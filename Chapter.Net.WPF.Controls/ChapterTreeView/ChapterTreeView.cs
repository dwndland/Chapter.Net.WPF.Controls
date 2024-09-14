// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTreeView.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Enhances the <see cref="ChapterTreeView" /> with:<br />
///     * multi select,
///     * select an item by right click on it and
///     * a two way bindable SelectedItem.
/// </summary>
public class ChapterTreeView : TreeViewBase
{
    /// <summary>
    ///     Identifies the <see cref="SelectionMode" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty SelectionModeProperty =
        DependencyProperty.Register(nameof(SelectionMode), typeof(SelectionMode), typeof(ChapterTreeView), new UIPropertyMetadata(SelectionMode.Extended));

    /// <summary>
    ///     Identifies the <see cref="SelectedItemChangedCommand" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty SelectedItemChangedCommandProperty =
        DependencyProperty.Register(nameof(SelectedItemChangedCommand), typeof(ICommand), typeof(ChapterTreeView), new PropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="SelectedElement" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty SelectedElementProperty =
        DependencyProperty.Register(nameof(SelectedElement), typeof(object), typeof(ChapterTreeView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedElementChanged));

    /// <summary>
    ///     Identifies the <see cref="AutoExpandSelected" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty AutoExpandSelectedProperty =
        DependencyProperty.Register(nameof(AutoExpandSelected), typeof(bool), typeof(ChapterTreeView), new PropertyMetadata(false));

    private readonly PropertyInfo _isSelectionChangeActiveProperty;
    private ChapterTreeViewItem _lastSelectedItem;
    private bool _selectionRequested;
    private bool _selfMultiSelect;
    private bool _selfSelectedElement;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ChapterTreeView" /> class.
    /// </summary>
    public ChapterTreeView()
    {
        PreviewMouseRightButtonDown += EnhancedTreeView_PreviewMouseRightButtonDown;
        _isSelectionChangeActiveProperty = typeof(ChapterTreeView).GetProperty("IsSelectionChangeActive", BindingFlags.NonPublic | BindingFlags.Instance);
        SelectedTreeViewItems = [];

        _selfMultiSelect = true;

        PreviewMouseDown += (_, _) => _selfMultiSelect = false;
        PreviewMouseUp += (_, _) => _selfMultiSelect = true;
        PreviewKeyDown += (_, _) => _selfMultiSelect = false;
        PreviewKeyUp += (_, _) => _selfMultiSelect = true;

        AddHandler(ChapterTreeViewItem.ContainerGeneratedEvent, new RoutedEventHandler(HandleContainerGenerated));
    }

    /// <summary>
    ///     Gets all selected items in the tree view. If nothing is selected an empty list is returned.
    /// </summary>
    public ObservableCollection<object> SelectedItems
    {
        get { return new ObservableCollection<object>(SelectedTreeViewItems.Select(i => i.DataContext)); }
    }

    /// <summary>
    ///     Gets the selected tree view item container.
    /// </summary>
    public ObservableCollection<ChapterTreeViewItem> SelectedTreeViewItems { get; }

    /// <summary>
    ///     Gets or set a value which indicates how items can be selected in the tree view.
    /// </summary>
    /// <value>Default: SelectionMode.Extended.</value>
    [DefaultValue(SelectionMode.Extended)]
    public SelectionMode SelectionMode
    {
        get => (SelectionMode)GetValue(SelectionModeProperty);
        set => SetValue(SelectionModeProperty, value);
    }

    /// <summary>
    ///     Gets or sets the command to be executed if a item got selected.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public ICommand SelectedItemChangedCommand
    {
        get => (ICommand)GetValue(SelectedItemChangedCommandProperty);
        set => SetValue(SelectedItemChangedCommandProperty, value);
    }

    /// <summary>
    ///     Gets or sets the selected item in the tree.
    /// </summary>
    /// <remarks>
    ///     The parent elements will not be expanded automatically. Check <see cref="AutoExpandSelected" /> for try to
    ///     expand them.
    /// </remarks>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object SelectedElement
    {
        get => GetValue(SelectedElementProperty);
        set => SetValue(SelectedElementProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value which indicates if the ChapterTreeViewItems gets expanded automatically to the selected item
    ///     when
    ///     using <see cref="SelectedElement" />.
    /// </summary>
    /// <remarks>
    ///     This works only if the items are not virtualized or were visible already.<br />
    ///     In ItemsPanelTemplate usually a VirtualizingStackPanel is used, then the ChapterTreeViewItems gets created only
    ///     after
    ///     expanding the parent.<br />
    ///     With overriding the ItemsPanel with a normal StackPanel all container should get created directly, but then the
    ///     performance will suffer depending an the amount of items.<br />
    ///     <br />
    ///     The default value is false.
    /// </remarks>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool AutoExpandSelected
    {
        get => (bool)GetValue(AutoExpandSelectedProperty);
        set => SetValue(AutoExpandSelectedProperty, value);
    }

    /// <summary>
    ///     Generates a new child item container to hold in the <see cref="ChapterTreeView" />.
    /// </summary>
    /// <returns>The generated child item container</returns>
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new ChapterTreeViewItem();
    }

    /// <summary>
    ///     Checks if the item is already the correct item container. If not the <see cref="GetContainerForItemOverride" />
    ///     will be used to generate the right container.
    /// </summary>
    /// <param name="item">The item to shown in the <see cref="ChapterTreeView" />.</param>
    /// <returns>True if the item is the correct item container already.</returns>
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is ChapterTreeViewItem;
    }

    /// <inheritdoc />
    protected override void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (SelectedElement != null)
            TrySelectItem(null, SelectedElement);
    }

