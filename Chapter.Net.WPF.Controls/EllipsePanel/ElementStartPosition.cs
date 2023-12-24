// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ElementStartPosition.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines the position where the elements has to start in the <see cref="EllipsePanel" />.
/// </summary>
public enum ElementStartPosition
{
    /// <summary>
    ///     The first item in the ellipse panel is starting on the left side.
    /// </summary>
    Left,

    /// <summary>
    ///     The first item in the ellipse panel is starting on top.
    /// </summary>
    Top,

    /// <summary>
    ///     The first item in the ellipse panel is starting on the right side.
    /// </summary>
    Right,

    /// <summary>
    ///     The first item in the ellipse panel is starting on bottom.
    /// </summary>
    Bottom
}