// -----------------------------------------------------------------------------------------------------------------
// <copyright file="RepeatButtonBase.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Chapter.Net.WPF.Controls.Bases;

/// <summary>
///     Base class for toggle buttons.
/// </summary>
public abstract class RepeatButtonBase : RepeatButton
{
    /// <summary>
    ///     The CornerRadius dependency property.
    /// </summary>
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(RepeatButtonBase), new PropertyMetadata(default(CornerRadius)));

    /// <summary>
    ///     The OvalCornerRadius dependency property.
    /// </summary>
    public static readonly DependencyProperty OvalCornerRadiusProperty =
        DependencyProperty.Register(nameof(OvalCornerRadius), typeof(CornerRadius), typeof(RepeatButtonBase), new PropertyMetadata(default(CornerRadius)));

    /// <summary>
    ///     The HasOvalEndings dependency property.
    /// </summary>
    public static readonly DependencyProperty HasOvalEndingsProperty =
        DependencyProperty.Register(nameof(HasOvalEndings), typeof(bool), typeof(RepeatButtonBase), new PropertyMetadata(false));

    /// <summary>
    ///     Create a new instance of RepeatButtonBase.
    /// </summary>
    protected RepeatButtonBase()
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
    ///     Gets or sets the corner radius if <see cref="HasOvalEndings" /> is on.
    /// </summary>
    /// <value>Default: default.</value>
    public CornerRadius OvalCornerRadius
    {
        get => (CornerRadius)GetValue(OvalCornerRadiusProperty);
        set => SetValue(OvalCornerRadiusProperty, value);
    }

    /// <summary>
    ///     Gets or set a value indicating whether the endings of the toggle button shall be oval.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool HasOvalEndings
    {
        get => (bool)GetValue(HasOvalEndingsProperty);
        set => SetValue(HasOvalEndingsProperty, value);
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

    /// <inheritdoc />
    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        if (sizeInfo is { HeightChanged: true, NewSize.Height: > 0 })
            OvalCornerRadius = new CornerRadius(sizeInfo.NewSize.Height / 2);

        base.OnRenderSizeChanged(sizeInfo);
    }
}