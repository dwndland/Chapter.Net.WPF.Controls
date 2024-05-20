// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterBadge.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     A notification badge control.
    /// </summary>
    [TemplatePart(Name = "PART_NumberPresenter", Type = typeof(TextBlock))]
    public class ChapterBadge : ContentControlBase
    {
        /// <summary>
        ///     The ChapterBadge style key.
        /// </summary>
        public static readonly ComponentResourceKey StyleKey = new ComponentResourceKey(typeof(ChapterBadge), "ChapterBadge");

        /// <summary>
        ///     The Shape dependency property.
        /// </summary>
        public static readonly DependencyProperty ShapeProperty =
            DependencyProperty.Register(nameof(Shape), typeof(BadgeShape), typeof(ChapterBadge), new PropertyMetadata(BadgeShape.Oval));

        /// <summary>
        ///     The Variant dependency property.
        /// </summary>
        public static readonly DependencyProperty VariantProperty =
            DependencyProperty.Register(nameof(Variant), typeof(BadgeVariant), typeof(ChapterBadge), new PropertyMetadata(BadgeVariant.Number));

        /// <summary>
        ///     The CornerRadius dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ChapterBadge), new PropertyMetadata(new CornerRadius(4)));

        /// <summary>
        ///     The Number dependency property.
        /// </summary>
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register(nameof(Number), typeof(int), typeof(ChapterBadge), new FrameworkPropertyMetadata(0));

        /// <summary>
        ///     The HideOnZero dependency property.
        /// </summary>
        public static readonly DependencyProperty HideOnZeroProperty =
            DependencyProperty.Register(nameof(HideOnZero), typeof(bool), typeof(ChapterBadge), new PropertyMetadata(false));

        /// <summary>
        ///     The NumberStringFormat dependency property.
        /// </summary>
        public static readonly DependencyProperty NumberStringFormatProperty =
            DependencyProperty.Register(nameof(NumberStringFormat), typeof(string), typeof(ChapterBadge), new PropertyMetadata(null));

        /// <summary>
        ///     The NumberConverter dependency property.
        /// </summary>
        public static readonly DependencyProperty NumberConverterProperty =
            DependencyProperty.Register(nameof(NumberConverter), typeof(IValueConverter), typeof(ChapterBadge), new PropertyMetadata(null));

        /// <summary>
        ///     The OvalCornerRadius dependency property.
        /// </summary>
        internal static readonly DependencyProperty OvalCornerRadiusProperty =
            DependencyProperty.Register(nameof(OvalCornerRadius), typeof(CornerRadius), typeof(ChapterBadge), new PropertyMetadata(default(CornerRadius)));

        /// <summary>
        ///     The HorizontalOffset dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalOffsetProperty =
            DependencyProperty.Register(nameof(HorizontalOffset), typeof(double), typeof(ChapterBadge), new PropertyMetadata(1d, OnPositionChanged));

        /// <summary>
        ///     The VerticalOffset dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.Register(nameof(VerticalOffset), typeof(double), typeof(ChapterBadge), new PropertyMetadata(0d, OnPositionChanged));

        /// <summary>
        ///     The HorizontalAnchorOffset dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalAnchorOffsetProperty =
            DependencyProperty.Register(nameof(HorizontalAnchorOffset), typeof(double), typeof(ChapterBadge), new PropertyMetadata(0.5d, OnPositionChanged));

        /// <summary>
        ///     The VerticalAnchorOffset dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalAnchorOffsetProperty =
            DependencyProperty.Register(nameof(VerticalAnchorOffset), typeof(double), typeof(ChapterBadge), new PropertyMetadata(0.5d, OnPositionChanged));

        /// <summary>
        ///     The Badge attached dependency property.
        /// </summary>
        public static readonly DependencyProperty BadgeProperty =
            DependencyProperty.RegisterAttached("Badge", typeof(ChapterBadge), typeof(ChapterBadge), new PropertyMetadata(null, OnBadgeChanged));

        static ChapterBadge()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterBadge), new FrameworkPropertyMetadata(typeof(ChapterBadge)));
        }

        /// <summary>
        ///     Gets or sets the shape of the badge.
        /// </summary>
        /// <value>Default: BadgeShape.Oval.</value>
        [DefaultValue(BadgeShape.Oval)]
        public BadgeShape Shape
        {
            get => (BadgeShape)GetValue(ShapeProperty);
            set => SetValue(ShapeProperty, value);
        }

        /// <summary>
        ///     Gets or sets the variant of the badge.
        /// </summary>
        /// <value>Default: BadgeVariant.Number.</value>
        [DefaultValue(BadgeVariant.Number)]
        public BadgeVariant Variant
        {
            get => (BadgeVariant)GetValue(VariantProperty);
            set => SetValue(VariantProperty, value);
        }

        /// <summary>
        ///     Gets or sets the shape of the badge.
        /// </summary>
        /// <value>Default: default.</value>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        ///     Gets or sets the number to show if the variant is set to Number.
        /// </summary>
        /// <value>Default: 0.</value>
        [DefaultValue(0)]
        public int Number
        {
            get => (int)GetValue(NumberProperty);
            set => SetValue(NumberProperty, value);
        }

        /// <summary>
        ///     Gets or sets the value indicating whether the badge shall be shown if the number is on 0 or not.
        /// </summary>
        /// <value>Default: false.</value>
        [DefaultValue(false)]
        public bool HideOnZero
        {
            get => (bool)GetValue(HideOnZeroProperty);
            set => SetValue(HideOnZeroProperty, value);
        }

        /// <summary>
        ///     Gets or sets the string format for the number display.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public string NumberStringFormat
        {
            get => (string)GetValue(NumberStringFormatProperty);
            set => SetValue(NumberStringFormatProperty, value);
        }

        /// <summary>
        ///     Gets or sets the converter for the number display.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public IValueConverter NumberConverter
        {
            get => (IValueConverter)GetValue(NumberConverterProperty);
            set => SetValue(NumberConverterProperty, value);
        }

        /// <summary>
        ///     Gets or sets the horizontal position offset (0.0 - 1.0).
        /// </summary>
        /// <value>Default: 1.0</value>
        [DefaultValue(1.0)]
        public double HorizontalOffset
        {
            get => (double)GetValue(HorizontalOffsetProperty);
            set => SetValue(HorizontalOffsetProperty, value);
        }

        /// <summary>
        ///     Gets or sets the vertical position offset (0.0 - 1.0).
        /// </summary>
        /// <value>Default: 0.0</value>
        [DefaultValue(0.0)]
        public double VerticalOffset
        {
            get => (double)GetValue(VerticalOffsetProperty);
            set => SetValue(VerticalOffsetProperty, value);
        }

        /// <summary>
        ///     Gets or sets the horizontal anchor position offset (0.0 - 1.0).
        /// </summary>
        /// <value>Default: 0.5</value>
        [DefaultValue(0.5)]
        public double HorizontalAnchorOffset
        {
            get => (double)GetValue(HorizontalAnchorOffsetProperty);
            set => SetValue(HorizontalAnchorOffsetProperty, value);
        }

        /// <summary>
        ///     Gets or sets the vertical anchor position offset (0.0 - 1.0).
        /// </summary>
        /// <value>Default: 0.5</value>
        [DefaultValue(0.5)]
        public double VerticalAnchorOffset
        {
            get => (double)GetValue(VerticalAnchorOffsetProperty);
            set => SetValue(VerticalAnchorOffsetProperty, value);
        }

        /// <summary>
        ///     Gets or sets the corner radius for the oval shape.
        /// </summary>
        internal CornerRadius OvalCornerRadius
        {
            get => (CornerRadius)GetValue(OvalCornerRadiusProperty);
            set => SetValue(OvalCornerRadiusProperty, value);
        }

        /// <summary>
        ///     Raised if the badge position got changed.
        /// </summary>
        public event EventHandler PositionChanged;

        private static void OnPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var badge = (ChapterBadge)d;
            badge.PositionChanged?.Invoke(badge, EventArgs.Empty);
        }

        /// <summary>
        ///     Gets the attached badge from a control
        /// </summary>
        /// <param name="obj">The control which has the badge attached.</param>
        /// <returns>The attached badge.</returns>
        public static ChapterBadge GetBadge(DependencyObject obj)
        {
            return (ChapterBadge)obj.GetValue(BadgeProperty);
        }

        /// <summary>
        ///     Attaches a badge to a control.
        /// </summary>
        /// <param name="obj">The control which has to get the badge attached.</param>
        /// <param name="value">The badge to attach.</param>
        public static void SetBadge(DependencyObject obj, ChapterBadge value)
        {
            obj.SetValue(BadgeProperty, value);
        }

        private static void OnBadgeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is FrameworkElement element))
                throw new InvalidOperationException("ChapterBadge.Badge can be attached to a FrameworkElement only.");

            if (!element.IsLoaded)
                element.Loaded += OnLoaded;
            else
                Adorn(element, e.NewValue as ChapterBadge);
        }

        private static void OnLoaded(object sender, EventArgs e)
        {
            var element = (FrameworkElement)sender;
            element.Loaded -= OnLoaded;
            var badge = GetBadge(element);
            Adorn(element, badge);
        }

        private static void Adorn(FrameworkElement target, ChapterBadge badge)
        {
            if (badge == null)
                return;

            var layer = AdornerLayer.GetAdornerLayer(target);
            badge.DataContext = target.DataContext;
            layer?.Add(new BadgeAdorner(target, badge));
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_NumberPresenter") is TextBlock textBlock)
                textBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Number))
                {
                    RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
                    StringFormat = NumberStringFormat,
                    Converter = NumberConverter
                });
        }

        /// <inheritdoc />
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            var newHeight = sizeInfo.NewSize.Height;
            if (Shape == BadgeShape.Oval && newHeight > 0)
            {
                var halfSize = newHeight / 2;
                SetCurrentValue(OvalCornerRadiusProperty, new CornerRadius(halfSize));
            }

            base.OnRenderSizeChanged(sizeInfo);
        }
    }
}