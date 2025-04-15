// -----------------------------------------------------------------------------------------------------------------
// <copyright file="WhitespaceHandling.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines how to handle whitespaces in the <see cref="ChapterTextBox" />.
/// </summary>
public enum WhitespaceHandling
{
    /// <summary>
    ///     Nothing shall be done.
    /// </summary>
    None,

    /// <summary>
    ///     Disallow the user to enter whitespaces on the beginning and trims the end on focus lost.
    /// </summary>
    DisallowLeadingAndTrim,

    /// <summary>
    ///     Trims leading and trailing whitespace on focus lost.
    /// </summary>
    Trim
}