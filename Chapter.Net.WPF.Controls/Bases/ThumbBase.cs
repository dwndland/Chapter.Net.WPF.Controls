﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ThumbBase.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls.Primitives;

namespace Chapter.Net.WPF.Controls.Bases;

/// <summary>
///     Base class for thumbs.
/// </summary>
public class ThumbBase : Thumb
{
    /// <summary>
    ///     The CornerRadius dependency property.
    /// </summary>
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ThumbBase), new PropertyMetadata(default(CornerRadius)));

    /// <summary>
    ///     Create a new instance of ThumbBase.
    /// </summary>
    protected ThumbBase()
    {
        Loaded += OnLoaded;
        IsEnabledChanged += OnIsEnabledChanged;
        DataContextChanged += OnDataContextChanged;
    }

    /// <summary>
    ///     Gets or sets the corner radius of the item.
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

    /// <summary>
    ///     Callback when the data context got changed.
    /// </summary>
    /// <param name="sender">The control.</param>
    /// <param name="e">The DataContextChanged event parameter.</param>
    protected virtual void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
    }
}