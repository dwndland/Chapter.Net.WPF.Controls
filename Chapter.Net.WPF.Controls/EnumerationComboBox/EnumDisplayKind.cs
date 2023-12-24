// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EnumDisplayKind.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines how the enum values in the <see cref="EnumerationComboBox" /> will be displayed.
/// </summary>
public enum EnumDisplayKind
{
    /// <summary>
    ///     The enum value will be display with just .ToString().
    /// </summary>
    ToString,

    /// <summary>
    ///     Displays the enumeration description attribute.
    /// </summary>
    Description,

    /// <summary>
    ///     The bound <see cref="EnumerationComboBox.ItemConverter" /> will be used to convert the value into the variable to
    ///     show.
    /// </summary>
    Converter,

    /// <summary>
    ///     The EnumerationComboBox.ItemTemplate will be set from outside of the control manually.
    /// </summary>
    Custom
}