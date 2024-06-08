// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterSplitButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A button with a drop down where more commands can be available.
/// </summary>
[TemplatePart(Name = "PART_MainButton", Type = typeof(ButtonBase))]
public class ChapterSplitButton : ComboBox
{
    /// <summary>
    ///     The DependencyProperty for the Command property.
    /// </summary>
    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ChapterSplitButton), new PropertyMetadata(null));

    /// <summary>
    ///     The DependencyProperty for the CommandParameter property.
    /// </summary>
    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(ChapterSplitButton), new PropertyMetadata(null));

    /// <summary>
    ///     The DependencyProperty for the Content property.
    /// </summary>
    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(nameof(Content), typeof(object), typeof(ChapterSplitButton), new PropertyMetadata(null));

    /// <summary>
    ///     The DependencyProperty for the ContentTemplate property.
    /// </summary>
    public static readonly DependencyProperty ContentTemplateProperty =
        DependencyProperty.Register(nameof(ContentTemplate), typeof(DataTemplate), typeof(ChapterSplitButton), new PropertyMetadata(null));

    /// <summary>
    ///     The DependencyProperty for the ContentTemplateSelector property.
    /// </summary>
    public static readonly DependencyProperty ContentTemplateSelectorProperty =
        DependencyProperty.Register(nameof(ContentTemplateSelector), typeof(DataTemplateSelector), typeof(ChapterSplitButton), new PropertyMetadata(null));

    /// <summary>
    ///     The RoutedEvent for the Click event.
    /// </summary>
    public static readonly RoutedEvent ClickEvent =
        EventManager.RegisterRoutedEvent(nameof(Click), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChapterSplitButton));

    static ChapterSplitButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterSplitButton), new FrameworkPropertyMetadata(typeof(ChapterSplitButton)));
    }

    /// <summary>
    ///     Gets or sets the content template for the main button.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public DataTemplate ContentTemplate
    {
        get => (DataTemplate)GetValue(ContentTemplateProperty);
        set => SetValue(ContentTemplateProperty, value);
    }

    /// <summary>
    ///     Gets or sets the content template selector for the main button.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public DataTemplateSelector ContentTemplateSelector
    {
        get => (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty);
        set => SetValue(ContentTemplateSelectorProperty, value);
    }

    /// <summary>
    ///     Gets or sets the content of the main button.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    /// <summary>
    ///     Gets or sets the command of the main button.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    /// <summary>
    ///     Gets or sets the command parameter of the main button.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    /// <summary>
    ///     Add or removes the event handler for the click routed event.
    /// </summary>
    public event RoutedEventHandler Click
    {
        add => AddHandler(ClickEvent, value);
        remove => RemoveHandler(ClickEvent, value);
    }

    /// <summary>
    ///     The template of the control got applied.
    /// </summary>
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (GetTemplateChild("PART_MainButton") is ButtonBase button)
            button.Click += OnMainButtonClick;
    }

    private void OnMainButtonClick(object sender, RoutedEventArgs e)
    {
        var newEventArgs = new RoutedEventArgs(ClickEvent, this);
        RaiseEvent(newEventArgs);
    }

    /// <summary>
    ///     Checks if the item is already the right container.
    /// </summary>
    /// <param name="item">The item added to the collection.</param>
    /// <returns>True if the items is already the correct child container; otherwise false.</returns>
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is ChapterSplitButtonItem;
    }

    /// <summary>
    ///     Returns a new child container.
    /// </summary>
    /// <returns>A new child container.</returns>
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new ChapterSplitButtonItem();
    }
}