// -----------------------------------------------------------------------------------------------------------------
// <copyright file="InputLimiter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows.Input;
using System.Windows.Markup;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Allows or disallows user inputs on a <see cref="AdvancedTextBox" />.
/// </summary>
public abstract class InputLimiter : MarkupExtension
{
    /// <summary>
    ///     Checks if the given key can be input.
    /// </summary>
    /// <param name="key">The key the user pressed.</param>
    /// <returns>True if the key press is allowed; otherwise false.</returns>
    public abstract bool AcceptKey(Key key);

    /// <summary>
    ///     Checks if the given text is allowed.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public abstract bool AcceptText(string input);

    /// <summary>
    ///     Provides the TextModificator.
    /// </summary>
    /// <param name="serviceProvider">Unused.</param>
    /// <returns>The current text modificator.</returns>
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}