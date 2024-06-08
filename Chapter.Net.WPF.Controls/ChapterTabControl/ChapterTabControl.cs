// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTabControl.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Enhances the TabControl with buttons for add new tab item and close buttons of existing tab items.
/// </summary>
[TemplatePart(Name = "PART_AddButton", Type = typeof(Button))]
public class ChapterTabControl : TabControl
{
    /// <summary>
    ///     Identifies the <see cref="ShowCloseButtons" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty ShowCloseButtonsProperty =
        DependencyProperty.Register(nameof(ShowCloseButtons), typeof(bool), typeof(ChapterTabControl), new UIPropertyMetadata(true));

    /// <summary>
    ///     Identifies the <see cref="ShowAddButton" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty ShowAddButtonProperty =
        DependencyProperty.Register(nameof(ShowAddButton), typeof(bool), typeof(ChapterTabControl), new UIPropertyMetadata(true));

    /// <summary>
    ///     Identifies the <see cref="TabItemClosingCommand" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty TabItemClosingCommandProperty =
        DependencyProperty.Register(nameof(TabItemClosingCommand), typeof(ICommand), typeof(ChapterTabControl), new UIPropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="TabItemAddingCommandParameter" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty TabItemAddingCommandParameterProperty =
        DependencyProperty.Register(nameof(TabItemAddingCommandParameter), typeof(object), typeof(ChapterTabControl), new UIPropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="TabItemAddingCommand" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty TabItemAddingCommandProperty =
        DependencyProperty.Register(nameof(TabItemAddingCommand), typeof(ICommand), typeof(ChapterTabControl), new UIPropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="AddButtonPosition" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty AddButtonPositionProperty =
        DependencyProperty.Register(nameof(AddButtonPosition), typeof(Dock), typeof(ChapterTabControl), new UIPropertyMetadata(Dock.Right));

    /// <summary>
    ///     Identifies the <see cref="AddButtonStyle" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty AddButtonStyleProperty =
        DependencyProperty.Register(nameof(AddButtonStyle), typeof(Style), typeof(ChapterTabControl), new PropertyMetadata(null));

    /// <summary>
    ///     The RoutedEvent for the AddClick event.
    /// </summary>
    public static readonly RoutedEvent AddClickEvent =
        EventManager.RegisterRoutedEvent(nameof(AddClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChapterTabControl));

    static ChapterTabControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterTabControl), new FrameworkPropertyMetadata(typeof(ChapterTabControl)));
    }

    /// <summary>
    ///     Gets or sets a value which indicates if the close buttons are shown on the tab items header.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool ShowCloseButtons
    {
        get => (bool)GetValue(ShowCloseButtonsProperty);
        set => SetValue(ShowCloseButtonsProperty, value);
    }

    /// <summary>
    ///     Gets or sets the value which indicates if the add new tab item button is shown.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool ShowAddButton
    {
        get => (bool)GetValue(ShowAddButtonProperty);
        set => SetValue(ShowAddButtonProperty, value);
    }

    /// <summary>
    ///     Gets or sets the command which gets called when the close on the tab item header is clicked. The tab DataContext is
    ///     forwarded as the command parameter.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public ICommand TabItemClosingCommand
    {
        get => (ICommand)GetValue(TabItemClosingCommandProperty);
        set => SetValue(TabItemClosingCommandProperty, value);
    }

    /// <summary>
    ///     Gets or sets the parameter which is passed with the <see cref="TabItemAddingCommand" /> command.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object TabItemAddingCommandParameter
    {
        get => GetValue(TabItemAddingCommandParameterProperty);
        set => SetValue(TabItemAddingCommandParameterProperty, value);
    }

    /// <summary>
    ///     Gets or sets the command which gets called when the add new tab item button is pressed.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public ICommand TabItemAddingCommand
    {
        get => (ICommand)GetValue(TabItemAddingCommandProperty);
        set => SetValue(TabItemAddingCommandProperty, value);
    }

    /// <summary>
    ///     Gets or sets the value which indicates where the add new tab item button has to be placed in the header.
    /// </summary>
    /// <value>Default: Dock.Right.</value>
    [DefaultValue(Dock.Right)]
    public Dock AddButtonPosition
    {
        get => (Dock)GetValue(AddButtonPositionProperty);
        set => SetValue(AddButtonPositionProperty, value);
    }

    /// <summary>
    ///     Gets or sets the add button style.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Style AddButtonStyle
    {
        get => (Style)GetValue(AddButtonStyleProperty);
        set => SetValue(AddButtonStyleProperty, value);
    }

    /// <summary>
    ///     Add or removes the event handler for the AddClick routed event.
    /// </summary>
    public event RoutedEventHandler AddClick
    {
        add => AddHandler(AddClickEvent, value);
        remove => RemoveHandler(AddClickEvent, value);
    }

    /// <inheritdoc />
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (GetTemplateChild("PART_AddButton") is Button addButton)
            addButton.Click += OnAddButtonClick;
    }

    /// <summary>
    ///     Generates a new child item container to hold in the <see cref="ChapterTabControl" />.
    /// </summary>
    /// <returns>The generated child item container</returns>
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new ChapterTabItem();
    }

    /// <summary>
    ///     Checks if the item is already the correct item container. If not the <see cref="GetContainerForItemOverride" />
    ///     will be used to generate the right container.
    /// </summary>
    /// <param name="item">The item to shown in the <see cref="ChapterTabControl" />.</param>
    /// <returns>True if the item is the correct item container already.</returns>
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is ChapterTabItem;
    }

    private void OnAddButtonClick(object sender, RoutedEventArgs e)
    {
        RaiseEvent(new RoutedEventArgs(AddClickEvent, this));
    }
}