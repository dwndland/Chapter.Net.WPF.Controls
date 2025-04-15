// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ScrollViewerBase.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Chapter.Net.WPF.Controls.Bases;

/// <summary>
///     Base class for scroll viewers.
/// </summary>
public abstract class ScrollViewerBase : ScrollViewer
{
    /// <summary>
    ///     The CornerRadius dependency property.
    /// </summary>
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ScrollViewerBase), new PropertyMetadata(default(CornerRadius)));

    /// <summary>
    ///     Create a new instance of ScrollViewerBase.
    /// </summary>
    protected ScrollViewerBase()
    {
        Loaded += OnLoaded;
        IsEnabledChanged += OnIsEnabledChanged;
        DataContextChanged += OnDataContextChanged;
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