// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ModificationTime.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines when the <see cref="TextModificator" /> will be executed in the <see cref="AdvancedTextBox" />.
/// </summary>
public enum ModificationTime
{
    /// <summary>
    ///     The text will be modified when the text box loses the focus.
    /// </summary>
    OnLostFocus,

    /// <summary>
    ///     The text will be modified in the moment the user is typing.
    /// </summary>
    OnType
}