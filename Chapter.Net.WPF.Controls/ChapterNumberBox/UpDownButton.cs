// -----------------------------------------------------------------------------------------------------------------
// <copyright file="UpDownButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents an up or down button shown in the <see cref="ChapterNumberBox" /> control.
/// </summary>
public class UpDownButton : RepeatButtonBase
{
    /// <summary>
    ///     Identifies the <see cref="UpDownButton.Direction" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty DirectionProperty =
        DependencyProperty.Register(nameof(Direction), typeof(UpDownDirections), typeof(UpDownButton), new UIPropertyMetadata(UpDownDirections.Up));

    static UpDownButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(UpDownButton), new FrameworkPropertyMetadata(typeof(UpDownButton)));
    }

    /// <summary>
    ///     Gets or sets a value which indicates in which direction the button is pointing to.
    /// </summary>
    /// <value>Default: UpDownDirections.Up.</value>
    [DefaultValue(UpDownDirections.Up)]
    public UpDownDirections Direction
    {
        get => (UpDownDirections)GetValue(DirectionProperty);
        set => SetValue(DirectionProperty, value);
    }
}