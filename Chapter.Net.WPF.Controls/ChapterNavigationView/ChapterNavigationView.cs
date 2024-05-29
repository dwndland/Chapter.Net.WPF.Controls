// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationView.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     A burger menu with items to navigate with.
    /// </summary>
    [TemplatePart(Name = "PART_ContentPresenter", Type = typeof(FrameworkElement))]
    [ContentProperty(nameof(Content))]
    public class ChapterNavigationView : ComboBoxBase
    {
        /// <summary>
        ///     The DisplayMode dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register(nameof(DisplayMode), typeof(NavigationDisplayMode), typeof(ChapterNavigationView), new PropertyMetadata(NavigationDisplayMode.Left, OnDisplayModeChanged));

        /// <summary>
        ///     The IsExpanded dependency property.
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(ChapterNavigationView), new PropertyMetadata(true));

        /// <summary>
        ///     The Content dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(nameof(Content), typeof(object), typeof(ChapterNavigationView), new PropertyMetadata(null));

        /// <summary>
        ///     The CurrentDisplayMode dependency property.
        /// </summary>
        internal static readonly DependencyProperty CurrentDisplayModeProperty =
            DependencyProperty.Register(nameof(CurrentDisplayMode), typeof(NavigationDisplayMode), typeof(ChapterNavigationView), new PropertyMetadata(NavigationDisplayMode.Left));

        static ChapterNavigationView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationView), new FrameworkPropertyMetadata(typeof(ChapterNavigationView)));
        }

        /// <summary>
        ///     Gets or sets the current display mode.
        /// </summary>
        /// <value>Default: NavigationDisplayMode.Left.</value>
        [DefaultValue(NavigationDisplayMode.Left)]
        public NavigationDisplayMode DisplayMode
        {
            get => (NavigationDisplayMode)GetValue(DisplayModeProperty);
            set => SetValue(DisplayModeProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the navigation is expanded in the Left display mode or not.
        /// </summary>
        /// <remarks>
        ///     This property us used only if the <see cref="DisplayMode" /> is set to left. In LeftCompact or LeftMinimal the
        ///     <see cref="ComboBox.IsDropDownOpen" /> is used.
        /// </remarks>
        /// <value>Default: true.</value>
        [DefaultValue(true)]
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        /// <summary>
        ///     Gets or sets the content shown in the body of the navigation view.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the current display mode which gets controlled by the DisplayMode.
        /// </summary>
        /// <value>Default: NavigationDisplayMode.Left.</value>
        [DefaultValue(NavigationDisplayMode.Left)]
        internal NavigationDisplayMode CurrentDisplayMode
        {
            get => (NavigationDisplayMode)GetValue(CurrentDisplayModeProperty);
            set => SetValue(CurrentDisplayModeProperty, value);
        }

        private static void OnDisplayModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ChapterNavigationView)d;
            if (control.DisplayMode != NavigationDisplayMode.Auto)
                control.SetCurrentValue(CurrentDisplayModeProperty, control.DisplayMode);
            else
                control.SetCurrentDisplayModeByWidth(control.ActualWidth);
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_ContentPresenter") is FrameworkElement contentPresenter)
                contentPresenter.PreviewMouseLeftButtonDown += OnContentClick;
        }

        /// <inheritdoc />
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            if (DisplayMode == NavigationDisplayMode.Auto && sizeInfo.WidthChanged)
                SetCurrentDisplayModeByWidth(sizeInfo.NewSize.Width);

            base.OnRenderSizeChanged(sizeInfo);
        }

        private void OnContentClick(object sender, MouseButtonEventArgs e)
        {
            SetCurrentValue(IsDropDownOpenProperty, false);
        }

        private void SetCurrentDisplayModeByWidth(double width)
        {
            if (width < 400)
                SetCurrentValue(CurrentDisplayModeProperty, NavigationDisplayMode.LeftMinimal);
            else if (width < 800)
                SetCurrentValue(CurrentDisplayModeProperty, NavigationDisplayMode.LeftCompact);
            else
                SetCurrentValue(CurrentDisplayModeProperty, NavigationDisplayMode.Left);
        }
    }
}