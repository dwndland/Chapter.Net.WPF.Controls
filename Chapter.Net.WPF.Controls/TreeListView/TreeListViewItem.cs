// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TreeListViewItem.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents a single entry in the <see cref="TreeListView" />.
/// </summary>
public class TreeListViewItem : ExtendedTreeViewItem
{
    static TreeListViewItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewItem), new FrameworkPropertyMetadata(typeof(TreeListViewItem)));
    }

    /// <summary>
    ///     Returns the level of the current item in the tree.
    /// </summary>
    public int Level => VisualTreeAssist.GetParentsUntilCount<TreeListViewItem, TreeListView>(this);

    /// <summary>
    ///     Generates a new child item container to hold in the <see cref="TreeListViewItem" />.
    /// </summary>
    /// <returns>The generated child item container</returns>
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new TreeListViewItem();
    }

    /// <summary>
    ///     Checks if the item is already the correct item container. If not the <see cref="GetContainerForItemOverride" />
    ///     will be used to generate the right container.
    /// </summary>
    /// <param name="item">The item to shown in the <see cref="TreeListViewItem" />.</param>
    /// <returns>True if the item is the correct item container already.</returns>
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is TreeListViewItem;
    }
}