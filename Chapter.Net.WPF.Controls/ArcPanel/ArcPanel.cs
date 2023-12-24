// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ArcPanel.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Arranges child elements in an arc form.
/// </summary>
public class ArcPanel : Panel
{
    /// <summary>
    ///     Identifies the RotateElements dependency property.
    /// </summary>
    public static readonly DependencyProperty RotateElementsProperty =
        DependencyProperty.Register(nameof(RotateElements), typeof(bool), typeof(ArcPanel), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsArrange));

    private readonly PathFigure _figure;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArcPanel" /> class.
    /// </summary>
    public ArcPanel()
    {
        _figure = new PathFigure
        {
            StartPoint = new Point(0, 100)
        };

        _figure.Segments.Add(new ArcSegment(new Point(400, 100), new Size(200, 100), 0, false, SweepDirection.Clockwise, false));
    }

    /// <summary>
    ///     Gets or sets a value that defines if the child elements has to be rotated by the arc line.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool RotateElements
    {
        get => (bool)GetValue(RotateElementsProperty);
        set => SetValue(RotateElementsProperty, value);
    }

    /// <summary>
    ///     Lets each child calculating is needed size.
    /// </summary>
    /// <param name="availableSize">The available space by the parent control.</param>
    /// <remarks>Since the ArcPanel always only consumes the full space it gets, the returned value is always 0,0.</remarks>
    /// <returns>The calculated minimum size needed for the control.</returns>
    protected override Size MeasureOverride(Size availableSize)
    {
        foreach (UIElement child in InternalChildren)
            child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        return base.MeasureOverride(availableSize);
    }

    /// <summary>
    ///     Positions each child in an arc line form.
    /// </summary>
    /// <param name="finalSize">The maximum possible space given by the parent control.</param>
    /// <remarks>
    ///     Since the ArcPanel always only consumes the full space it gets, the returned value is always the maximum
    ///     available by the parent.
    /// </remarks>
    /// <returns>The calculated needed space in sum of all available child controls.</returns>
    protected override Size ArrangeOverride(Size finalSize)
    {
        if (InternalChildren.Count <= 0 || finalSize.Width <= 0)
            return base.ArrangeOverride(finalSize);

        ResetArc(finalSize);

        var pathGeometry = new PathGeometry(new[] { _figure });
        var distance = 1 / (double)(InternalChildren.Count + 1);
        var position = distance;
        foreach (UIElement child in InternalChildren)
        {
            pathGeometry.GetPointAtFractionLength(position, out var point, out var tangent);

            var childSize = child.DesiredSize;
            point.X -= childSize.Width / 2;
            child.Arrange(new Rect(point, childSize));

            if (RotateElements)
            {
                var elementCenter = new Size(childSize.Width / 2, childSize.Height / 2);
                var transforms = new TransformGroup();
                transforms.Children.Add(new RotateTransform(Math.Atan2(tangent.Y, tangent.X) * 180 / Math.PI, elementCenter.Width, elementCenter.Height));
                child.RenderTransform = transforms;
            }
            else
            {
                child.RenderTransform = null;
            }

            position += distance;
        }

        return base.ArrangeOverride(finalSize);
    }

    private void ResetArc(Size finalSize)
    {
        var segment = (ArcSegment)_figure.Segments[0];
        _figure.StartPoint = new Point(0, finalSize.Height);
        segment.Point = new Point(finalSize.Width, finalSize.Height);
        segment.Size = new Size(finalSize.Width / 2, finalSize.Height);
    }
}