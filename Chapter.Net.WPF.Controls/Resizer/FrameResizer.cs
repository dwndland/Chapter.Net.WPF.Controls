// -----------------------------------------------------------------------------------------------------------------
// <copyright file="FrameResizer.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents a single line to drag in a specific direction. This is used in the <see cref="Resizer" />.
/// </summary>
public class FrameResizer : Thumb
{
    /// <summary>
    ///     The Direction dependency property.
    /// </summary>
    public static readonly DependencyProperty DirectionProperty =
        DependencyProperty.Register(nameof(Direction), typeof(FrameResizeDirection), typeof(FrameResizer), new PropertyMetadata(FrameResizeDirection.LeftToRight));

    static FrameResizer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FrameResizer), new FrameworkPropertyMetadata(typeof(FrameResizer)));
    }

    /// <summary>
    ///     Defines in which direction the frame is resize to.
    /// </summary>
    /// <value>Default: FrameResizeDirection.LeftToRight.</value>
    [DefaultValue(FrameResizeDirection.LeftToRight)]
    public FrameResizeDirection Direction
    {
        get => (FrameResizeDirection)GetValue(DirectionProperty);
        set => SetValue(DirectionProperty, value);
    }
}