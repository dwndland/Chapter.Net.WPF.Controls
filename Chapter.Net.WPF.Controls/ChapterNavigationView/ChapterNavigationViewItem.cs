// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationViewItem.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     A single item within the <see cref="ChapterNavigationView" />.
    /// </summary>
    [TemplatePart(Name = "PART_HeaderBar", Type = typeof(FrameworkElement))]
    public class ChapterNavigationViewItem : ChapterTreeViewItem
    {
        /// <summary>
        ///     The ChapterNavigationViewItem style key.
        /// </summary>
        public static readonly ComponentResourceKey StyleKey = new ComponentResourceKey(typeof(ChapterNavigationViewItem), "ChapterNavigationViewItem");

        /// <summary>
        ///     The Icon style key.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(object), typeof(ChapterNavigationViewItem), new PropertyMetadata(null));

        /// <summary>
        ///     The IsDropDownOpen dependency property.
        /// </summary>
        public static readonly DependencyProperty IsDropDownOpenProperty =
            DependencyProperty.Register(nameof(IsDropDownOpen), typeof(bool), typeof(ChapterNavigationViewItem), new PropertyMetadata(false, OnToCompact));

        /// <summary>
        ///     The IsNavigationExpanded dependency property.
        /// </summary>
        public static readonly DependencyProperty IsNavigationExpandedProperty =
            DependencyProperty.Register(nameof(IsNavigationExpanded), typeof(bool), typeof(ChapterNavigationViewItem), new PropertyMetadata(false, OnToCompact));

        /// <summary>
        ///     The DisplayMode dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register(nameof(DisplayMode), typeof(NavigationDisplayMode), typeof(ChapterNavigationViewItem), new PropertyMetadata(NavigationDisplayMode.Left, OnToCompact));

        /// <summary>
        ///     The CornerRadius dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ChapterNavigationViewItem), new PropertyMetadata(default(CornerRadius)));

        static ChapterNavigationViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationViewItem), new FrameworkPropertyMetadata(typeof(ChapterNavigationViewItem)));
        }

        /// <summary>
        ///     Gets or sets the icon of the item.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public object Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the item is an expanded popup.
        /// </summary>
        /// <value>Default: false.</value>
        [DefaultValue(false)]
        public bool IsDropDownOpen
        {
            get => (bool)GetValue(IsDropDownOpenProperty);
            set => SetValue(IsDropDownOpenProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the item is an expanded panel.
        /// </summary>
        /// <value>Default: false.</value>
        [DefaultValue(false)]
        public bool IsNavigationExpanded
        {
            get => (bool)GetValue(IsNavigationExpandedProperty);
            set => SetValue(IsNavigationExpandedProperty, value);
        }

        /// <summary>
        ///     Gets or sets the display mode in which the button is displayed in .
        /// </summary>
        /// <value>Default: NavigationDisplayMode.Left.</value>
        [DefaultValue(NavigationDisplayMode.Left)]
        public NavigationDisplayMode DisplayMode
        {
            get => (NavigationDisplayMode)GetValue(DisplayModeProperty);
            set => SetValue(DisplayModeProperty, value);
        }

        /// <summary>
        ///     Gets or sets the corner radius.
        /// </summary>
        /// <value>Default: default.</value>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        private static void OnToCompact(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ChapterNavigationViewItem)d;
            if (control.DisplayMode == NavigationDisplayMode.Left && !control.IsNavigationExpanded)
                control.SetValue(IsExpandedProperty, false);
            if (control.DisplayMode == NavigationDisplayMode.LeftCompact && !control.IsDropDownOpen)
                control.SetValue(IsExpandedProperty, false);
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // No idea why these bindings do not work in the style.
            SetBinding(DisplayModeProperty, new Binding("CurrentDisplayMode") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ChapterNavigationView), 1) });
            SetBinding(IsNavigationExpandedProperty, new Binding("IsExpanded") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ChapterNavigationView), 1) });
            SetBinding(IsDropDownOpenProperty, new Binding("IsDropDownOpen") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ChapterNavigationView), 1) });

            if (GetTemplateChild("PART_HeaderBar") is FrameworkElement headerBar)
                headerBar.PreviewMouseDown += OnPressed;
        }

        private void OnPressed(object sender, MouseButtonEventArgs e)
        {
            SetCurrentValue(IsSelectedProperty, true);
        }

        /// <inheritdoc />
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ChapterNavigationViewItem;
        }

        /// <inheritdoc />
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ChapterNavigationViewItem();
        }
    }
}