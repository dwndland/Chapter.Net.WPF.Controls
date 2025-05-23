// -----------------------------------------------------------------------------------------------------------------
// <copyright file="UpDownBehavior.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines how the value in the <see cref="ChapterNumberBox" /> can incremented or decremented.
/// </summary>
public enum UpDownBehavior
{
    /// <summary>
    ///     The ChapterNumberBox doesn't have any up/down.
    /// </summary>
    None,

    /// <summary>
    ///     The value can incremented or decremented by the arrow keys only.
    /// </summary>
    Arrows,

    /// <summary>
    ///     The value can incremented or decremented by the up/down buttons only.
    /// </summary>
    Buttons,

    /// <summary>
    ///     The value can incremented or decremented by the arrow keys and up/down buttons.
    /// </summary>
    ArrowsAndButtons
}