// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ToLowerModificator.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Modifies the text to always lower in the <see cref="AdvancedTextBox" />.
/// </summary>
public sealed class ToLowerModificator : TextModificator
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ToUpperModificator" /> class.
    /// </summary>
    public ToLowerModificator()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ToUpperModificator" /> class.
    /// </summary>
    /// <param name="modificationTime">The time when the <see cref="Modify" /> will be called.</param>
    public ToLowerModificator(ModificationTime modificationTime)
        : base(modificationTime)
    {
    }

    /// <inheritdoc />
    public override string Modify(string input)
    {
        return input.ToLower(CultureInfo.CurrentCulture);
    }
}