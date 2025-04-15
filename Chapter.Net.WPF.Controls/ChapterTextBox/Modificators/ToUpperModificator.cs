// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ToUpperModificator.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Modifies the text to always upper in the <see cref="ChapterTextBox" />.
/// </summary>
public sealed class ToUpperModificator : TextModificator
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ToUpperModificator" /> class.
    /// </summary>
    public ToUpperModificator()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ToUpperModificator" /> class.
    /// </summary>
    /// <param name="modificationTime">The time when the <see cref="Modify" /> will be called.</param>
    public ToUpperModificator(ModificationTime modificationTime)
        : base(modificationTime)
    {
    }

    /// <inheritdoc />
    public override string Modify(string input)
    {
        return input.ToUpper(CultureInfo.CurrentCulture);
    }
}