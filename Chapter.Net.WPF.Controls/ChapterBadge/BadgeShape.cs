// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BadgeShape.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines the shape of the <see cref="ChapterBadge" />.
/// </summary>
public enum BadgeShape
{
    /// <summary>
    ///     A circle shape.
    /// </summary>
    Circle,

    /// <summary>
    ///     A diamond shape.
    /// </summary>
    Diamond,

    /// <summary>
    ///     A heart shape.
    /// </summary>
    Heart,

    /// <summary>
    ///     No shape, only the content.
    /// </summary>
    None,

    /// <summary>
    ///     A oval shape.
    /// </summary>
    Oval,

    /// <summary>
    ///     A polygon with 5 sides.
    /// </summary>
    Polygon5,

    /// <summary>
    ///     A polygon with 6 sides.
    /// </summary>
    Polygon6,

    /// <summary>
    ///     A polygon with 7 sides.
    /// </summary>
    Polygon7,

    /// <summary>
    ///     A polygon with 8 sides.
    /// </summary>
    Polygon8,

    /// <summary>
    ///     A square shape.
    /// </summary>
    Square,

    /// <summary>
    ///     A star shape.
    /// </summary>
    Star,

    /// <summary>
    ///     A triangle shape.
    /// </summary>
    Triangle,

    /// <summary>
    ///     A triangle for a bottom left elbow.
    /// </summary>
    TriangleBottomLeft,

    /// <summary>
    ///     A triangle for a bottom right elbow.
    /// </summary>
    TriangleBottomRight,

    /// <summary>
    ///     A triangle for a top left elbow.
    /// </summary>
    TriangleTopLeft,

    /// <summary>
    ///     A triangle for a top right elbow.
    /// </summary>
    TriangleTopRight
}