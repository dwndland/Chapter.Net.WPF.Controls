// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendedTreeView.cs" company="my-libraries">
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

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Enhances the <see cref="ExtendedTreeView" /> with:<br />
///     * multi select,
///     * select an item by right click on it and
///     * a two way bindable SelectedItem.
/// </summary>
public class ExtendedTreeView : TreeView
{
    /// <summary>
    ///     Identifies the <see cref="SelectionMode" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty SelectionModeProperty =
        DependencyProperty.Register(nameof(SelectionMode), typeof(SelectionMode), typeof(ExtendedTreeView), new UIPropertyMetadata(SelectionMode.Extended));

    /// <summary>
    ///     Identifies the <see cref="SelectedItemChangedCommand" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty SelectedItemChangedCommandProperty =
        DependencyProperty.Register(nameof(SelectedItemChangedCommand), typeof(ICommand), typeof(ExtendedTreeView), new PropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="SelectedElement" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty SelectedElementProperty =
        DependencyProperty.Register(nameof(SelectedElement), typeof(object), typeof(ExtendedTreeView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedElementChanged));

    /// <summary>
    ///     Identifies the <see cref="AutoExpandSelected" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty AutoExpandSelectedProperty =
        DependencyProperty.Register(nameof(AutoExpandSelected), typeof(bool), typeof(ExtendedTreeView), new PropertyMetadata(false));

    private readonly PropertyInfo _isSelectionChangeActiveProperty;
    private ExtendedTreeViewItem _lastSelectedItem;
    private bool _selectionRequested;
    private bool _selfMultiSelect;
    private bool _selfSelectedElement;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ExtendedTreeView" /> class.
    /// </summary>
    public ExtendedTreeView()
    {
        PreviewMouseRightButtonDown += EnhancedTreeView_PreviewMouseRightButtonDown;
        _isSelectionChangeActiveProperty = typeof(ExtendedTreeView).GetProperty("IsSelectionChangeActive", BindingFlags.NonPublic | BindingFlags.Instance);
        SelectedTreeViewItems = new ObservableCollection<ExtendedTreeViewItem>();

        _selfMultiSelect = true;

        PreviewMouseDown += (sender, e) => _selfMultiSelect = false;
        PreviewMouseUp += (sender, e) => _selfMultiSelect = true;
        PreviewKeyDown += (sender, e) => _selfMultiSelect = false;
        PreviewKeyUp += (sender, e) => _selfMultiSelect = true;

        AddHandler(ExtendedTreeViewItem.ContainerGeneratedEvent, new RoutedEventHandler(HandleContainerGenerated));

        Loaded += (sender, args) =>
        {
            if (SelectedElement != null)
                TrySelectItem(null, SelectedElement);
        };
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
    public ObservableCollection<ExtendedTreeViewItem> SelectedTreeViewItems { get; }

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
    ///     Gets or sets a value which indicates if the ExtendedTreeViewItems gets expanded automatically to the selected item
    ///     when
    ///     using <see cref="SelectedElement" />.
    /// </summary>
    /// <remarks>
    ///     This works only if the items are not virtualized or were visible already.<br />
    ///     In ItemsPanelTemplate usually a VirtualizingStackPanel is used, then the ExtendedTreeViewItems gets created only
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
    ///     Generates a new child item container to hold in the <see cref="ExtendedTreeView" />.
    /// </summary>
    /// <returns>The generated child item container</returns>
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new ExtendedTreeViewItem();
    }

    /// <summary>
    ///     Checks if the item is already the correct item container. If not the <see cref="GetContainerForItemOverride" />
    ///     will be used to generate the right container.
    /// </summary>
    /// <param name="item">The item to shown in the <see cref="ExtendedTreeView" />.</param>
    /// <returns>True if the item is the correct item container already.</returns>
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is ExtendedTreeViewItem;
    }

    private void EnhancedTreeView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        var control = (ExtendedTreeView)sender;
        var clickedItem = control.InputHitTest(e.GetPosition(control));
        while (clickedItem != null && !(clickedItem is ExtendedTreeViewItem))
        {
            var frameworkElement = (FrameworkElement)clickedItem;
            clickedItem = (IInputElement)(frameworkElement.Parent ?? frameworkElement.TemplatedParent);
        }

        if (clickedItem != null)
            ((ExtendedTreeViewItem)clickedItem).IsSelected = true;
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

    private void HandleCodeSelection(ExtendedTreeViewItem newSelected)
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

    private void HandleControlKeySelection(ExtendedTreeViewItem newSelected)
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

    private void HandleShiftKeySelection(ExtendedTreeViewItem newSelectedItemContainer)
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

    private void HandleSingleSelection(ExtendedTreeViewItem newSelectedItem)
    {
        ClearAllSelections();
        newSelectedItem.IsSelected = true;
        SelectedTreeViewItems.Add(newSelectedItem);
        _lastSelectedItem = newSelectedItem;
    }

    private void Sort(ref int firstItemPos, ref int lastItemPos)
    {
        if (firstItemPos > lastItemPos)
            (firstItemPos, lastItemPos) = (lastItemPos, firstItemPos);
    }

    private List<ExtendedTreeViewItem> GetFlatTreeViewItems(ItemsControl control)
    {
        var items = new List<ExtendedTreeViewItem>();

        foreach (var item in control.Items)
        {
            var containerItem = item as ExtendedTreeViewItem ?? control.ItemContainerGenerator.ContainerFromItem(item) as ExtendedTreeViewItem;
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

    private ExtendedTreeViewItem GetSelectedContainer()
    {
        // ReSharper disable once PossibleNullReferenceException
        return (ExtendedTreeViewItem)typeof(TreeView).GetField("_selectedContainer", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
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
        var control = (ExtendedTreeView)d;
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

    private static ExtendedTreeViewItem GetContainerFromItem(ItemsControl parent, object item)
    {
        if (parent.ItemContainerGenerator.ContainerFromItem(item) is ExtendedTreeViewItem actualContainer)
            return actualContainer;

        foreach (var treeViewItem in parent.Items)
        {
            var container = parent.ItemContainerGenerator.ContainerFromItem(treeViewItem) as ExtendedTreeViewItem;
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

    private void Select(ExtendedTreeViewItem element)
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

    private void TryExpandTree(ExtendedTreeViewItem element)
    {
        var parents = GetParentsUntil<ExtendedTreeViewItem, ExtendedTreeView>(element).ToList();
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