    private void EnhancedTreeView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        var control = (ChapterTreeView)sender;
        var clickedItem = control.InputHitTest(e.GetPosition(control));
        while (clickedItem != null && !(clickedItem is ChapterTreeViewItem))
        {
            var frameworkElement = (FrameworkElement)clickedItem;
            clickedItem = (IInputElement)(frameworkElement.Parent ?? frameworkElement.TemplatedParent);
        }

        if (clickedItem != null)
            ((ChapterTreeViewItem)clickedItem).IsSelected = true;
    }

    /// <summary>
    ///     Handles the selection changing depending on the <see cref="SelectionMode" />.
    /// </summary>
    /// <param name="e">The data passed by the caller.</param>
    protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
    {
        base.OnSelectedItemChanged(e);

        OnSelectedItemChangedCommand(e.NewValue);

        if (SelectionMode == SelectionMode.Single)
            return;

        DisableSelectionChangedEvent();

        var newSelected = GetSelectedContainer();
        if (newSelected != null)
        {
            if (_selfMultiSelect)
                HandleCodeSelection(newSelected);
            else if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control) || SelectionMode == SelectionMode.Multiple)
                HandleControlKeySelection(newSelected);
            else if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
                HandleShiftKeySelection(newSelected);
            else
                HandleSingleSelection(newSelected);
        }

        EnableSelectionChangedEvent();
    }

    private void HandleCodeSelection(ChapterTreeViewItem newSelected)
    {
        HandleControlKeySelection(newSelected);
        RemoveDeselectedItemContainers();
    }

    private void RemoveDeselectedItemContainers()
    {
        for (var i = 0; i < SelectedTreeViewItems.Count; i++)
            if (!SelectedTreeViewItems[i].IsSelected)
                SelectedTreeViewItems.RemoveAt(i);
    }

    private void HandleControlKeySelection(ChapterTreeViewItem newSelected)
    {
        if (SelectedTreeViewItems.Contains(newSelected))
        {
            newSelected.IsSelected = false;
            SelectedTreeViewItems.Remove(newSelected);
            if (_lastSelectedItem != null)
                _lastSelectedItem.IsSelected = true;
            _lastSelectedItem = null;
        }
        else
        {
            if (_lastSelectedItem != null)
                _lastSelectedItem.IsSelected = true;
            SelectedTreeViewItems.Add(newSelected);
            _lastSelectedItem = newSelected;
        }
    }

    private void HandleShiftKeySelection(ChapterTreeViewItem newSelectedItemContainer)
    {
        if (_lastSelectedItem != null)
        {
            ClearAllSelections();
            var items = GetFlatTreeViewItems(this);

            var firstItemPos = items.IndexOf(_lastSelectedItem);
            var lastItemPos = items.IndexOf(newSelectedItemContainer);
            Sort(ref firstItemPos, ref lastItemPos);

            for (var i = firstItemPos; i <= lastItemPos; ++i)
            {
                items[i].IsSelected = true;
                SelectedTreeViewItems.Add(items[i]);
            }
        }
    }

    private void HandleSingleSelection(ChapterTreeViewItem newSelectedItem)
    {
        ClearAllSelections();
        newSelectedItem.IsSelected = true;
        SelectedTreeViewItems.Add(newSelectedItem);
        _lastSelectedItem = newSelectedItem;
    }

    private void Sort(ref int firstItemPos, ref int lastItemPos)
    {
        if (firstItemPos > lastItemPos) (firstItemPos, lastItemPos) = (lastItemPos, firstItemPos);
    }

    private List<ChapterTreeViewItem> GetFlatTreeViewItems(ItemsControl control)
    {
        var items = new List<ChapterTreeViewItem>();

        foreach (var item in control.Items)
        {
            var containerItem = item as ChapterTreeViewItem ?? control.ItemContainerGenerator.ContainerFromItem(item) as ChapterTreeViewItem;
            if (containerItem != null)
            {
                items.Add(containerItem);
                if (containerItem.IsExpanded)
                    items.AddRange(GetFlatTreeViewItems(containerItem));
            }
        }

        return items;
    }

    private void ClearAllSelections()
    {
        while (SelectedTreeViewItems.Count > 0)
        {
            SelectedTreeViewItems[0].IsSelected = false;
            SelectedTreeViewItems.RemoveAt(0);
        }
    }

    private ChapterTreeViewItem GetSelectedContainer()
    {
        // ReSharper disable once PossibleNullReferenceException
        return (ChapterTreeViewItem)typeof(TreeView).GetField("_selectedContainer", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
    }

    private void DisableSelectionChangedEvent()
    {
        _isSelectionChangeActiveProperty.SetValue(this, true, null);
    }

    private void EnableSelectionChangedEvent()
    {
        _isSelectionChangeActiveProperty.SetValue(this, false, null);
    }

    private void OnSelectedItemChangedCommand(object newValue)
    {
        if (SelectedItemChangedCommand != null && SelectedItemChangedCommand.CanExecute(newValue))
            SelectedItemChangedCommand.Execute(newValue);

        if (_selfSelectedElement)
            return;

        _selfSelectedElement = true;
        SelectedElement = newValue;
        _selfSelectedElement = false;
    }

    private static void OnSelectedElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterTreeView)d;
        if (control._selfSelectedElement)
            return;

        control.TrySelectItem(e.OldValue, e.NewValue);
    }

    private void TrySelectItem(object oldSelectedElement, object newSelectedElement)
    {
        _selfSelectedElement = true;

        if (oldSelectedElement != null)
            Deselect(oldSelectedElement);

        if (newSelectedElement == null)
        {
            _selfSelectedElement = false;
            return;
        }

        var container = GetContainerFromItem(this, newSelectedElement);
        if (container != null)
            Select(container);
        else
            _selectionRequested = true;

        _selfSelectedElement = false;
    }

    private static ChapterTreeViewItem GetContainerFromItem(ItemsControl parent, object item)
    {
        if (parent.ItemContainerGenerator.ContainerFromItem(item) is ChapterTreeViewItem actualContainer)
            return actualContainer;

        foreach (var treeViewItem in parent.Items)
        {
            var container = parent.ItemContainerGenerator.ContainerFromItem(treeViewItem) as ChapterTreeViewItem;
            if (container == null)
                continue;

            var foundContainer = GetContainerFromItem(container, item);
            if (foundContainer != null)
                return foundContainer;
        }

        return null;
    }

    private void HandleContainerGenerated(object sender, RoutedEventArgs e)
    {
        if (!_selectionRequested)
            return;

        _selectionRequested = false;
        TrySelectItem(null, SelectedElement);
    }

    private void Deselect(object oldSelectedElement)
    {
        var container = GetContainerFromItem(this, oldSelectedElement);
        if (container != null)
        {
            container.IsSelected = false;
            if (Equals(container, _lastSelectedItem))
                _lastSelectedItem = null;
            SelectedTreeViewItems.Remove(container);
        }
    }

    private void Select(ChapterTreeViewItem element)
    {
        if (element.IsSelected)
            return;

        element.IsSelected = true;
        _lastSelectedItem = element;
        SelectedTreeViewItems.Add(element);
        element.BringIntoView();

        if (AutoExpandSelected)
            TryExpandTree(element);
    }

    private void TryExpandTree(ChapterTreeViewItem element)
    {
        var parents = GetParentsUntil<ChapterTreeViewItem, ChapterTreeView>(element).ToList();
        parents.ForEach(p => p.IsExpanded = true);
        element.BringIntoView();
    }

    private static List<TParentType> GetParentsUntil<TParentType, TEndType>(DependencyObject item) where TParentType : DependencyObject where TEndType : DependencyObject
    {
        var parents = new List<TParentType>();
        if (item == null)
            return parents;

        var parent = VisualTreeHelper.GetParent(item);
        while (parent != null && !(parent is TEndType))
        {
            if (parent is TParentType parentType)
                parents.Add(parentType);
            parent = VisualTreeHelper.GetParent(parent);
        }

        return parents;
    }
}