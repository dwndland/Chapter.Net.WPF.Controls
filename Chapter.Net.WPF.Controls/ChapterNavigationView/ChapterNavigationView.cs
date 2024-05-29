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

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     A burger menu with items to navigate with.
    /// </summary>
    [TemplatePart(Name = "PART_ContentPresenter", Type = typeof(FrameworkElement))]
    [ContentProperty(nameof(Content))]
    public class ChapterNavigationView : ComboBox
    {
        /// <summary>
        ///     The DisplayMode dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register(nameof(DisplayMode), typeof(NavigationDisplayMode), typeof(ChapterNavigationView), new PropertyMetadata(NavigationDisplayMode.Left));

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

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_ContentPresenter") is FrameworkElement contentPresenter)
                contentPresenter.PreviewMouseLeftButtonDown += OnContentClick;
        }

        private void OnContentClick(object sender, MouseButtonEventArgs e)
        {
            SetCurrentValue(IsDropDownOpenProperty, false);
        }
    }
}