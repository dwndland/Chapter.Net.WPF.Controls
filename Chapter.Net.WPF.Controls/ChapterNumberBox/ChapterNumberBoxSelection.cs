// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNumberBoxSelection.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines how the automatic selection of the number in the <see cref="ChapterNumberBox" /> should behave.
/// </summary>
public enum ChapterNumberBoxSelection
{
    /// <summary>
    ///     No automatic selection will be done.
    /// </summary>
    None,

    /// <summary>
    ///     The number gets selected when the ChapterNumberBox got the focus.
    /// </summary>
    OnFocus,

    /// <summary>
    ///     The number will be selected when increment or decrement the value using arrow keys or up/down buttons.
    /// </summary>
    OnUpDown,

    /// <summary>
    ///     The number will be selected when the ChapterNumberBox got the focus or the value gets incremented or decremented
    ///     using the
    ///     arrow keys or up/down buttons.
    /// </summary>
    OnFocusAndUpDown
}