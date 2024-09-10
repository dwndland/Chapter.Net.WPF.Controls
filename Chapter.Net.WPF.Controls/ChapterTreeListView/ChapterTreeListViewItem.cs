// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTreeListViewItem.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents a single entry in the <see cref="ChapterTreeListView" />.
/// </summary>
public class ChapterTreeListViewItem : ChapterTreeViewItem
{
    /// <summary>
    ///     The ChapterTreeListViewItem style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterTreeListViewItem), "ChapterTreeListViewItem");

    static ChapterTreeListViewItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterTreeListViewItem), new FrameworkPropertyMetadata(typeof(ChapterTreeListViewItem)));
    }

    /// <summary>
    ///     Returns the level of the current item in the tree.
    /// </summary>
    public int Level => VisualTreeAssist.GetParentsUntilCount<ChapterTreeListViewItem, ChapterTreeListView>(this);

    /// <summary>
    ///     Generates a new child item container to hold in the <see cref="ChapterTreeListViewItem" />.
    /// </summary>
    /// <returns>The generated child item container</returns>
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new ChapterTreeListViewItem();
    }

    /// <summary>
    ///     Checks if the item is already the correct item container. If not the <see cref="GetContainerForItemOverride" />
    ///     will be used to generate the right container.
    /// </summary>
    /// <param name="item">The item to shown in the <see cref="ChapterTreeListViewItem" />.</param>
    /// <returns>True if the item is the correct item container already.</returns>
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is ChapterTreeListViewItem;
    }
}