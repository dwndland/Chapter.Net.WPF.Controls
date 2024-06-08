// -----------------------------------------------------------------------------------------------------------------
// <copyright file="AccordionExpandDirection.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines how the <see cref="ChapterAccordionItem" /> shall expand inside the <see cref="ChapterAccordion" />.
/// </summary>
public enum AccordionExpandDirection
{
    /// <summary>
    ///     The item shall expand down or right.
    /// </summary>
    Forward,

    /// <summary>
    ///     The item shall expand to the left or top
    /// </summary>
    Backward
}