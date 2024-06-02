﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ListBoxBase.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Chapter.Net.WPF.Controls.Bases
{
    /// <summary>
    ///     Base class for list boxes.
    /// </summary>
    public class ListBoxBase : ListBox
    {
        /// <summary>
        ///     The CornerRadius dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ListBoxBase), new PropertyMetadata(default(CornerRadius)));

        /// <summary>
        ///     Create a new instance of ListBoxBase.
        /// </summary>
        protected ListBoxBase()
        {
            Loaded += OnLoaded;
            IsEnabledChanged += OnIsEnabledChanged;
        }

        /// <summary>
        ///     Gets or sets the corner radius of the bar.
        /// </summary>
        /// <value>Default: 0.</value>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        ///     Callback when the control got loaded.
        /// </summary>
        /// <param name="sender">The loaded checkbox.</param>
        /// <param name="e">The loaded event parameter.</param>
        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        ///     Callback when the control IsEnabled got changed.
        /// </summary>
        /// <param name="sender">The checkbox.</param>
        /// <param name="e">The IsEnabledChanged event parameter.</param>
        protected virtual void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}