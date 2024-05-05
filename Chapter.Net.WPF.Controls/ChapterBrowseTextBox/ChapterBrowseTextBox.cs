// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterBrowseTextBox.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Adds a browse button to the <see cref="ChapterTextBox" />.
    /// </summary>
    [TemplatePart(Name = "PART_BrowseButton", Type = typeof(Button))]
    public class ChapterBrowseTextBox : ChapterTextBox
    {
        /// <summary>
        ///     Identifies the <see cref="BrowseButtonContent" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseButtonContentProperty =
            DependencyProperty.Register(nameof(BrowseButtonContent), typeof(object), typeof(ChapterBrowseTextBox), new UIPropertyMetadata("..."));

        /// <summary>
        ///     Identifies the <see cref="BrowseButtonPosition" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseButtonPositionProperty =
            DependencyProperty.Register(nameof(BrowseButtonPosition), typeof(Dock), typeof(ChapterBrowseTextBox), new UIPropertyMetadata(Dock.Right));

        /// <summary>
        ///     Identifies the <see cref="ShowBrowseButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowBrowseButtonProperty =
            DependencyProperty.Register(nameof(ShowBrowseButton), typeof(bool), typeof(ChapterBrowseTextBox), new UIPropertyMetadata(true));

        /// <summary>
        ///     Identifies the <see cref="BrowseCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseCommandProperty =
            DependencyProperty.Register(nameof(BrowseCommand), typeof(ICommand), typeof(ChapterBrowseTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="BrowseCommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseCommandParameterProperty =
            DependencyProperty.Register(nameof(BrowseCommandParameter), typeof(object), typeof(ChapterBrowseTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="BrowseButtonStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseButtonStyleProperty =
            DependencyProperty.Register(nameof(BrowseButtonStyle), typeof(Style), typeof(ChapterBrowseTextBox), new PropertyMetadata(null));

        /// <summary>
        ///     The RoutedEvent for the BrowseClick event.
        /// </summary>
        public static readonly RoutedEvent BrowseClickEvent =
            EventManager.RegisterRoutedEvent(nameof(BrowseClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChapterBrowseTextBox));

        static ChapterBrowseTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterBrowseTextBox), new FrameworkPropertyMetadata(typeof(ChapterBrowseTextBox)));
        }

        /// <summary>
        ///     Gets or sets the text shown in the browse button.
        /// </summary>
        /// <value>Default: "...".</value>
        [DefaultValue("...")]
        public object BrowseButtonContent
        {
            get => GetValue(BrowseButtonContentProperty);
            set => SetValue(BrowseButtonContentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the position where the browse button has to be placed inside the text box.
        /// </summary>
        /// <value>Default: Dock.Right.</value>
        [DefaultValue(Dock.Right)]
        public Dock BrowseButtonPosition
        {
            get => (Dock)GetValue(BrowseButtonPositionProperty);
            set => SetValue(BrowseButtonPositionProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the browse button is shown or not.
        /// </summary>
        /// <value>Default: true.</value>
        [DefaultValue(true)]
        public bool ShowBrowseButton
        {
            get => (bool)GetValue(ShowBrowseButtonProperty);
            set => SetValue(ShowBrowseButtonProperty, value);
        }

        /// <summary>
        ///     Gets or sets the command to be executed by the browse button.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public ICommand BrowseCommand
        {
            get => (ICommand)GetValue(BrowseCommandProperty);
            set => SetValue(BrowseCommandProperty, value);
        }

        /// <summary>
        ///     Gets or sets the command passed by the <see cref="BrowseCommand" />.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public object BrowseCommandParameter
        {
            get => GetValue(BrowseCommandParameterProperty);
            set => SetValue(BrowseCommandParameterProperty, value);
        }

        /// <summary>
        ///     Gets or sets the browse button style.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public Style BrowseButtonStyle
        {
            get => (Style)GetValue(BrowseButtonStyleProperty);
            set => SetValue(BrowseButtonStyleProperty, value);
        }

        /// <summary>
        ///     Add or removes the event handler for the BrowseClick routed event.
        /// </summary>
        public event RoutedEventHandler BrowseClick
        {
            add => AddHandler(BrowseClickEvent, value);
            remove => RemoveHandler(BrowseClickEvent, value);
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_BrowseButton") is Button searchButton)
                searchButton.Click += OnBrowseClick;
        }

        private void OnBrowseClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BrowseClickEvent, this));
        }
    }
}