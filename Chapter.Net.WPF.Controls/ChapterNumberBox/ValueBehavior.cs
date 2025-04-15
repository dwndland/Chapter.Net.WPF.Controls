// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ValueBehavior.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines what the <see cref="ChapterNumberBox" /> should do when it lose the focus without a value (null).
/// </summary>
public enum ValueBehavior
{
    /// <summary>
    ///     Nothing should be done, the value stays on null.
    /// </summary>
    None,

    /// <summary>
    ///     The default number defined by <see cref="ChapterNumberBox.DefaultNumber" /> will be placed in.
    /// </summary>
    PlaceDefaultNumber,

    /// <summary>
    ///     The minimum value of the number type will be placed in.
    /// </summary>
    /// <remarks>For BigInteger there is no minimum, it stays on null.</remarks>
    PlaceMinimumNumber,

    /// <summary>
    ///     The maximum value of the number type will be placed in.
    /// </summary>
    /// <remarks>For BigInteger there is no maximum, it stays on null.</remarks>
    PlaceMaximumNumber
}