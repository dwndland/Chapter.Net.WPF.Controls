// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ElementsRotateDirection.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Defines how the items should be rotated in the <see cref="EllipsePanel" />.
/// </summary>
public enum ElementsRotateDirection
{
    /// <summary>
    ///     The top of the items are oriented to the ellipse panel center point.
    /// </summary>
    Introversive,

    /// <summary>
    ///     The bottom of the items are oriented to the ellipse panel center point.
    /// </summary>
    Outroversive,

    /// <summary>
    ///     The items are oriented with the ellipse form clockwise.
    /// </summary>
    Clockwise,

    /// <summary>
    ///     The items are oriented with the ellipse form counter clockwise.
    /// </summary>
    Counterclockwise
}