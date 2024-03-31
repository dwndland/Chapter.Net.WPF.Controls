// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EllipsePanel.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Arranges child elements in a configurable ellipse form.
    /// </summary>
    public class EllipsePanel : Panel
    {
        /// <summary>
        ///     Identifies the RotateElements dependency property.
        /// </summary>
        public static readonly DependencyProperty RotateElementsProperty =
            DependencyProperty.Register(nameof(RotateElements), typeof(bool), typeof(EllipsePanel), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsArrange));

        /// <summary>
        ///     Identifies the ElementsRotateDirection dependency property.
        /// </summary>
        public static readonly DependencyProperty ElementsRotateDirectionProperty =
            DependencyProperty.Register(nameof(ElementsRotateDirection), typeof(ElementsRotateDirection), typeof(EllipsePanel), new FrameworkPropertyMetadata(ElementsRotateDirection.Introversive, FrameworkPropertyMetadataOptions.AffectsArrange));

        /// <summary>
        ///     Identifies the EllipseRotateDirection dependency property.
        /// </summary>
        public static readonly DependencyProperty EllipseRotateDirectionProperty =
            DependencyProperty.Register(nameof(EllipseRotateDirection), typeof(SweepDirection), typeof(EllipsePanel), new FrameworkPropertyMetadata(SweepDirection.Clockwise, FrameworkPropertyMetadataOptions.AffectsArrange));

        /// <summary>
        ///     Identifies the ElementStartPosition dependency property.
        /// </summary>
        public static readonly DependencyProperty ElementStartPositionProperty =
            DependencyProperty.Register(nameof(ElementStartPosition), typeof(ElementStartPosition), typeof(EllipsePanel), new FrameworkPropertyMetadata(ElementStartPosition.Top, FrameworkPropertyMetadataOptions.AffectsArrange));

        private readonly EllipseGeometry _ellipse = new EllipseGeometry();

        /// <summary>
        ///     Gets or sets the indicator if the elements shall be rotated or not.
        /// </summary>
        /// <value>Default: false.</value>
        [DefaultValue(false)]
        public bool RotateElements
        {
            get => (bool)GetValue(RotateElementsProperty);
            set => SetValue(RotateElementsProperty, value);
        }

        /// <summary>
        ///     Gets or sets the value how to rotate the elements if <see cref="RotateElements" /> is true.
        /// </summary>
        /// <value>Default: ElementsRotateDirection.Introversive.</value>
        [DefaultValue(ElementsRotateDirection.Introversive)]
        public ElementsRotateDirection ElementsRotateDirection
        {
            get => (ElementsRotateDirection)GetValue(ElementsRotateDirectionProperty);
            set => SetValue(ElementsRotateDirectionProperty, value);
        }

        /// <summary>
        ///     Gets or sets the direction the elements shall be placed on the ellipse.
        /// </summary>
        /// <value>Default: SweepDirection.Clockwise.</value>
        [DefaultValue(SweepDirection.Clockwise)]
        public SweepDirection EllipseRotateDirection
        {
            get => (SweepDirection)GetValue(EllipseRotateDirectionProperty);
            set => SetValue(EllipseRotateDirectionProperty, value);
        }

        /// <summary>
        ///     Gets or sets the position where the first element shall start on the ellipse.
        /// </summary>
        /// <value>Default: ElementStartPosition.Top.</value>
        [DefaultValue(ElementStartPosition.Top)]
        public ElementStartPosition ElementStartPosition
        {
            get => (ElementStartPosition)GetValue(ElementStartPositionProperty);
            set => SetValue(ElementStartPositionProperty, value);
        }

        /// <summary>
        ///     Lets each child calculating is needed size.
        /// </summary>
        /// <param name="availableSize">The available space by the parent control.</param>
        /// <remarks>Since the EllipsePanel always only consumes the full space it gets, the returned value is always 0,0.</remarks>
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
        ///     Since the EllipsePanel always only consumes the full space it gets, the returned value is always the maximum
        ///     available by the parent.
        /// </remarks>
        /// <returns>The calculated needed space in sum of all available child controls.</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (InternalChildren.Count <= 0 || finalSize.Width <= 0 || finalSize.Height <= 0)
                return base.ArrangeOverride(finalSize);

            ResetEllipse(finalSize);

            var figure = _ellipse.GetOutlinedPathGeometry().Figures[0];
            var pathGeometry = new PathGeometry(new[] { figure });

            var points = new List<Point>();
            var tangents = new List<Point>();
            var distance = 1 / (double)InternalChildren.Count;
            var position = GetElementStartPositionValue();
            foreach (var _ in InternalChildren)
            {
                pathGeometry.GetPointAtFractionLength(position, out var point, out var tangent);
                points.Add(point);
                tangents.Add(tangent);
                position += distance;
                if (position > 1)
                    position -= 1;
            }

            if (EllipseRotateDirection == SweepDirection.Counterclockwise)
            {
                points.Reverse();
                tangents.Reverse();
                var point = points.Last();
                points.Remove(point);
                points.Insert(0, point);

                var tangent = tangents.Last();
                tangents.Remove(tangent);
                tangents.Insert(0, tangent);
            }

            var pos = 0;
            foreach (UIElement child in InternalChildren)
            {
                var childSize = child.DesiredSize;
                var elementPos = points[pos];
                elementPos.X -= childSize.Width / 2;
                elementPos.Y -= childSize.Height / 2;
                child.SnapsToDevicePixels = true;
                child.Arrange(new Rect(elementPos, childSize));
                if (RotateElements)
                {
                    var elementCenter = new Size(childSize.Width / 2, childSize.Height / 2);
                    var transforms = new TransformGroup();
                    transforms.Children.Add(new RotateTransform(Math.Atan2(tangents[pos].Y, tangents[pos].X) * 180 / Math.PI + GetElementsRotateDirectionValue(), elementCenter.Width, elementCenter.Height));
                    child.RenderTransform = transforms;
                }
                else
                {
                    child.RenderTransform = null;
                }

                ++pos;
            }

            return base.ArrangeOverride(finalSize);
        }

        private double GetElementStartPositionValue()
        {
            switch (ElementStartPosition)
            {
                case ElementStartPosition.Left:
                    return 0.75;
                case ElementStartPosition.Top:
                    return 0;
                case ElementStartPosition.Right:
                    return 0.25;
                case ElementStartPosition.Bottom:
                    return 0.5;
                default:
                    return 0;
            }
        }

        private double GetElementsRotateDirectionValue()
        {
            switch (ElementsRotateDirection)
            {
                case ElementsRotateDirection.Introversive:
                    return 0;
                case ElementsRotateDirection.Outroversive:
                    return 180;
                case ElementsRotateDirection.Clockwise:
                    return 90;
                case ElementsRotateDirection.Counterclockwise:
                    return -90;
                default:
                    return 0;
            }
        }

        private void ResetEllipse(Size finalSize)
        {
            _ellipse.RadiusX = finalSize.Width / 2;
            _ellipse.RadiusY = finalSize.Height / 2;
            _ellipse.Center = new Point(finalSize.Width / 2, finalSize.Height / 2);
        }
    }
}