// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTabItem.cs" company="my-libraries">
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
    ///     Represents the shown tab in the <see cref="ChapterTabControl" />.
    /// </summary>
    [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
    public class ChapterTabItem : TabItem
    {
        /// <summary>
        ///     Identifies the <see cref="CloseButtonPosition" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonPositionProperty =
            DependencyProperty.Register(nameof(CloseButtonPosition), typeof(Dock), typeof(ChapterTabItem), new UIPropertyMetadata(Dock.Right));

        /// <summary>
        ///     Identifies the <see cref="ShowCloseButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowCloseButtonProperty =
            DependencyProperty.Register(nameof(ShowCloseButton), typeof(bool), typeof(ChapterTabItem), new UIPropertyMetadata(true));

        /// <summary>
        ///     Identifies the <see cref="CloseButtonStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonStyleProperty =
            DependencyProperty.Register(nameof(CloseButtonStyle), typeof(Style), typeof(ChapterTabItem), new PropertyMetadata(null));

        /// <summary>
        ///     The RoutedEvent for the CloseClick event.
        /// </summary>
        public static readonly RoutedEvent CloseClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CloseClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChapterTabItem));

        static ChapterTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterTabItem), new FrameworkPropertyMetadata(typeof(ChapterTabItem)));
        }

        /// <summary>
        ///     Gets or sets a value which indicates where the close tab item button have to be placed in the header.
        /// </summary>
        /// <value>Default: Dock.Right.</value>
        [DefaultValue(Dock.Right)]
        public Dock CloseButtonPosition
        {
            get => (Dock)GetValue(CloseButtonPositionProperty);
            set => SetValue(CloseButtonPositionProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the close tab item button is visible or not.
        /// </summary>
        /// <value>Default: true.</value>
        [DefaultValue(true)]
        public bool ShowCloseButton
        {
            get => (bool)GetValue(ShowCloseButtonProperty);
            set => SetValue(ShowCloseButtonProperty, value);
        }

        /// <summary>
        ///     Gets or sets the style of the close button.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public Style CloseButtonStyle
        {
            get => (Style)GetValue(CloseButtonStyleProperty);
            set => SetValue(CloseButtonStyleProperty, value);
        }

        /// <summary>
        ///     Add or removes the event handler for the AddClick routed event.
        /// </summary>
        public event RoutedEventHandler CloseClick
        {
            add => AddHandler(CloseClickEvent, value);
            remove => RemoveHandler(CloseClickEvent, value);
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_CloseButton") is Button addButton)
                addButton.Click += OnCloseButtonClick;
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(CloseClickEvent, this));
        }
    }
}