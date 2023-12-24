// -----------------------------------------------------------------------------------------------------------------
// <copyright file="AlphaNumericInputLimiter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Text.RegularExpressions;
using System.Windows.Input;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Allows only numeric input ([a-zA-Z0-9 ]) on a <see cref="AdvancedTextBox" />.
/// </summary>
public sealed class AlphaNumericInputLimiter : InputLimiter
{
    private readonly Regex _regex;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AlphaNumericInputLimiter" /> class.
    /// </summary>
    public AlphaNumericInputLimiter()
    {
        _regex = new Regex(@"^[a-zA-Z0-9 ]*$");
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