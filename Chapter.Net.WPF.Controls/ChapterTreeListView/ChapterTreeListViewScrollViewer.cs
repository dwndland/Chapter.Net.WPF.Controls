// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTreeListViewScrollViewer.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents the scroll viewer shown in the <see cref="ChapterTreeListView" />.
/// </summary>
public sealed class ChapterTreeListViewScrollViewer : ScrollViewer
{
    static ChapterTreeListViewScrollViewer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterTreeListViewScrollViewer), new FrameworkPropertyMetadata(typeof(ChapterTreeListViewScrollViewer)));
    }
}