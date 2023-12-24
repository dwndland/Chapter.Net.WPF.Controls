// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CloseButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents the close Button shown in the <see cref="DynamicTabControl" />.
/// </summary>
public class CloseButton : Button
{
    /// <summary>
    ///     Identifies the <see cref="StrokeThickness" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty StrokeThicknessProperty =
        DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(CloseButton), new UIPropertyMetadata(1.5));

    static CloseButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CloseButton), new FrameworkPropertyMetadata(typeof(CloseButton)));
    }

    /// <summary>
    ///     Gets or sets the stroke thickness of the X in the template.
    /// </summary>
    /// <value>Default: 1.5.</value>
    [DefaultValue(1.5)]
    public double StrokeThickness
    {
        get => (double)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }
}