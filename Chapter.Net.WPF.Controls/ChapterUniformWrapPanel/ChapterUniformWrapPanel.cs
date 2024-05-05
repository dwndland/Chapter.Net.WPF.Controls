// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterUniformWrapPanel.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Enhances the <see cref="WrapPanel" /> by the feature that all items will have the same size.
    /// </summary>
    public class ChapterUniformWrapPanel : WrapPanel
    {
        /// <summary>
        ///     Identifies the <see cref="IsAutoUniform" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsAutoUniformProperty =
            DependencyProperty.Register(nameof(IsAutoUniform), typeof(bool), typeof(ChapterUniformWrapPanel), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        ///     Identifies the <see cref="MinItemWidth" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MinItemWidthProperty =
            DependencyProperty.Register(nameof(MinItemWidth), typeof(double), typeof(ChapterUniformWrapPanel), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        ///     Identifies the <see cref="MinItemHeight" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MinItemHeightProperty =
            DependencyProperty.Register(nameof(MinItemHeight), typeof(double), typeof(ChapterUniformWrapPanel), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        ///     Gets or sets a value that defines if the common height or width will be taken by the biggest child element.
        /// </summary>
        /// <value>Default: true.</value>
        [DefaultValue(true)]
        public bool IsAutoUniform
        {
            get => (bool)GetValue(IsAutoUniformProperty);
            set => SetValue(IsAutoUniformProperty, value);
        }

        /// <summary>
        ///     Gets or sets the minimum width of the items.
        /// </summary>
        /// <value>Default: 0.</value>
        [DefaultValue(0d)]
        public double MinItemWidth
        {
            get => (double)GetValue(MinItemWidthProperty);
            set => SetValue(MinItemWidthProperty, value);
        }

        /// <summary>
        ///     Gets or sets the minimum height of the items.
        /// </summary>
        /// <value>Default: 0.</value>
        [DefaultValue(0d)]
        public double MinItemHeight
        {
            get => (double)GetValue(MinItemHeightProperty);
            set => SetValue(MinItemHeightProperty, value);
        }

        /// <summary>
        ///     Lets each child calculating is needed size.
        /// </summary>
        /// <param name="availableSize">The available space by the parent control.</param>
        /// <returns>The calculated size needed for the control.</returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            if (IsAutoUniform)
            {
                if (Orientation == Orientation.Vertical)
                {
                    var itemHeight = 0d;
                    foreach (UIElement el in Children)
                        itemHeight = MeasureItem(itemHeight, el.DesiredSize.Height, MinItemHeight);
                    ItemHeight = itemHeight;
                }
                else
                {
                    var itemWidth = 0d;
                    foreach (UIElement el in Children)
                        itemWidth = MeasureItem(itemWidth, el.DesiredSize.Width, MinItemWidth);
                    ItemWidth = itemWidth;
                }
            }
            else
            {
                ItemHeight = double.NaN;
                ItemWidth = double.NaN;
            }

            return base.MeasureOverride(availableSize);
        }

        private double MeasureItem(double finalItemSize, double currentItemSize, double minimumSize)
        {
            if (double.IsNaN(finalItemSize))
                finalItemSize = 0;

            if (double.IsInfinity(currentItemSize) || double.IsNaN(currentItemSize))
                return finalItemSize;

            finalItemSize = Math.Max(finalItemSize, currentItemSize);
            return Math.Max(finalItemSize, minimumSize);
        }
    }
}