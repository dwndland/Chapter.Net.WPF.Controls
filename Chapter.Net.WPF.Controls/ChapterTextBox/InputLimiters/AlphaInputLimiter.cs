// -----------------------------------------------------------------------------------------------------------------
// <copyright file="AlphaInputLimiter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Text.RegularExpressions;
using System.Windows.Input;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Allows only alpha input ([a-zA-Z ]) on a <see cref="ChapterTextBox" />.
/// </summary>
public sealed class AlphaInputLimiter : InputLimiter
{
    private readonly Regex _regex;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AlphaInputLimiter" /> class.
    /// </summary>
    public AlphaInputLimiter()
    {
        _regex = new Regex("^[a-zA-Z ]*$");
    }

    /// <inheritdoc />
    public override bool AcceptKey(Key key)
    {
        return true;
    }

    /// <inheritdoc />
    public override bool AcceptText(string input)
    {
        return _regex.IsMatch(input);
    }
}