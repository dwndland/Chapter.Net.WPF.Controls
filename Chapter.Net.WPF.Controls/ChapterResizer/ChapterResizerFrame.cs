// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterResizerFrame.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents a single line to drag in a specific direction. This is used in the <see cref="ChapterResizer" />.
/// </summary>
public class ChapterResizerFrame : ThumbBase
{
    /// <summary>
    ///     The ChapterResizerFrame style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterResizerFrame), "ChapterResizerFrame");

    /// <summary>
    ///     The Direction dependency property.
    /// </summary>
    public static readonly DependencyProperty DirectionProperty =
        DependencyProperty.Register(nameof(Direction), typeof(FrameResizeDirection), typeof(ChapterResizerFrame), new PropertyMetadata(FrameResizeDirection.LeftToRight));

    static ChapterResizerFrame()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterResizerFrame), new FrameworkPropertyMetadata(typeof(ChapterResizerFrame)));
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