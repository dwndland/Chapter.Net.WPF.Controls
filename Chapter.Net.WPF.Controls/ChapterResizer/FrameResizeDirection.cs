// -----------------------------------------------------------------------------------------------------------------
// <copyright file="FrameResizeDirection.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines the direction for the <see cref="ChapterResizerFrame" />.
/// </summary>
public enum FrameResizeDirection
{
    /// <summary>
    ///     Resizes from the left to the right.
    /// </summary>
    LeftToRight,

    /// <summary>
    ///     Resizes from the top to the bottom.
    /// </summary>
    TopToBotom,

    /// <summary>
    ///     Resizes from the right to the left.
    /// </summary>
    RightToLeft,

    /// <summary>
    ///     Resizes from the bottom to the top.
    /// </summary>
    BottomToTop,

    /// <summary>
    ///     Resizes from the top left to the bottom right.
    /// </summary>
    TopLeftToBottomRight,

    /// <summary>
    ///     Resizes from the top right to the bottom left.
    /// </summary>
    TopRightToBottomLeft,

    /// <summary>
    ///     Resizes from the bottom right to the top left.
    /// </summary>
    BottomRightToTopLeft,

    /// <summary>
    ///     Resizes from the bottom left to the top right.
    /// </summary>
    BottomLeftToTopRight
}