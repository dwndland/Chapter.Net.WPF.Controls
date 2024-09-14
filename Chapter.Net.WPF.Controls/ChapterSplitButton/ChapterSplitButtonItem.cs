// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterSplitButtonItem.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A single command entry in the <see cref="ChapterSplitButton" />.
/// </summary>
public class ChapterSplitButtonItem : ComboBoxItemBase
{
    /// <summary>
    ///     The ChapterSplitButtonItem style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterSplitButtonItem), "ChapterSplitButtonItem");

    /// <summary>
    ///     The DependencyProperty for the Command property.
    /// </summary>
    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ChapterSplitButtonItem), new PropertyMetadata(null));

    /// <summary>
    ///     The DependencyProperty for the CommandParameter property.
    /// </summary>
    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(ChapterSplitButtonItem), new PropertyMetadata(null));

    /// <summary>
    ///     The RoutedEvent for the Click event.
    /// </summary>
    public static readonly RoutedEvent ClickEvent =
        EventManager.RegisterRoutedEvent(nameof(Click), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChapterSplitButtonItem));

    static ChapterSplitButtonItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterSplitButtonItem), new FrameworkPropertyMetadata(typeof(ChapterSplitButtonItem)));
    }

    /// <summary>
    ///     Creates a new instance of the <see cref="ChapterSplitButtonItem" /> object.
    /// </summary>
    public ChapterSplitButtonItem()
    {
        KeyDown += OnKeyDown;
        PreviewMouseLeftButtonUp += OnPreviewMouseLeftButtonUp;
    }

    /// <summary>
    ///     Gets or sets the command of the button item.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    /// <summary>
    ///     Gets or sets the command parameter of the button item.
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

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Return || e.Key == Key.Enter)
            RaiseClick();
    }

    private void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        RaiseClick();
    }

    private void RaiseClick()
    {
        var newEventArgs = new RoutedEventArgs(ClickEvent, this);
        RaiseEvent(newEventArgs);

        if (Command != null && Command.CanExecute(CommandParameter))
            Command.Execute(CommandParameter);
    }
}