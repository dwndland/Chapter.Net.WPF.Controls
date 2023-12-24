// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DroppableTypes.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents what is possible to drop into the <see cref="AdvancedTextBox" />.
/// </summary>
public enum DroppableTypes
{
    /// <summary>
    ///     Just one file can be dropped into the <see cref="AdvancedTextBox" />.
    /// </summary>
    File,

    /// <summary>
    ///     Multiple files can be dropped into the <see cref="AdvancedTextBox" />.
    /// </summary>
    Files,

    /// <summary>
    ///     Multiple files and folders can be dropped into the <see cref="AdvancedTextBox" />.
    /// </summary>
    FilesFolders,

    /// <summary>
    ///     Multiple folders can be dropped into the <see cref="AdvancedTextBox" />.
    /// </summary>
    Folders,

    /// <summary>
    ///     Just one folder can be dropped into the <see cref="AdvancedTextBox" />.
    /// </summary>
    Folder,

    /// <summary>
    ///     Text can be dropped into the box.
    /// </summary>
    Text
}