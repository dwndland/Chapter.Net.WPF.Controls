// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTreeListViewExpander.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls.Primitives;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents the expander shown in the <see cref="ChapterTreeListView" /> to show or collapse child elements.
/// </summary>
public class ChapterTreeListViewExpander : ToggleButton
{
    /// <summary>
    ///     The ChapterTreeListViewExpander style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterTreeListViewExpander), "ChapterTreeListViewExpander");

    static ChapterTreeListViewExpander()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterTreeListViewExpander), new FrameworkPropertyMetadata(typeof(ChapterTreeListViewExpander)));
    }
}