// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterUniformPanel.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A UniformGrid with only one row or one column, depending on the orientation, which adds a spacing between the
///     items.
/// </summary>
public class ChapterUniformPanel : PanelBase
{
    /// <summary>
    ///     Identifies the Spacing dependency property.
    /// </summary>
    public static readonly DependencyProperty SpacingProperty =
        DependencyProperty.Register(nameof(Spacing), typeof(double), typeof(ChapterUniformPanel), new FrameworkPropertyMetadata(4.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

    /// <summary>
    ///     Identifies the Orientation dependency property.
    /// </summary>
    public static readonly DependencyProperty OrientationProperty =
        DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(ChapterUniformPanel), new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsMeasure));

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
    ///     Calculates the size this panel would like to get from the parent control.
    /// </summary>
    /// <param name="availableSize">The available size from the parent control.</param>
    /// <returns>The size this panel would like to get from the parent control.</returns>
    protected override Size MeasureOverride(Size availableSize)
    {
        return Measure(availableSize, Children, Spacing, Orientation, HorizontalAlignment, VerticalAlignment, DockPanel.GetDock(this));
    }

    /// <summary>
    ///     Arranges all the children in the given space by the parent control.
    /// </summary>
    /// <param name="finalSize">The available size give from the parent control.</param>
    /// <returns></returns>
    protected override Size ArrangeOverride(Size finalSize)
    {
        return Arrange(finalSize, Children, Spacing, Orientation);
    }

    internal static Size Measure(Size availableSize, UIElementCollection children, double spacing, Orientation orientation, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment, Dock dock)
    {
        var elements = children.Cast<UIElement>().Where(x => x.Visibility != Visibility.Collapsed).ToList();
        var totalSpacing = spacing * (elements.Count - 1);

        if (orientation == Orientation.Vertical)
        {
            var itemWidth = availableSize.Width;
            var maxItemHeight = (availableSize.Height - totalSpacing) / elements.Count;
            if (maxItemHeight < 0)
                maxItemHeight = 0;
            var maxItemSize = new Size(itemWidth, maxItemHeight);
            var measuredMaxItemHeight = 0d;
            var measuredMaxItemWidth = 0d;
            foreach (var child in elements)
            {
                child.Measure(maxItemSize);
                measuredMaxItemHeight = Math.Max(measuredMaxItemHeight, child.DesiredSize.Height);
                measuredMaxItemWidth = Math.Max(measuredMaxItemWidth, child.DesiredSize.Width);
            }

            if (horizontalAlignment != HorizontalAlignment.Stretch || dock == Dock.Left || dock == Dock.Right)
                itemWidth = Math.Min(itemWidth, measuredMaxItemWidth);

            if (double.IsInfinity(itemWidth))
                itemWidth = measuredMaxItemWidth;

            if (double.IsInfinity(maxItemHeight))
                maxItemHeight = measuredMaxItemHeight;

            if (verticalAlignment == VerticalAlignment.Stretch && dock != Dock.Top && dock != Dock.Bottom)
                return new Size(itemWidth, maxItemHeight * elements.Count + totalSpacing);
            return new Size(itemWidth, Math.Min(maxItemHeight, measuredMaxItemHeight) * elements.Count + totalSpacing);
        }
        else
        {
            var itemHeight = availableSize.Height;
            var maxItemWidth = (availableSize.Width - totalSpacing) / elements.Count;
            if (maxItemWidth < 0)
                maxItemWidth = 0;
            var maxItemSize = new Size(maxItemWidth, itemHeight);
            var measuredMaxItemHeight = 0d;
            var measuredMaxItemWidth = 0d;
            foreach (var child in elements)
            {
                child.Measure(maxItemSize);
                measuredMaxItemHeight = Math.Max(measuredMaxItemHeight, child.DesiredSize.Height);
                measuredMaxItemWidth = Math.Max(measuredMaxItemWidth, child.DesiredSize.Width);
            }

            if (verticalAlignment != VerticalAlignment.Stretch || dock == Dock.Top || dock == Dock.Bottom)
                itemHeight = Math.Min(itemHeight, measuredMaxItemHeight);

            if (double.IsInfinity(itemHeight))
                itemHeight = measuredMaxItemHeight;

            if (double.IsInfinity(maxItemWidth))
                maxItemWidth = measuredMaxItemWidth;

            if (horizontalAlignment == HorizontalAlignment.Stretch && dock != Dock.Left && dock != Dock.Right)
                return new Size(maxItemWidth * elements.Count + totalSpacing, itemHeight);
            return new Size(Math.Min(maxItemWidth, measuredMaxItemWidth) * elements.Count + totalSpacing, itemHeight);
        }
    }

    internal static Size Arrange(Size finalSize, UIElementCollection children, double spacing, Orientation orientation)
    {
        var elements = children.Cast<UIElement>().Where(x => x.Visibility != Visibility.Collapsed).ToList();
        var spaces = spacing * (elements.Count - 1);
        var itemHeight = finalSize.Height;
        var itemWidth = finalSize.Width;

        var left = 0d;
        var top = 0d;

        if (orientation == Orientation.Horizontal)
        {
            itemWidth = (finalSize.Width - spaces) / elements.Count;
            foreach (var child in elements)
            {
                child.Arrange(new Rect(new Point(left, top), new Size(itemWidth, itemHeight)));
                left += itemWidth + spacing;
            }
        }
        else
        {
            itemHeight = (finalSize.Height - spaces) / elements.Count;
            foreach (var child in elements)
            {
                child.Arrange(new Rect(new Point(left, top), new Size(itemWidth, itemHeight)));
                top += itemHeight + spacing;
            }
        }

        return finalSize;
    }
}