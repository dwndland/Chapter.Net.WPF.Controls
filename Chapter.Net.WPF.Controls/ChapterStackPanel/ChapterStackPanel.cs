// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterStackPanel.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A StackPanel which adds a spacing between the items.
/// </summary>
public class ChapterStackPanel : Panel
{
    /// <summary>
    ///     Identifies the Spacing dependency property.
    /// </summary>
    public static readonly DependencyProperty SpacingProperty =
        DependencyProperty.Register(nameof(Spacing), typeof(double), typeof(ChapterStackPanel), new FrameworkPropertyMetadata(4.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

    /// <summary>
    ///     Identifies the Orientation dependency property.
    /// </summary>
    public static readonly DependencyProperty OrientationProperty =
        DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(ChapterStackPanel), new FrameworkPropertyMetadata(Orientation.Vertical, FrameworkPropertyMetadataOptions.AffectsMeasure));

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
    /// <value>Default: Orientation.Vertical.</value>
    [DefaultValue(Orientation.Vertical)]
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
        return Measure(availableSize, Children, Spacing, Orientation, HorizontalAlignment, VerticalAlignment);
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

    internal static Size Measure(Size availableSize, UIElementCollection children, double spacing, Orientation orientation, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment)
    {
        var elements = children.Cast<UIElement>().Where(x => x.Visibility != Visibility.Collapsed).ToList();

        var maxWidth = 0d;
        var maxHeight = 0d;
        var totalItemWidth = 0d;
        var totalItemHeight = 0d;
        foreach (var child in elements)
        {
            var newAvailableSize = new Size(availableSize.Width, double.PositiveInfinity);
            if (orientation == Orientation.Horizontal)
                newAvailableSize = new Size(double.PositiveInfinity, availableSize.Height);

            child.Measure(newAvailableSize);
            maxWidth = Math.Max(maxWidth, child.DesiredSize.Width);
            maxHeight = Math.Max(maxHeight, child.DesiredSize.Height);

            totalItemWidth += child.DesiredSize.Width;
            totalItemHeight += child.DesiredSize.Height;
        }

        if (orientation == Orientation.Horizontal)
        {
            var calculatedWidth = Math.Max(totalItemWidth + spacing * (elements.Count - 1), 0);
            var availableWidth = double.IsInfinity(availableSize.Width) ? calculatedWidth : availableSize.Width;
            if (horizontalAlignment != HorizontalAlignment.Stretch)
                availableWidth = Math.Min(availableWidth, calculatedWidth);
            return new Size(Math.Min(availableWidth, calculatedWidth), maxHeight);
        }

        var calculatedHeight = Math.Max(totalItemHeight + spacing * (elements.Count - 1), 0);
        var availableHeight = double.IsInfinity(availableSize.Height) ? calculatedHeight : availableSize.Height;
        if (verticalAlignment != VerticalAlignment.Stretch)
            availableHeight = Math.Min(availableHeight, calculatedHeight);
        return new Size(maxWidth, Math.Min(availableHeight, calculatedHeight));
    }

    internal static Size Arrange(Size finalSize, UIElementCollection children, double spacing, Orientation orientation)
    {
        var elements = children.Cast<UIElement>().Where(x => x.Visibility != Visibility.Collapsed).ToList();

        var left = 0d;
        var top = 0d;

        if (orientation == Orientation.Horizontal)
            foreach (var child in elements)
            {
                var desiredSize = child.DesiredSize;
                child.Arrange(new Rect(new Point(left, top), new Size(desiredSize.Width, finalSize.Height)));
                left += desiredSize.Width + spacing;
            }
        else
            foreach (var child in elements)
            {
                var desiredSize = child.DesiredSize;
                child.Arrange(new Rect(new Point(left, top), new Size(finalSize.Width, desiredSize.Height)));
                top += desiredSize.Height + spacing;
            }

        return finalSize;
    }
}