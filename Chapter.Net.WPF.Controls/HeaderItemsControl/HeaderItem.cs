// -----------------------------------------------------------------------------------------------------------------
// <copyright file="HeaderItem.cs" company="my-libraries">
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
    ///     Represents a single line in the <see cref="HeaderItemsControl" />.
    /// </summary>
    public class HeaderItem : ContentControl
    {
        /// <summary>
        ///     Identifies the Header dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(object), typeof(HeaderItem), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the HorizontalHeaderAlignment dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalHeaderAlignmentProperty =
            DependencyProperty.Register(nameof(HorizontalHeaderAlignment), typeof(HorizontalAlignment), typeof(HeaderItem), new UIPropertyMetadata(HorizontalAlignment.Left));

        /// <summary>
        ///     Identifies the HeaderMargin dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderMarginProperty =
            DependencyProperty.Register(nameof(HeaderMargin), typeof(Thickness), typeof(HeaderItem), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

        /// <summary>
        ///     Identifies the ContentMargin dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register(nameof(ContentMargin), typeof(Thickness), typeof(HeaderItem), new UIPropertyMetadata(new Thickness(0, 2, 0, 2)));

        static HeaderItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HeaderItem), new FrameworkPropertyMetadata(typeof(HeaderItem)));
        }

        /// <summary>
        ///     Gets or sets the Header.
        /// </summary>
        /// <remarks>Default: null</remarks>
        [DefaultValue(null)]
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        ///     Gets or sets the HorizontalAlignment of the Header.
        /// </summary>
        /// <remarks>Default: HorizontalAlignment.Left</remarks>
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment HorizontalHeaderAlignment
        {
            get => (HorizontalAlignment)GetValue(HorizontalHeaderAlignmentProperty);
            set => SetValue(HorizontalHeaderAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the margin of the Header.
        /// </summary>
        /// <remarks>Default: new Thickness(5, 0, 5, 0)</remarks>
        public Thickness HeaderMargin
        {
            get => (Thickness)GetValue(HeaderMarginProperty);
            set => SetValue(HeaderMarginProperty, value);
        }

        /// <summary>
        ///     Gets or sets the margin of the content.
        /// </summary>
        /// <remarks>Default: new Thickness(0, 2, 0, 2)</remarks>
        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }
    }
}