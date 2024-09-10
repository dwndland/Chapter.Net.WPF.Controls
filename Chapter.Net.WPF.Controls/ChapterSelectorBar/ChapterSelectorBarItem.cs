// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterSelectorBarItem.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A single entry within the <see cref="ChapterSelectorBar" />.
/// </summary>
public class ChapterSelectorBarItem : ListBoxItemBase
{
    /// <summary>
    ///     The ChapterSelectorBarItem style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterSelectorBarItem), "ChapterSelectorBarItem");

    static ChapterSelectorBarItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterSelectorBarItem), new FrameworkPropertyMetadata(typeof(ChapterSelectorBarItem)));
    }
}