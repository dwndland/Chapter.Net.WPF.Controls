// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationTreeItemsPresenter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     The presenter displaying the <see cref="ChapterNavigationViewItem" />s.
    /// </summary>
    public class ChapterNavigationTreeItemsPresenter : ChapterTreeView
    {
        /// <summary>
        ///     The ChapterNavigationTreeItemsPresenter style key.
        /// </summary>
        public static readonly ComponentResourceKey StyleKey = new ComponentResourceKey(typeof(ChapterNavigationTreeItemsPresenter), "ChapterNavigationTreeItemsPresenter");

        /// <summary>
        ///     The DisplayMode dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register(nameof(DisplayMode), typeof(NavigationDisplayMode), typeof(ChapterNavigationTreeItemsPresenter), new PropertyMetadata(NavigationDisplayMode.Left));

        static ChapterNavigationTreeItemsPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationTreeItemsPresenter), new FrameworkPropertyMetadata(typeof(ChapterNavigationTreeItemsPresenter)));
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