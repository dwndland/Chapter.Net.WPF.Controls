// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterCard.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A container control to crate card like groups of elements.
/// </summary>
public class ChapterCard : ContentControlBase
{
    /// <summary>
    ///     The ChapterButton style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterCard), "ChapterCard");

    static ChapterCard()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterCard), new FrameworkPropertyMetadata(typeof(ChapterCard)));
    }
}