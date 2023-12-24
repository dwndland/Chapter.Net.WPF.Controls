// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CharInsertModificator.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Adjust the text in the <see cref="AdvancedTextBox" /> that it always contains a dash every N position.
/// </summary>
public sealed class CharInsertModificator : TextModificator
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CharInsertModificator" /> class.
    /// </summary>
    public CharInsertModificator()
    {
        Every = 6;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="CharInsertModificator" /> class.
    /// </summary>
    /// <param name="modificationTime">The time when the <see cref="Modify" /> will be called.</param>
    public CharInsertModificator(ModificationTime modificationTime)
        : base(modificationTime)
    {
        Every = 6;
    }

    /// <summary>
    ///     Gets or sets the repeat position on which the dash shall be inserted.
    /// </summary>
    /// <value>Default: 6.</value>
    [DefaultValue(6)]
    public int Every { get; set; }

    /// <summary>
    ///     Gets or sets the character to insert every N position.
    /// </summary>
    public char Character { get; set; }

    /// <inheritdoc />
    public override string Modify(string input)
    {
        for (var i = Every - 1; i < input.Length; i += Every)
            if (input[i] != Character)
                input = input.Insert(i++, Character.ToString());

        return input;
    }
}