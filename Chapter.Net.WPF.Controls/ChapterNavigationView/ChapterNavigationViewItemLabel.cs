// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationViewItemLabel.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Displays a label within the items in the <see cref="ChapterNavigationView" />.
/// </summary>
public class ChapterNavigationViewItemLabel : ChapterNavigationViewItem
{
    /// <summary>
    ///     The ChapterNavigationViewItemLabel style key.
    /// </summary>
    public new static readonly ComponentResourceKey StyleKey = new(typeof(ChapterNavigationViewItemLabel), "ChapterNavigationViewItemLabel");

    /// <summary>
    ///     The IsVisibleOnLeftCompact dependency property.
    /// </summary>
    public static readonly DependencyProperty IsVisibleOnLeftCompactProperty =
        DependencyProperty.Register(nameof(IsVisibleOnLeftCompact), typeof(bool), typeof(ChapterNavigationViewItemLabel), new PropertyMetadata(false));

    /// <summary>
    ///     The IsVisibleOnTop dependency property.
    /// </summary>
    public static readonly DependencyProperty IsVisibleOnTopProperty =
        DependencyProperty.Register(nameof(IsVisibleOnTop), typeof(bool), typeof(ChapterNavigationViewItemLabel), new PropertyMetadata(true));

    static ChapterNavigationViewItemLabel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationViewItemLabel), new FrameworkPropertyMetadata(typeof(ChapterNavigationViewItemLabel)));
    }

    /// <summary>
    ///     Gets or set a value indicating whether the label shall be shown if the navigation view is collapsed to the left.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool IsVisibleOnLeftCompact
    {
        get => (bool)GetValue(IsVisibleOnLeftCompactProperty);
        set => SetValue(IsVisibleOnLeftCompactProperty, value);
    }

    /// <summary>
    ///     Gets or set a value indicating whether the label shall be shown if the navigation view is on the top.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool IsVisibleOnTop
    {
        get => (bool)GetValue(IsVisibleOnTopProperty);
        set => SetValue(IsVisibleOnTopProperty, value);
    }
}