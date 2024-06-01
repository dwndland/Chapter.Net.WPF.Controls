// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     A repeat button which brings additional features like a header, footer and icon.
    /// </summary>
    [TemplatePart(Name = "PART_Border", Type = typeof(FrameworkElement))]
    public class ChapterRepeatButton : RepeatButtonBase
    {
        /// <summary>
        ///     The ChapterRepeatButton style key.
        /// </summary>
        public static readonly ComponentResourceKey StyleKey = new ComponentResourceKey(typeof(ChapterRepeatButton), "ChapterRepeatButton");

        /// <summary>
        ///     The Header dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(object), typeof(ChapterRepeatButton), new PropertyMetadata(null));

        /// <summary>
        ///     The Footer dependency property.
        /// </summary>
        public static readonly DependencyProperty FooterProperty =
            DependencyProperty.Register(nameof(Footer), typeof(object), typeof(ChapterRepeatButton), new PropertyMetadata(null));

        /// <summary>
        ///     The Icon dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(object), typeof(ChapterRepeatButton), new PropertyMetadata(null));

        /// <summary>
        ///     The ImageIcon dependency property.
        /// </summary>
        public static readonly DependencyProperty ImageIconProperty =
            DependencyProperty.Register(nameof(ImageIcon), typeof(Image), typeof(ChapterRepeatButton), new PropertyMetadata(null));

        /// <summary>
        ///     The IconMargin dependency property.
        /// </summary>
        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register(nameof(IconMargin), typeof(Thickness), typeof(ChapterRepeatButton), new PropertyMetadata(new Thickness(0, 0, 6, 0)));

        /// <summary>
        ///     The HorizontalIconAlignment dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalIconAlignmentProperty =
            DependencyProperty.Register(nameof(HorizontalIconAlignment), typeof(HorizontalAlignment), typeof(ChapterRepeatButton), new PropertyMetadata(HorizontalAlignment.Left));

        /// <summary>
        ///     The VerticalIconAlignment dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalIconAlignmentProperty =
            DependencyProperty.Register(nameof(VerticalIconAlignment), typeof(VerticalAlignment), typeof(ChapterRepeatButton), new PropertyMetadata(VerticalAlignment.Center));

        /// <summary>
        ///     The IconPosition dependency property.
        /// </summary>
        public static readonly DependencyProperty IconPositionProperty =
            DependencyProperty.Register(nameof(IconPosition), typeof(Dock), typeof(ChapterRepeatButton), new PropertyMetadata(Dock.Left));

        private FrameworkElement _border;

        static ChapterRepeatButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterRepeatButton), new FrameworkPropertyMetadata(typeof(ChapterRepeatButton)));
        }

        /// <summary>
        ///     Gets or sets the header.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        ///     Gets or sets the footer.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public object Footer
        {
            get => GetValue(FooterProperty);
            set => SetValue(FooterProperty, value);
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
        ///     Gets or sets the icon by image.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public Image ImageIcon
        {
            get => (Image)GetValue(ImageIconProperty);
            set => SetValue(ImageIconProperty, value);
        }

        /// <summary>
        ///     Gets or sets the margin of the icon.
        /// </summary>
        /// <value>Default: 0, 0, 6, 0</value>
        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set => SetValue(IconMarginProperty, value);
        }

        /// <summary>
        ///     Gets or sets the horizontal icon alignment.
        /// </summary>
        /// <value>Default: HorizontalAlignment.Left.</value>
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment HorizontalIconAlignment
        {
            get => (HorizontalAlignment)GetValue(HorizontalIconAlignmentProperty);
            set => SetValue(HorizontalIconAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the vertical icon alignment.
        /// </summary>
        /// <value>Default: VerticalAlignment.Left.</value>
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment VerticalIconAlignment
        {
            get => (VerticalAlignment)GetValue(VerticalIconAlignmentProperty);
            set => SetValue(VerticalIconAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the position of the icon.
        /// </summary>
        /// <value>Default: Dock.Left.</value>
        [DefaultValue(Dock.Left)]
        public Dock IconPosition
        {
            get => (Dock)GetValue(IconPositionProperty);
            set => SetValue(IconPositionProperty, value);
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _border = GetTemplateChild("PART_Border") as FrameworkElement;
        }

        /// <inheritdoc />
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (_border != null && _border.ActualHeight > 0)
                OvalCornerRadius = new CornerRadius(_border.ActualHeight / 2);
        }
    }
}