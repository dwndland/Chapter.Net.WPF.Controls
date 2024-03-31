// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TitledItemsControl.cs" company="my-libraries">
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
    ///     Provides the possibility to automatically align titles and contents.
    /// </summary>
    public class TitledItemsControl : ItemsControl
    {
        /// <summary>
        ///     The DependencyProperty for the ViewModel VerticalTitleAlignments.
        /// </summary>
        public static readonly DependencyProperty VerticalTitleAlignmentsProperty =
            DependencyProperty.Register(nameof(VerticalTitleAlignments), typeof(VerticalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(VerticalAlignment.Center));

        /// <summary>
        ///     The DependencyProperty for the ViewModel HorizontalTitleAlignments.
        /// </summary>
        public static readonly DependencyProperty HorizontalTitleAlignmentsProperty =
            DependencyProperty.Register(nameof(HorizontalTitleAlignments), typeof(HorizontalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(HorizontalAlignment.Left));

        /// <summary>
        ///     The DependencyProperty for the ViewModel TitleMargins.
        /// </summary>
        public static readonly DependencyProperty TitleMarginsProperty =
            DependencyProperty.Register(nameof(TitleMargins), typeof(Thickness), typeof(TitledItemsControl), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

        /// <summary>
        ///     The DependencyProperty for the ViewModel HorizontalContentAlignments.
        /// </summary>
        public static readonly DependencyProperty HorizontalContentAlignmentsProperty =
            DependencyProperty.Register(nameof(HorizontalContentAlignments), typeof(HorizontalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(HorizontalAlignment.Stretch));

        /// <summary>
        ///     The DependencyProperty for the ViewModel VerticalContentAlignments.
        /// </summary>
        public static readonly DependencyProperty VerticalContentAlignmentsProperty =
            DependencyProperty.Register(nameof(VerticalContentAlignments), typeof(VerticalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(VerticalAlignment.Center));

        /// <summary>
        ///     The DependencyProperty for the ViewModel ContentMargins.
        /// </summary>
        public static readonly DependencyProperty ContentMarginsProperty =
            DependencyProperty.Register(nameof(ContentMargins), typeof(Thickness), typeof(TitledItemsControl), new UIPropertyMetadata(new Thickness(0, 2, 0, 2)));

        /// <summary>
        ///     Identifies the Orientation dependency property.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(TitledItemsControl), new PropertyMetadata(Orientation.Vertical));

        static TitledItemsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TitledItemsControl), new FrameworkPropertyMetadata(typeof(TitledItemsControl)));
        }

        /// <summary>
        ///     Gets or sets the VerticalAlignment of all titles.
        /// </summary>
        /// <remarks>Default: HorizontalAlignment.Center</remarks>
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment VerticalTitleAlignments
        {
            get => (VerticalAlignment)GetValue(VerticalTitleAlignmentsProperty);
            set => SetValue(VerticalTitleAlignmentsProperty, value);
        }

        /// <summary>
        ///     Gets or sets the HorizontalAlignment of all titles.
        /// </summary>
        /// <remarks>Default: HorizontalAlignment.Left</remarks>
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment HorizontalTitleAlignments
        {
            get => (HorizontalAlignment)GetValue(HorizontalTitleAlignmentsProperty);
            set => SetValue(HorizontalTitleAlignmentsProperty, value);
        }

        /// <summary>
        ///     Gets or sets the margin for all titles.
        /// </summary>
        /// <remarks>Default: new Thickness(5, 0, 5, 0)</remarks>
        public Thickness TitleMargins
        {
            get => (Thickness)GetValue(TitleMarginsProperty);
            set => SetValue(TitleMarginsProperty, value);
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
            return new TitledItem();
        }

        /// <summary>
        ///     Checks if the item is already the right container.
        /// </summary>
        /// <param name="item">The item added to the collection.</param>
        /// <returns>True if the items is already the correct child container; otherwise false.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TitledItem;
        }
    }
}