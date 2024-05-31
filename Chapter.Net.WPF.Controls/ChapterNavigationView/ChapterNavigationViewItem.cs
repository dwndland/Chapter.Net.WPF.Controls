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
    [TemplatePart(Name = "PART_PopupHeaderBar", Type = typeof(FrameworkElement))]
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

        /// <summary>
        ///     The Level dependency property.
        /// </summary>
        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register(nameof(Level), typeof(int), typeof(ChapterNavigationViewItem), new PropertyMetadata(0));

        /// <summary>
        ///     The Indentation dependency property.
        /// </summary>
        public static readonly DependencyProperty IndentationProperty =
            DependencyProperty.Register(nameof(Indentation), typeof(Thickness), typeof(ChapterNavigationViewItem), new PropertyMetadata(new Thickness()));

        private FrameworkElement _headerBar;

        static ChapterNavigationViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationViewItem), new FrameworkPropertyMetadata(typeof(ChapterNavigationViewItem)));
        }

        public ChapterNavigationViewItem()
        {
            Loaded += OnLoaded;
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

        /// <summary>
        ///     Gets the level of the item within the hierarchy.
        /// </summary>
        /// <value>Default: 0</value>
        [DefaultValue(0)]
        public int Level
        {
            get => (int)GetValue(LevelProperty);
            private set => SetValue(LevelProperty, value);
        }

        /// <summary>
        ///     Gets or sets the indentation.
        /// </summary>
        /// <value>Default: 0.</value>
        public Thickness Indentation
        {
            get => (Thickness)GetValue(IndentationProperty);
            set => SetValue(IndentationProperty, value);
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (_headerBar != null)
                _headerBar.PreviewMouseDown -= OnPressed;

            _headerBar = GetTemplateChild("PART_HeaderBar") as FrameworkElement;
            if (_headerBar != null)
                _headerBar.PreviewMouseDown += OnPressed;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // The binding in the xaml does not work if the item is within the popup item presenter
            SetBinding(DisplayModeProperty, new Binding("CurrentDisplayMode") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ChapterNavigationView), 1) });
            SetBinding(IsNavigationExpandedProperty, new Binding("IsExpanded") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ChapterNavigationView), 1) });
            SetBinding(IsDropDownOpenProperty, new Binding("IsDropDownOpen") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ChapterNavigationView), 1) });

            Level = GetLevel();
            Indentation = new Thickness(Level * 20, 0, 0, 0);
        }

        private static void OnToCompact(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ChapterNavigationViewItem)d;
            if (control.DisplayMode == NavigationDisplayMode.Left && !control.IsNavigationExpanded)
                control.SetValue(IsExpandedProperty, false);
            if (control.DisplayMode == NavigationDisplayMode.LeftCompact && !control.IsDropDownOpen)
                control.SetValue(IsExpandedProperty, false);
        }

        private void OnPressed(object sender, MouseButtonEventArgs e)
        {
            SetCurrentValue(IsSelectedProperty, true);
        }

        private int GetLevel()
        {
            if (Parent == null) // Items are bound
            {
                var count = VisualTreeAssist.GetParentsUntilCount<ChapterNavigationViewItem, ChapterNavigationView>(this);
                if (count == 0)
                    return VisualTreeAssist.FindParent<ChapterNavigationView>(this) == null ? 1 : count;
                return count;
            }

            var level = 0;
            var parent = Parent as ChapterNavigationViewItem;
            while (parent != null)
            {
                ++level;
                parent = parent.Parent as ChapterNavigationViewItem;
            }

            return level;
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