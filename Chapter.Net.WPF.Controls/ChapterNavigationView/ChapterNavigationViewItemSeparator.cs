// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationViewItemSeparator.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Displays a separator line within the items in the <see cref="ChapterNavigationView" />.
/// </summary>
public class ChapterNavigationViewItemSeparator : ChapterNavigationViewItem
{
    /// <summary>
    ///     The ChapterNavigationViewItemSeparator style key.
    /// </summary>
    public new static readonly ComponentResourceKey StyleKey = new(typeof(ChapterNavigationViewItemSeparator), "ChapterNavigationViewItemSeparator");

    /// <summary>
    ///     The IsVisibleOnLeftCompact dependency property.
    /// </summary>
    public static readonly DependencyProperty IsVisibleOnLeftCompactProperty =
        DependencyProperty.Register(nameof(IsVisibleOnLeftCompact), typeof(bool), typeof(ChapterNavigationViewItemSeparator), new PropertyMetadata(false));

    /// <summary>
    ///     The IsVisibleOnTop dependency property.
    /// </summary>
    public static readonly DependencyProperty IsVisibleOnTopProperty =
        DependencyProperty.Register(nameof(IsVisibleOnTop), typeof(bool), typeof(ChapterNavigationViewItemSeparator), new PropertyMetadata(true));

    static ChapterNavigationViewItemSeparator()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationViewItemSeparator), new FrameworkPropertyMetadata(typeof(ChapterNavigationViewItemSeparator)));
    }

    /// <summary>
    ///     Gets or set a value indicating whether the separator shall be shown if the navigation view is collapsed to the
    ///     left.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool IsVisibleOnLeftCompact
    {
        get => (bool)GetValue(IsVisibleOnLeftCompactProperty);
        set => SetValue(IsVisibleOnLeftCompactProperty, value);
    }

    /// <summary>
    ///     Gets or set a value indicating whether the separator shall be shown if the navigation view is on the top.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool IsVisibleOnTop
    {
        get => (bool)GetValue(IsVisibleOnTopProperty);
        set => SetValue(IsVisibleOnTopProperty, value);
    }
}