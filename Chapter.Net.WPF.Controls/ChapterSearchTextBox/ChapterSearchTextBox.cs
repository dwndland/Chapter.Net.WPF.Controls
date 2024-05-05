// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterSearchTextBox.cs" company="my-libraries">
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
    ///     Adds search and cancel buttons to the ChapterTextBox to represent a search box shown like in the Windows explorer.
    /// </summary>
    [TemplatePart(Name = "PART_SearchButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_CancelButton", Type = typeof(Button))]
    public class ChapterSearchTextBox : ChapterTextBox
    {
        /// <summary>
        ///     Identifies the <see cref="SearchButtonPosition" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchButtonPositionProperty =
            DependencyProperty.Register(nameof(SearchButtonPosition), typeof(Dock), typeof(ChapterSearchTextBox), new UIPropertyMetadata(Dock.Right));

        /// <summary>
        ///     Identifies the <see cref="SearchButtonStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchButtonStyleProperty =
            DependencyProperty.Register(nameof(SearchButtonStyle), typeof(Style), typeof(ChapterSearchTextBox), new PropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="ShowSearchButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowSearchButtonProperty =
            DependencyProperty.Register(nameof(ShowSearchButton), typeof(bool), typeof(ChapterSearchTextBox), new UIPropertyMetadata(true));

        /// <summary>
        ///     Identifies the <see cref="SearchCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register(nameof(SearchCommand), typeof(ICommand), typeof(ChapterSearchTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="SearchCommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchCommandParameterProperty =
            DependencyProperty.Register(nameof(SearchCommandParameter), typeof(object), typeof(ChapterSearchTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="CancelCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register(nameof(CancelCommand), typeof(ICommand), typeof(ChapterSearchTextBox), new PropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="CancelCommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CancelCommandParameterProperty =
            DependencyProperty.Register(nameof(CancelCommandParameter), typeof(object), typeof(ChapterSearchTextBox), new PropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="CancelButtonStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CancelButtonStyleProperty =
            DependencyProperty.Register(nameof(CancelButtonStyle), typeof(Style), typeof(ChapterSearchTextBox), new PropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="IsSearching" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsSearchingProperty =
            DependencyProperty.Register(nameof(IsSearching), typeof(bool), typeof(ChapterSearchTextBox), new UIPropertyMetadata(false));

        /// <summary>
        ///     The RoutedEvent for the SearchClick event.
        /// </summary>
        public static readonly RoutedEvent SearchClickEvent =
            EventManager.RegisterRoutedEvent(nameof(SearchClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChapterSearchTextBox));

        /// <summary>
        ///     The RoutedEvent for the CancelClick event.
        /// </summary>
        public static readonly RoutedEvent CancelClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CancelClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChapterSearchTextBox));

        static ChapterSearchTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterSearchTextBox), new FrameworkPropertyMetadata(typeof(ChapterSearchTextBox)));
        }

        /// <summary>
        ///     Gets or sets a value which indicates where the search button has to be placed.
        /// </summary>
        /// <value>Default: Dock.Right.</value>
        [DefaultValue(Dock.Right)]
        public Dock SearchButtonPosition
        {
            get => (Dock)GetValue(SearchButtonPositionProperty);
            set => SetValue(SearchButtonPositionProperty, value);
        }

        /// <summary>
        ///     Gets or sets the style of the search button.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public Style SearchButtonStyle
        {
            get => (Style)GetValue(SearchButtonStyleProperty);
            set => SetValue(SearchButtonStyleProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the search button is visible or not. This has effect on the cancel button
        ///     too.
        /// </summary>
        /// <value>Default: true.</value>
        [DefaultValue(true)]
        public bool ShowSearchButton
        {
            get => (bool)GetValue(ShowSearchButtonProperty);
            set => SetValue(ShowSearchButtonProperty, value);
        }

        /// <summary>
        ///     Gets or sets the command to be called by the search button.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public ICommand SearchCommand
        {
            get => (ICommand)GetValue(SearchCommandProperty);
            set => SetValue(SearchCommandProperty, value);
        }

        /// <summary>
        ///     Gets or sets the parameter to be passed when the <see cref="SearchCommand" /> gets executed.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public object SearchCommandParameter
        {
            get => GetValue(SearchCommandParameterProperty);
            set => SetValue(SearchCommandParameterProperty, value);
        }

        /// <summary>
        ///     Gets or sets the command to be called by the cancel button.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public ICommand CancelCommand
        {
            get => (ICommand)GetValue(CancelCommandProperty);
            set => SetValue(CancelCommandProperty, value);
        }

        /// <summary>
        ///     Gets or sets the parameter to be passed when the <see cref="CancelCommand" /> gets executed.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public object CancelCommandParameter
        {
            get => GetValue(CancelCommandParameterProperty);
            set => SetValue(CancelCommandParameterProperty, value);
        }

        /// <summary>
        ///     Gets or sets the cancel button style.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public Style CancelButtonStyle
        {
            get => (Style)GetValue(CancelButtonStyleProperty);
            set => SetValue(CancelButtonStyleProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the search or cancel button is visible. If true the cancel button is shown;
        ///     otherwise the search button.
        /// </summary>
        /// <value>Default: false.</value>
        [DefaultValue(false)]
        public bool IsSearching
        {
            get => (bool)GetValue(IsSearchingProperty);
            set => SetValue(IsSearchingProperty, value);
        }

        /// <summary>
        ///     Add or removes the event handler for the SearchClick routed event.
        /// </summary>
        public event RoutedEventHandler SearchClick
        {
            add => AddHandler(SearchClickEvent, value);
            remove => RemoveHandler(SearchClickEvent, value);
        }

        /// <summary>
        ///     Add or removes the event handler for the SearchClick routed event.
        /// </summary>
        public event RoutedEventHandler CancelClick
        {
            add => AddHandler(CancelClickEvent, value);
            remove => RemoveHandler(CancelClickEvent, value);
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_SearchButton") is Button searchButton)
                searchButton.Click += OnSearchClick;

            if (GetTemplateChild("PART_CancelButton") is Button cancelButton)
                cancelButton.Click += OnCancelClick;
        }

        private void OnSearchClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SearchClickEvent, this));
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(CancelClickEvent, this));
        }
    }
}