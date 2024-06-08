// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BadgeShapePresenter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Presents the background shape of a badge.
/// </summary>
public class BadgeShapePresenter : ContentControlBase
{
    /// <summary>
    ///     The BadgeShapePresenter style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(BadgeShapePresenter), "BadgeShapePresenter");

    /// <summary>
    ///     The Shape dependency property.
    /// </summary>
    public static readonly DependencyProperty ShapeProperty =
        DependencyProperty.Register(nameof(Shape), typeof(BadgeShape), typeof(BadgeShapePresenter), new PropertyMetadata(BadgeShape.Oval));

    /// <summary>
    ///     The OvalCornerRadius dependency property.
    /// </summary>
    internal static readonly DependencyProperty OvalCornerRadiusProperty =
        DependencyProperty.Register(nameof(OvalCornerRadius), typeof(CornerRadius), typeof(BadgeShapePresenter), new PropertyMetadata(default(CornerRadius)));

    static BadgeShapePresenter()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(BadgeShapePresenter), new FrameworkPropertyMetadata(typeof(BadgeShapePresenter)));
    }

    /// <summary>
    ///     Gets or sets the shape to present.
    /// </summary>
    /// <value>Default: BadgeShape.Oval.</value>
    [DefaultValue(BadgeShape.Oval)]
    public BadgeShape Shape
    {
        get => (BadgeShape)GetValue(ShapeProperty);
        set => SetValue(ShapeProperty, value);
    }

    /// <summary>
    ///     Gets or sets the corner radius for the oval shape.
    /// </summary>
    /// <value>Default: default.</value>
    internal CornerRadius OvalCornerRadius
    {
        get => (CornerRadius)GetValue(OvalCornerRadiusProperty);
        set => SetValue(OvalCornerRadiusProperty, value);
    }
}