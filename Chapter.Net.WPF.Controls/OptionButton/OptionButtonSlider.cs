// -----------------------------------------------------------------------------------------------------------------
// <copyright file="OptionButtonSlider.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     The slider shown in the <see cref="OptionButton" />.
/// </summary>
public class OptionButtonSlider : Control
{
    /// <summary>
    ///     The DependencyProperty for the Shape property.
    /// </summary>
    public static readonly DependencyProperty ShapeProperty =
        DependencyProperty.Register(nameof(Shape), typeof(OptionButtonShape), typeof(OptionButtonSlider), new PropertyMetadata(OptionButtonShape.Round));

    static OptionButtonSlider()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(OptionButtonSlider), new FrameworkPropertyMetadata(typeof(OptionButtonSlider)));
    }

    /// <summary>
    ///     Gets or sets the shape of the slider.
    /// </summary>
    /// <value>Default: OptionButtonShape.Round.</value>
    [DefaultValue(OptionButtonShape.Round)]
    public OptionButtonShape Shape
    {
        get => (OptionButtonShape)GetValue(ShapeProperty);
        set => SetValue(ShapeProperty, value);
    }
}