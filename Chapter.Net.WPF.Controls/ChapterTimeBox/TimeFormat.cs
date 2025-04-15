// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TimeFormat.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines if the <see cref="ChapterTimeBox" /> contains a seconds box or not.
/// </summary>
public enum TimeFormat
{
    /// <summary>
    ///     The <see cref="ChapterTimeBox" /> contains hours, minutes and seconds.
    /// </summary>
    Long,

    /// <summary>
    ///     The <see cref="ChapterTimeBox" /> contains hours and minutes.
    /// </summary>
    Short
}