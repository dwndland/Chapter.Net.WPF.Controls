// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationBackButton.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A back button placed on the <see cref="ChapterNavigationView" />.
/// </summary>
public class ChapterNavigationBackButton : ButtonBase
{
    /// <summary>
    ///     The ChapterNavigationBackButton style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterNavigationBackButton), "ChapterNavigationBackButton");

    static ChapterNavigationBackButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationBackButton), new FrameworkPropertyMetadata(typeof(ChapterNavigationBackButton)));
    }
}