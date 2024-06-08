// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BadgeVariant.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines the variant of the <see cref="ChapterBadge" />.
/// </summary>
public enum BadgeVariant
{
    /// <summary>
    ///     The block icon.
    /// </summary>
    Block,

    /// <summary>
    ///     The cancel icon.
    /// </summary>
    Cancel,

    /// <summary>
    ///     The checkmark icon.
    /// </summary>
    Check,

    /// <summary>
    ///     The custom content.
    /// </summary>
    Content,

    /// <summary>
    ///     The minus icon.
    /// </summary>
    Minus,

    /// <summary>
    ///     The number display.
    /// </summary>
    Number,

    /// <summary>
    ///     The plus icon.
    /// </summary>
    Plus,

    /// <summary>
    ///     The time icon.
    /// </summary>
    Time,

    /// <summary>
    ///     The warning icon.
    /// </summary>
    Warning
}