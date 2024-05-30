// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationPopupItemPresenter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     The presenter display a <see cref="ChapterNavigationViewItem" /> and its direct children either directly or in a
    ///     popup.
    /// </summary>
    [ContentProperty(nameof(Content))]
    public class ChapterNavigationPopupItemPresenter : ComboBoxBase
    {
        /// <summary>
        ///     The ChapterNavigationItemPresenter style key.
        /// </summary>
        public static readonly ComponentResourceKey StyleKey = new ComponentResourceKey(typeof(ChapterNavigationPopupItemPresenter), "ChapterNavigationItemPresenter");

        /// <summary>
        ///     The Header dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(object), typeof(ChapterNavigationPopupItemPresenter), new PropertyMetadata(null));

        /// <summary>
        ///     The Content dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(nameof(Content), typeof(object), typeof(ChapterNavigationPopupItemPresenter), new PropertyMetadata(null));

        /// <summary>
        ///     The Placement dependency property.
        /// </summary>
        public static readonly DependencyProperty PlacementProperty =
            DependencyProperty.Register(nameof(Placement), typeof(PlacementMode), typeof(ChapterNavigationPopupItemPresenter), new PropertyMetadata(PlacementMode.Right));

        static ChapterNavigationPopupItemPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationPopupItemPresenter), new FrameworkPropertyMetadata(typeof(ChapterNavigationPopupItemPresenter)));
        }

        /// <summary>
        ///     Gets or sets main item shown.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        ///     Gets or sets child item either directly or in a popup.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the placement of the popup.
        /// </summary>
        /// <value>Default: PlacementMode.Right.</value>
        [DefaultValue(PlacementMode.Right)]
        public PlacementMode Placement
        {
            get => (PlacementMode)GetValue(PlacementProperty);
            set => SetValue(PlacementProperty, value);
        }
    }
}