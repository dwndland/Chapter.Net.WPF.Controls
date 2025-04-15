// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DroppableTypes.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents what is possible to drop into the <see cref="ChapterTextBox" />.
/// </summary>
public enum DroppableTypes
{
    /// <summary>
    ///     Just one file can be dropped into the <see cref="ChapterTextBox" />.
    /// </summary>
    File,

    /// <summary>
    ///     Multiple files can be dropped into the <see cref="ChapterTextBox" />.
    /// </summary>
    Files,

    /// <summary>
    ///     Multiple files and folders can be dropped into the <see cref="ChapterTextBox" />.
    /// </summary>
    FilesFolders,

    /// <summary>
    ///     Multiple folders can be dropped into the <see cref="ChapterTextBox" />.
    /// </summary>
    Folders,

    /// <summary>
    ///     Just one folder can be dropped into the <see cref="ChapterTextBox" />.
    /// </summary>
    Folder,

    /// <summary>
    ///     Text can be dropped into the box.
    /// </summary>
    Text
}