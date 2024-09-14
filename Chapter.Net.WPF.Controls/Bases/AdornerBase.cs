// -----------------------------------------------------------------------------------------------------------------
// <copyright file="AdornerBase.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Documents;

namespace Chapter.Net.WPF.Controls.Bases;

/// <summary>
///     Base class for adorners;
/// </summary>
public abstract class AdornerBase : Adorner
{
    /// <summary>
    ///     Creates a new instance of AdornerBase.
    /// </summary>
    /// <param name="adornedElement">The adorned element.</param>
    protected AdornerBase(UIElement adornedElement)
        : base(adornedElement)
    {
        Loaded += OnLoaded;
        IsEnabledChanged += OnIsEnabledChanged;
        DataContextChanged += OnDataContextChanged;
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