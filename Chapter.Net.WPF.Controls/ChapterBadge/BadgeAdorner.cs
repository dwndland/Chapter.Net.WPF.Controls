// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BadgeAdorner.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Adorns a <see cref="ChapterBadge" /> to a target control.
    /// </summary>
    public class BadgeAdorner : Adorner
    {
        private readonly ChapterBadge _badge;

        /// <summary>
        ///     Creates a new instance of BadgeAdorner.
        /// </summary>
        /// <param name="adornedElement">The target control.</param>
        /// <param name="badge">The badge.</param>
        public BadgeAdorner(FrameworkElement adornedElement, ChapterBadge badge)
            : base(adornedElement)
        {
            _badge = badge;
            AddVisualChild(_badge);

            adornedElement.SizeChanged += (s, e) => PositionBadge();
            _badge.SizeChanged += (s, e) => PositionBadge();
            _badge.PositionChanged += (s, e) => PositionBadge();
        }

        /// <inheritdoc />
        protected override int VisualChildrenCount => 1;

        /// <inheritdoc />
        protected override Size MeasureOverride(Size constraint)
        {
            _badge.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            return base.MeasureOverride(constraint);
        }

        /// <inheritdoc />
        protected override Size ArrangeOverride(Size finalSize)
        {
            _badge.Arrange(new Rect(finalSize));
            PositionBadge();
            return base.ArrangeOverride(finalSize);
        }

        /// <inheritdoc />
        protected override Visual GetVisualChild(int index)
        {
            return index != 0 ? throw new ArgumentOutOfRangeException(nameof(index)) : _badge;
        }

        private void PositionBadge()
        {
            if (_badge.ActualWidth <= 0)
                return;

            var element = (FrameworkElement)AdornedElement;

            var badgeAnchorLeftDistance = _badge.ActualWidth * _badge.HorizontalAnchorOffset;
            var badgeAnchorRightDistance = _badge.ActualWidth - badgeAnchorLeftDistance;
            var badgeAnchorTopDistance = _badge.ActualHeight * _badge.VerticalAnchorOffset;
            var badgeAnchorBottomDistance = _badge.ActualHeight - badgeAnchorTopDistance;

            var left = element.ActualWidth * _badge.HorizontalOffset - badgeAnchorLeftDistance;
            var top = element.ActualHeight * _badge.VerticalOffset - badgeAnchorTopDistance;
            var right = badgeAnchorRightDistance * -1 - element.ActualWidth - left;
            var bottom = badgeAnchorBottomDistance * -1 - element.ActualHeight - top;

            _badge.Margin = new Thickness(left, top, right, bottom);
        }
    }
}