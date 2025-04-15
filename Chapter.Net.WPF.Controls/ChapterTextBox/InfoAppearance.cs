// -----------------------------------------------------------------------------------------------------------------
// <copyright file="InfoAppearance.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines when the <see cref="ChapterTextBox.InfoText" /> in the <see cref="ChapterTextBox" /> and its derived
///     controls is visible.
/// </summary>
public enum InfoAppearance
{
    /// <summary>
    ///     No info text has to be shown.
    /// </summary>
    None,

    /// <summary>
    ///     The info text is shown when the box is empty, no matter if it has the keyboard focus or not.
    /// </summary>
    OnEmpty,

    /// <summary>
    ///     The info text is shown when the box is empty and does not have the keyboard focus.
    /// </summary>
    OnLostFocus
}