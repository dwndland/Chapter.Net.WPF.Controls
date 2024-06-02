// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterSelectorBarItem.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using Chapter.Net.WPF.Controls.Bases;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     A single entry within the <see cref="ChapterSelectorBar" />.
    /// </summary>
    public class ChapterSelectorBarItem : ListBoxItemBase
    {
        /// <summary>
        ///     The ChapterSelectorBarItem style key.
        /// </summary>
        public static readonly ComponentResourceKey StyleKey = new ComponentResourceKey(typeof(ChapterSelectorBarItem), "ChapterSelectorBarItem");

        /// <summary>
        ///     The Icon dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(object), typeof(ChapterSelectorBarItem), new PropertyMetadata(null));

        /// <summary>
        ///     The IconPosition dependency property.
        /// </summary>
        public static readonly DependencyProperty IconPositionProperty =
            DependencyProperty.Register(nameof(IconPosition), typeof(Dock), typeof(ChapterSelectorBarItem), new PropertyMetadata(Dock.Left));

        /// <summary>
        ///     The HorizontalIconAlignment dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalIconAlignmentProperty =
            DependencyProperty.Register(nameof(HorizontalIconAlignment), typeof(HorizontalAlignment), typeof(ChapterSelectorBarItem), new PropertyMetadata(HorizontalAlignment.Center));

        /// <summary>
        ///     The VerticalIconAlignment dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalIconAlignmentProperty =
            DependencyProperty.Register(nameof(VerticalIconAlignment), typeof(VerticalAlignment), typeof(ChapterSelectorBarItem), new PropertyMetadata(VerticalAlignment.Center));

        /// <summary>
        ///     The IconMargin dependency property.
        /// </summary>
        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register(nameof(IconMargin), typeof(Thickness), typeof(ChapterSelectorBarItem), new PropertyMetadata(default(Thickness)));

        static ChapterSelectorBarItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterSelectorBarItem), new FrameworkPropertyMetadata(typeof(ChapterSelectorBarItem)));
        }

        /// <summary>
        ///     Gets or sets the icon.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public object Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        ///     Gets or sets the icon position.
        /// </summary>
        /// <value>Default: Dock.Left.</value>
        [DefaultValue(Dock.Left)]
        public Dock IconPosition
        {
            get => (Dock)GetValue(IconPositionProperty);
            set => SetValue(IconPositionProperty, value);
        }

        /// <summary>
        ///     Gets or sets the horizontal icon alignment.
        /// </summary>
        /// <value>Default: HorizontalAlignment.Center.</value>
        [DefaultValue(HorizontalAlignment.Center)]
        public HorizontalAlignment HorizontalIconAlignment
        {
            get => (HorizontalAlignment)GetValue(HorizontalIconAlignmentProperty);
            set => SetValue(HorizontalIconAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the vertical icon alignment.
        /// </summary>
        /// <value>Default: VerticalAlignment.Center.</value>
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment VerticalIconAlignment
        {
            get => (VerticalAlignment)GetValue(VerticalIconAlignmentProperty);
            set => SetValue(VerticalIconAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the icon margin.
        /// </summary>
        /// <value>Default: 0,0,8,0.</value>
        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set => SetValue(IconMarginProperty, value);
        }
    }
}