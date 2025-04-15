// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTreeListViewExpander.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents the expander shown in the <see cref="ChapterTreeListView" /> to show or collapse child elements.
/// </summary>
public class ChapterTreeListViewExpander : ToggleButtonBase
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