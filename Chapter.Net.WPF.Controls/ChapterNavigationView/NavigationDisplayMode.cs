// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationDisplayMode.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     The mode how the <see cref="ChapterNavigationView" /> shall be displayed.
/// </summary>
public enum NavigationDisplayMode
{
    /// <summary>
    ///     The <see cref="ChapterNavigationView" /> shall be displayed left expanded.
    /// </summary>
    Left,

    /// <summary>
    ///     The <see cref="ChapterNavigationView" /> shall be displayed left in a compact bar.
    /// </summary>
    LeftCompact,

    /// <summary>
    ///     The <see cref="ChapterNavigationView" /> shall be displayed left with only a burger button overlaying the content.
    /// </summary>
    LeftMinimal,

    /// <summary>
    ///     The <see cref="ChapterNavigationView" /> shall be displayed as a top menu bar.
    /// </summary>
    Top,

    /// <summary>
    ///     The <see cref="ChapterNavigationView" /> shall switch automatically between Left, LeftCompact and LeftMinimal
    ///     depending on the control width.
    /// </summary>
    Auto
}