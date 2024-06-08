// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationView.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A burger menu with items to navigate with.
/// </summary>
[TemplatePart(Name = "PART_BackButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_ContentPresenter", Type = typeof(FrameworkElement))]
[TemplatePart(Name = "PART_SearchControl", Type = typeof(Button))]
[TemplatePart(Name = "PART_ItemsPresenter", Type = typeof(ChapterNavigationTreeItemsPresenter))]
[TemplatePart(Name = "PART_FooterItemsPresenter", Type = typeof(ChapterNavigationTreeItemsPresenter))]
[ContentProperty(nameof(Content))]
public class ChapterNavigationView : ComboBoxBase
{
    /// <summary>
    ///     The ChapterNavigationView style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterNavigationView), "ChapterNavigationView");

    /// <summary>
    ///     The DisplayMode dependency property.
    /// </summary>
    public static readonly DependencyProperty DisplayModeProperty =
        DependencyProperty.Register(nameof(DisplayMode), typeof(NavigationDisplayMode), typeof(ChapterNavigationView), new PropertyMetadata(NavigationDisplayMode.Left, OnDisplayModeChanged));

    /// <summary>
    ///     The IsExpanded dependency property.
    /// </summary>
    public static readonly DependencyProperty IsExpandedProperty =
        DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(ChapterNavigationView), new PropertyMetadata(true, OnExpandChanged));

    /// <summary>
    ///     The Content dependency property.
    /// </summary>
    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(nameof(Content), typeof(object), typeof(ChapterNavigationView), new PropertyMetadata(null));

    /// <summary>
    ///     The Header dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(object), typeof(ChapterNavigationView), new PropertyMetadata(null));

    /// <summary>
    ///     The Title dependency property.
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(object), typeof(ChapterNavigationView), new PropertyMetadata(null));

    /// <summary>
    ///     The IsBackButtonVisible dependency property.
    /// </summary>
    public static readonly DependencyProperty IsBackButtonVisibleProperty =
        DependencyProperty.Register(nameof(IsBackButtonVisible), typeof(bool), typeof(ChapterNavigationView), new PropertyMetadata(false));

    /// <summary>
    ///     The CurrentDisplayMode dependency property.
    /// </summary>
    public static readonly DependencyProperty BackCommandProperty =
        DependencyProperty.Register(nameof(BackCommand), typeof(ICommand), typeof(ChapterNavigationView), new PropertyMetadata(null));

    /// <summary>
    ///     The CurrentDisplayMode dependency property.
    /// </summary>
    public static readonly DependencyProperty BackCommandParameterProperty =
        DependencyProperty.Register(nameof(BackCommandParameter), typeof(object), typeof(ChapterNavigationView), new PropertyMetadata(null));

    /// <summary>
    ///     The SearchControl dependency property.
    /// </summary>
    public static readonly DependencyProperty SearchControlProperty =
        DependencyProperty.Register(nameof(SearchControl), typeof(object), typeof(ChapterNavigationView), new PropertyMetadata(null));

    /// <summary>
    ///     The IsBurgerButtonVisible dependency property.
    /// </summary>
    public static readonly DependencyProperty IsBurgerButtonVisibleProperty =
        DependencyProperty.Register(nameof(IsBurgerButtonVisible), typeof(bool), typeof(ChapterNavigationView), new PropertyMetadata(true));

    /// <summary>
    ///     The LeftToLeftCompactThreshold dependency property.
    /// </summary>
    public static readonly DependencyProperty LeftToLeftCompactThresholdProperty =
        DependencyProperty.Register(nameof(LeftToLeftCompactThreshold), typeof(double), typeof(ChapterNavigationView), new PropertyMetadata(1000d));

    /// <summary>
    ///     The LeftCompactToLeftMinimalThreshold dependency property.
    /// </summary>
    public static readonly DependencyProperty LeftCompactToLeftMinimalThresholdProperty =
        DependencyProperty.Register(nameof(LeftCompactToLeftMinimalThreshold), typeof(double), typeof(ChapterNavigationView), new PropertyMetadata(600d));

    /// <summary>
    ///     The Items dependency property.
    /// </summary>
    public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register(nameof(Items), typeof(IList), typeof(ChapterNavigationView), new PropertyMetadata(null));

    /// <summary>
    ///     The FooterItems dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterItemsProperty =
        DependencyProperty.Register(nameof(FooterItems), typeof(IList), typeof(ChapterNavigationView), new PropertyMetadata(null));

    /// <summary>
    ///     The FooterItemContainerStyle dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterItemContainerStyleProperty =
        DependencyProperty.Register(nameof(FooterItemContainerStyle), typeof(Style), typeof(ChapterNavigationView), new PropertyMetadata(null));

    /// <summary>
    ///     The FooterItemTemplate dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterItemTemplateProperty =
        DependencyProperty.Register(nameof(FooterItemTemplate), typeof(DataTemplate), typeof(ChapterNavigationView), new PropertyMetadata(null));

    /// <summary>
    ///     The SelectedItem dependency property.
    /// </summary>
    public new static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(ChapterNavigationView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    /// <summary>
    ///     The AllowMultiExpanding dependency property.
    /// </summary>
    public static readonly DependencyProperty AllowMultiExpandingProperty =
        DependencyProperty.Register(nameof(AllowMultiExpanding), typeof(bool), typeof(ChapterNavigationView), new PropertyMetadata(false));

    /// <summary>
    ///     The IsBurgerButtonVisibleForExpandedLeftMinimal dependency property.
    /// </summary>
    public static readonly DependencyProperty IsBurgerButtonVisibleForExpandedLeftMinimalProperty =
        DependencyProperty.Register(nameof(IsBurgerButtonVisibleForExpandedLeftMinimal), typeof(bool), typeof(ChapterNavigationView), new PropertyMetadata(true));

    /// <summary>
    ///     The CollapsedPanelSize dependency property.
    /// </summary>
    public static readonly DependencyProperty CollapsedPanelSizeProperty =
        DependencyProperty.Register(nameof(CollapsedPanelSize), typeof(double), typeof(ChapterNavigationView), new PropertyMetadata(40d));

    /// <summary>
    ///     The ExtendedPanelSize dependency property.
    /// </summary>
    public static readonly DependencyProperty ExtendedPanelSizeProperty =
        DependencyProperty.Register(nameof(ExtendedPanelSize), typeof(double), typeof(ChapterNavigationView), new PropertyMetadata(210d));

    /// <summary>
    ///     The DisableAnimations dependency property.
    /// </summary>
    public static readonly DependencyProperty DisableAnimationsProperty =
        DependencyProperty.Register(nameof(DisableAnimations), typeof(bool), typeof(ChapterNavigationView), new PropertyMetadata(false));

    /// <summary>
    ///     The AnimationSpeed dependency property.
    /// </summary>
    public static readonly DependencyProperty AnimationSpeedProperty =
        DependencyProperty.Register(nameof(AnimationSpeed), typeof(TimeSpan), typeof(ChapterNavigationView), new PropertyMetadata(TimeSpan.FromMilliseconds(120)));

    /// <summary>
    ///     The CurrentDisplayMode dependency property.
    /// </summary>
    internal static readonly DependencyProperty CurrentDisplayModeProperty =
        DependencyProperty.Register(nameof(CurrentDisplayMode), typeof(NavigationDisplayMode), typeof(ChapterNavigationView), new PropertyMetadata(NavigationDisplayMode.Left));

    /// <summary>
    ///     The ExtendedColumnWidth dependency property.
    /// </summary>
    internal static readonly DependencyProperty ExtendedColumnWidthProperty =
        DependencyProperty.Register(nameof(ExtendedColumnWidth), typeof(double), typeof(ChapterNavigationView), new PropertyMetadata(210d));

    /// <summary>
    ///     The RoutedEvent for the BackClick event.
    /// </summary>
    public static readonly RoutedEvent BackClickEvent =
        EventManager.RegisterRoutedEvent(nameof(BackClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChapterBrowseTextBox));

    private ChapterNavigationTreeItemsPresenter _footerItemsPresenter;
    private ChapterNavigationTreeItemsPresenter _itemsPresenter;

    static ChapterNavigationView()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationView), new FrameworkPropertyMetadata(typeof(ChapterNavigationView)));
    }

    /// <summary>
    ///     Creates a new instance of ChapterNavigationView.
    /// </summary>
    public ChapterNavigationView()
    {
        Items = new ObservableCollection<ChapterNavigationViewItem>();
        FooterItems = new ObservableCollection<ChapterNavigationViewItem>();

        AddHandler(TreeViewItem.ExpandedEvent, new RoutedEventHandler(OnItemExpanded));
    }

    /// <summary>
    ///     Gets or sets the current display mode.
    /// </summary>
    /// <value>Default: NavigationDisplayMode.Left.</value>
    [DefaultValue(NavigationDisplayMode.Left)]
    public NavigationDisplayMode DisplayMode
    {
        get => (NavigationDisplayMode)GetValue(DisplayModeProperty);
        set => SetValue(DisplayModeProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the navigation is expanded in the Left display mode or not.
    /// </summary>
    /// <remarks>
    ///     This property us used only if the <see cref="DisplayMode" /> is set to left. In LeftCompact or LeftMinimal the
    ///     <see cref="ComboBox.IsDropDownOpen" /> is used.
    /// </remarks>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    /// <summary>
    ///     Gets or sets the header shown in the body of the navigation view.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    /// <summary>
    ///     Gets or sets the content shown in the body of the navigation view.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    /// <summary>
    ///     Gets or sets the title control shown within the burger button.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the back button is visible or not.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool IsBackButtonVisible
    {
        get => (bool)GetValue(IsBackButtonVisibleProperty);
        set => SetValue(IsBackButtonVisibleProperty, value);
    }

    /// <summary>
    ///     Gets or sets the command to execute by click on the back button.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public ICommand BackCommand
    {
        get => (ICommand)GetValue(BackCommandProperty);
        set => SetValue(BackCommandProperty, value);
    }

    /// <summary>
    ///     Gets or sets the parameter to send with the <see cref="BackCommand" />.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object BackCommandParameter
    {
        get => GetValue(BackCommandParameterProperty);
        set => SetValue(BackCommandParameterProperty, value);
    }

    /// <summary>
    ///     Gets or sets the search control.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object SearchControl
    {
        get => GetValue(SearchControlProperty);
        set => SetValue(SearchControlProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the burger button is visible or not.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool IsBurgerButtonVisible
    {
        get => (bool)GetValue(IsBurgerButtonVisibleProperty);
        set => SetValue(IsBurgerButtonVisibleProperty, value);
    }

    /// <summary>
    ///     Gets or sets the threshold when the view shall switch from Left to LeftCompact in the case of Auto display mode.
    /// </summary>
    /// <value>Default: 1000.</value>
    [DefaultValue(1000d)]
    public double LeftToLeftCompactThreshold
    {
        get => (double)GetValue(LeftToLeftCompactThresholdProperty);
        set => SetValue(LeftToLeftCompactThresholdProperty, value);
    }

    /// <summary>
    ///     Gets or sets the threshold when the view shall switch from LeftCompact to LeftMinimal in the case of Auto display
    ///     mode.
    /// </summary>
    /// <value>Default: 600.</value>
    [DefaultValue(600d)]
    public double LeftCompactToLeftMinimalThreshold
    {
        get => (double)GetValue(LeftCompactToLeftMinimalThresholdProperty);
        set => SetValue(LeftCompactToLeftMinimalThresholdProperty, value);
    }

    /// <summary>
    ///     Gets or sets the main items.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public new IList Items
    {
        get => (IList)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    /// <summary>
    ///     Gets or sets footer items.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public IList FooterItems
    {
        get => (IList)GetValue(FooterItemsProperty);
        set => SetValue(FooterItemsProperty, value);
    }

    /// <summary>
    ///     Gets or sets the item container styles for the footer items.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Style FooterItemContainerStyle
    {
        get => (Style)GetValue(FooterItemContainerStyleProperty);
        set => SetValue(FooterItemContainerStyleProperty, value);
    }

    /// <summary>
    ///     Gets or sets item templates for the footer items.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public DataTemplate FooterItemTemplate
    {
        get => (DataTemplate)GetValue(FooterItemTemplateProperty);
        set => SetValue(FooterItemTemplateProperty, value);
    }

    /// <summary>
    ///     Gets or sets the current selected item.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public new object SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the navigation view allows multiple expanded items.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool AllowMultiExpanding
    {
        get => (bool)GetValue(AllowMultiExpandingProperty);
        set => SetValue(AllowMultiExpandingProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the burger button shall be shown or hidden if DisplayMode is LeftMinimal
    ///     and the menu is open.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool IsBurgerButtonVisibleForExpandedLeftMinimal
    {
        get => (bool)GetValue(IsBurgerButtonVisibleForExpandedLeftMinimalProperty);
        set => SetValue(IsBurgerButtonVisibleForExpandedLeftMinimalProperty, value);
    }

    /// <summary>
    ///     Gets or sets the panel size if collapsed.
    /// </summary>
    /// <value>Default: 40d.</value>
    [DefaultValue(40d)]
    public double CollapsedPanelSize
    {
        get => (double)GetValue(CollapsedPanelSizeProperty);
        set => SetValue(CollapsedPanelSizeProperty, value);
    }

    /// <summary>
    ///     Gets or sets the panel size if extended.
    /// </summary>
    /// <value>Default: 210d.</value>
    [DefaultValue(210d)]
    public double ExtendedPanelSize
    {
        get => (double)GetValue(ExtendedPanelSizeProperty);
        set => SetValue(ExtendedPanelSizeProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the panel expand and collapsed shall be animated or not.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool DisableAnimations
    {
        get => (bool)GetValue(DisableAnimationsProperty);
        set => SetValue(DisableAnimationsProperty, value);
    }

    /// <summary>
    ///     Gets or sets the speed of the panel expand and collapse animation.
    /// </summary>
    /// <value>Default: 120ms.</value>
    public TimeSpan AnimationSpeed
    {
        get => (TimeSpan)GetValue(AnimationSpeedProperty);
        set => SetValue(AnimationSpeedProperty, value);
    }

    /// <summary>
    ///     Gets or sets the current display mode which gets controlled by the DisplayMode.
    /// </summary>
    /// <value>Default: NavigationDisplayMode.Left.</value>
    [DefaultValue(NavigationDisplayMode.Left)]
    internal NavigationDisplayMode CurrentDisplayMode
    {
        get => (NavigationDisplayMode)GetValue(CurrentDisplayModeProperty);
        set => SetValue(CurrentDisplayModeProperty, value);
    }

    /// <summary>
    ///     Gets or sets the width of the extended column.
    /// </summary>
    /// <value>Default: 210d</value>
    [DefaultValue(210d)]
    internal double ExtendedColumnWidth
    {
        get => (double)GetValue(ExtendedColumnWidthProperty);
        set => SetValue(ExtendedColumnWidthProperty, value);
    }

    /// <summary>
    ///     Add or removes the event handler for the BackClick routed event.
    /// </summary>
    public event RoutedEventHandler BackClick
    {
        add => AddHandler(BackClickEvent, value);
        remove => RemoveHandler(BackClickEvent, value);
    }

    private static void OnDisplayModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterNavigationView)d;
        if (control.DisplayMode != NavigationDisplayMode.Auto)
            control.SetCurrentValue(CurrentDisplayModeProperty, control.DisplayMode);
        else
            control.SetCurrentDisplayModeByWidth(control.ActualWidth);

        control.AnimatePanelSize();
    }

    private static void OnExpandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterNavigationView)d;
        control.AnimatePanelSize();
    }

    private void AnimatePanelSize()
    {
        switch (CurrentDisplayMode)
        {
            case NavigationDisplayMode.Left:
                if (IsExpanded)
                    AnimatePanelSize(0, ExtendedPanelSize);
                else
                    AnimatePanelSize(ExtendedPanelSize, 0);
                break;
            case NavigationDisplayMode.LeftCompact:
                if (IsDropDownOpen)
                    AnimatePanelSize(0, ExtendedPanelSize);
                else
                    AnimatePanelSize(ExtendedPanelSize, 0);
                break;
            case NavigationDisplayMode.LeftMinimal:
                if (IsDropDownOpen)
                    AnimatePanelSize(0, CollapsedPanelSize + ExtendedPanelSize);
                else
                    AnimatePanelSize(CollapsedPanelSize + ExtendedPanelSize, 0);
                break;
            case NavigationDisplayMode.Top:
                SetCurrentValue(ExtendedColumnWidthProperty, 0d);
                break;
        }
    }

    private void AnimatePanelSize(double from, double to)
    {
        if (DisableAnimations)
        {
            SetCurrentValue(ExtendedColumnWidthProperty, to);
            return;
        }

        var doubleAnimation = new DoubleAnimation(from, to, new Duration(AnimationSpeed));
        BeginAnimation(ExtendedColumnWidthProperty, doubleAnimation);
    }

    /// <inheritdoc />
    protected override void OnDropDownOpened(EventArgs e)
    {
        base.OnDropDownOpened(e);
        AnimatePanelSize();
    }

    /// <inheritdoc />
    protected override void OnDropDownClosed(EventArgs e)
    {
        base.OnDropDownClosed(e);
        AnimatePanelSize();
    }

    /// <inheritdoc />
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (GetTemplateChild("PART_ContentPresenter") is FrameworkElement contentPresenter)
            contentPresenter.PreviewMouseLeftButtonDown += OnContentClick;

        if (GetTemplateChild("PART_BackButton") is Button backButton)
            backButton.Click += OnBackClick;

        if (GetTemplateChild("PART_SearchControl") is Button searchButton)
            searchButton.Click += OnSearchClick;

        _itemsPresenter = GetTemplateChild("PART_ItemsPresenter") as ChapterNavigationTreeItemsPresenter;
        _footerItemsPresenter = GetTemplateChild("PART_FooterItemsPresenter") as ChapterNavigationTreeItemsPresenter;
    }

    /// <inheritdoc />
    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        if (DisplayMode == NavigationDisplayMode.Auto && sizeInfo.WidthChanged)
            SetCurrentDisplayModeByWidth(sizeInfo.NewSize.Width);

        base.OnRenderSizeChanged(sizeInfo);
    }

    private void OnItemExpanded(object sender, RoutedEventArgs e)
    {
        if (!AllowMultiExpanding)
        {
            if (!(e.OriginalSource is ChapterNavigationViewItem container) || container.Level != 0)
                return;

            _itemsPresenter.CollapseAllExcept(e.OriginalSource);
            _footerItemsPresenter.CollapseAllExcept(e.OriginalSource);
        }
    }

    private void OnContentClick(object sender, MouseButtonEventArgs e)
    {
        SetCurrentValue(IsDropDownOpenProperty, false);
    }

    private void OnBackClick(object sender, RoutedEventArgs e)
    {
        RaiseEvent(new RoutedEventArgs(BackClickEvent, this));
    }

    private void OnSearchClick(object sender, RoutedEventArgs e)
    {
        SetCurrentValue(CurrentDisplayMode == NavigationDisplayMode.Left ? IsExpandedProperty : IsDropDownOpenProperty, true);

        var button = (Button)e.OriginalSource;
        var childTextBox = VisualTreeAssist.FindChild<TextBox>(button);
        if (childTextBox != null)
            ControlFocus.GiveFocus(childTextBox);
    }

    private void SetCurrentDisplayModeByWidth(double width)
    {
        if (width < LeftCompactToLeftMinimalThreshold)
            SetCurrentValue(CurrentDisplayModeProperty, NavigationDisplayMode.LeftMinimal);
        else if (width < LeftToLeftCompactThreshold)
            SetCurrentValue(CurrentDisplayModeProperty, NavigationDisplayMode.LeftCompact);
        else
            SetCurrentValue(CurrentDisplayModeProperty, NavigationDisplayMode.Left);
    }
}