// -----------------------------------------------------------------------------------------------------------------
// <copyright file="HeaderItemsControl.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Provides the possibility to automatically align Headers and contents.
    /// </summary>
    public class HeaderItemsControl : ItemsControl
    {
        /// <summary>
        ///     Identifies the HorizontalHeaderAlignments dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalHeaderAlignmentsProperty =
            DependencyProperty.Register(nameof(HorizontalHeaderAlignments), typeof(HorizontalAlignment), typeof(HeaderItemsControl), new UIPropertyMetadata(HorizontalAlignment.Left));

        /// <summary>
        ///     Identifies the HeaderMargins dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderMarginsProperty =
            DependencyProperty.Register(nameof(HeaderMargins), typeof(Thickness), typeof(HeaderItemsControl), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

        /// <summary>
        ///     Identifies the HorizontalContentAlignments dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalContentAlignmentsProperty =
            DependencyProperty.Register(nameof(HorizontalContentAlignments), typeof(HorizontalAlignment), typeof(HeaderItemsControl), new UIPropertyMetadata(HorizontalAlignment.Stretch));

        /// <summary>
        ///     Identifies the VerticalContentAlignments dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalContentAlignmentsProperty =
            DependencyProperty.Register(nameof(VerticalContentAlignments), typeof(VerticalAlignment), typeof(HeaderItemsControl), new UIPropertyMetadata(VerticalAlignment.Center));

        /// <summary>
        ///     Identifies the ContentMargins dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentMarginsProperty =
            DependencyProperty.Register(nameof(ContentMargins), typeof(Thickness), typeof(HeaderItemsControl), new UIPropertyMetadata(new Thickness(0, 2, 0, 2)));

        /// <summary>
        ///     Identifies the Orientation dependency property.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(HeaderItemsControl), new PropertyMetadata(Orientation.Vertical));

        static HeaderItemsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HeaderItemsControl), new FrameworkPropertyMetadata(typeof(HeaderItemsControl)));
        }

        /// <summary>
        ///     Gets or sets the HorizontalAlignment of all Headers.
        /// </summary>
        /// <remarks>Default: HorizontalAlignment.Left</remarks>
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment HorizontalHeaderAlignments
        {
            get => (HorizontalAlignment)GetValue(HorizontalHeaderAlignmentsProperty);
            set => SetValue(HorizontalHeaderAlignmentsProperty, value);
        }

        /// <summary>
        ///     Gets or sets the margin for all Headers.
        /// </summary>
        /// <remarks>Default: new Thickness(5, 0, 5, 0)</remarks>
        public Thickness HeaderMargins
        {
            get => (Thickness)GetValue(HeaderMarginsProperty);
            set => SetValue(HeaderMarginsProperty, value);
        }

        /// <summary>
        ///     Gets or sets the HorizontalAlignment for all contents.
        /// </summary>
        /// <remarks>Default: HorizontalAlignment.Stretch</remarks>
        [DefaultValue(HorizontalAlignment.Stretch)]
        public HorizontalAlignment HorizontalContentAlignments
        {
            get => (HorizontalAlignment)GetValue(HorizontalContentAlignmentsProperty);
            set => SetValue(HorizontalContentAlignmentsProperty, value);
        }

        /// <summary>
        ///     Gets or sets the VerticalAlignment for all contents.
        /// </summary>
        /// <remarks>Default: VerticalAlignment.Center</remarks>
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment VerticalContentAlignments
        {
            get => (VerticalAlignment)GetValue(VerticalContentAlignmentsProperty);
            set => SetValue(VerticalContentAlignmentsProperty, value);
        }

        /// <summary>
        ///     Gets or sets the margin of all contents.
        /// </summary>
        /// <remarks>Default: new Thickness(0, 2, 0, 2)</remarks>
        public Thickness ContentMargins
        {
            get => (Thickness)GetValue(ContentMarginsProperty);
            set => SetValue(ContentMarginsProperty, value);
        }

        /// <summary>
        ///     Gets or sets the orientation how the items shall be aligned.
        /// </summary>
        /// <remarks>Default: Orientation.Vertical.</remarks>
        [DefaultValue(Orientation.Vertical)]
        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        /// <summary>
        ///     Returns a new child container.
        /// </summary>
        /// <returns>A new child container.</returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new HeaderItem();
        }

        /// <summary>
        ///     Checks if the item is already the right container.
        /// </summary>
        /// <param name="item">The item added to the collection.</param>
        /// <returns>True if the items is already the correct child container; otherwise false.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is HeaderItem;
        }
    }
}