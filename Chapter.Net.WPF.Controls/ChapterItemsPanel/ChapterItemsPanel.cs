﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterItemsPanel.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A UniformGrid with only one row or one column, depending on the orientation, which adds a spacing between the
///     items.
/// </summary>
public class ChapterItemsPanel : PanelBase
{
    /// <summary>
    ///     Identifies the Spacing dependency property.
    /// </summary>
    public static readonly DependencyProperty SpacingProperty =
        DependencyProperty.Register(nameof(Spacing), typeof(double), typeof(ChapterItemsPanel), new FrameworkPropertyMetadata(4.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

    /// <summary>
    ///     Identifies the Orientation dependency property.
    /// </summary>
    public static readonly DependencyProperty OrientationProperty =
        DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(ChapterItemsPanel), new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsMeasure));

    /// <summary>
    ///     Identifies the IsUniform dependency property.
    /// </summary>
    public static readonly DependencyProperty IsUniformProperty =
        DependencyProperty.Register(nameof(IsUniform), typeof(bool), typeof(ChapterItemsPanel), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure));

    /// <summary>
    ///     Gets or sets the space between the items.
    /// </summary>
    /// <value>Default: 4d.</value>
    [DefaultValue(4d)]
    public double Spacing
    {
        get => (double)GetValue(SpacingProperty);
        set => SetValue(SpacingProperty, value);
    }

    /// <summary>
    ///     Gets or sets the orientation of the panel.
    /// </summary>
    /// <value>Default: Orientation.Horizontal.</value>
    [DefaultValue(Orientation.Horizontal)]
    public Orientation Orientation
    {
        get => (Orientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    /// <summary>
    ///     Gets or sets the indicator if the ItemsPanel shall behave like a <see cref="ChapterUniformPanel" /> or a
    ///     <see cref="ChapterStackPanel" />.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool IsUniform
    {
        get => (bool)GetValue(IsUniformProperty);
        set => SetValue(IsUniformProperty, value);
    }

    /// <summary>
    ///     Calculates the size this panel would like to get from the parent control.
    /// </summary>
    /// <param name="availableSize">The available size from the parent control.</param>
    /// <returns>The size this panel would like to get from the parent control.</returns>
    protected override Size MeasureOverride(Size availableSize)
    {
        if (IsUniform)
            return ChapterUniformPanel.Measure(availableSize, Children, Spacing, Orientation, HorizontalAlignment, VerticalAlignment, DockPanel.GetDock(this));
        return ChapterStackPanel.Measure(availableSize, Children, Spacing, Orientation, HorizontalAlignment, VerticalAlignment);
    }

    /// <summary>
    ///     Arranges all the children in the given space by the parent control.
    /// </summary>
    /// <param name="finalSize">The available size give from the parent control.</param>
    /// <returns></returns>
    protected override Size ArrangeOverride(Size finalSize)
    {
        if (IsUniform)
            return ChapterUniformPanel.Arrange(finalSize, Children, Spacing, Orientation);
        return ChapterStackPanel.Arrange(finalSize, Children, Spacing, Orientation);
    }
}