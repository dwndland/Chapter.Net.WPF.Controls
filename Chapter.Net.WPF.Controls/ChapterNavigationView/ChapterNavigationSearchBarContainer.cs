// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationSearchBarContainer.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A container to put a text box in within the <see cref="ChapterNavigationView" />.
/// </summary>
public class ChapterNavigationSearchBarContainer : ButtonBase
{
    /// <summary>
    ///     The ChapterNavigationSearchBarContainer style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterNavigationSearchBarContainer), "ChapterNavigationSearchBarContainer");

    /// <summary>
    ///     The IsDropDownOpen dependency property.
    /// </summary>
    public static readonly DependencyProperty IsDropDownOpenProperty =
        DependencyProperty.Register(nameof(IsDropDownOpen), typeof(bool), typeof(ChapterNavigationSearchBarContainer), new PropertyMetadata(false));

    /// <summary>
    ///     The IsExpanded dependency property.
    /// </summary>
    public static readonly DependencyProperty IsExpandedProperty =
        DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(ChapterNavigationSearchBarContainer), new PropertyMetadata(false));

    /// <summary>
    ///     The DisplayMode dependency property.
    /// </summary>
    public static readonly DependencyProperty DisplayModeProperty =
        DependencyProperty.Register(nameof(DisplayMode), typeof(NavigationDisplayMode), typeof(ChapterNavigationSearchBarContainer), new PropertyMetadata(NavigationDisplayMode.Left));

    static ChapterNavigationSearchBarContainer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationSearchBarContainer), new FrameworkPropertyMetadata(typeof(ChapterNavigationSearchBarContainer)));
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the item is an expanded popup.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool IsDropDownOpen
    {
        get => (bool)GetValue(IsDropDownOpenProperty);
        set => SetValue(IsDropDownOpenProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the item is an expanded panel.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    /// <summary>
    ///     Gets or sets the display mode in which the button is displayed in .
    /// </summary>
    /// <value>Default: NavigationDisplayMode.Left.</value>
    [DefaultValue(NavigationDisplayMode.Left)]
    public NavigationDisplayMode DisplayMode
    {
        get => (NavigationDisplayMode)GetValue(DisplayModeProperty);
        set => SetValue(DisplayModeProperty, value);
    }
}