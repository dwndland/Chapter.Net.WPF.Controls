// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendedTreeViewItem.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Enhances the <see cref="ExtendedTreeViewItem" /> to be used in the <see cref="ExtendedTreeView" />.
/// </summary>
public class ExtendedTreeViewItem : TreeViewItem
{
    internal static readonly RoutedEvent ContainerGeneratedEvent =
        EventManager.RegisterRoutedEvent("ContainerGenerated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ExtendedTreeViewItem));

    /// <summary>
    ///     Initializes a new instance of the <see cref="ExtendedTreeViewItem" /> class.
    /// </summary>
    public ExtendedTreeViewItem()
    {
        DataContextChanged += (sender, args) => RaiseContainerGenerated();
        Loaded += (sender, args) => RaiseContainerGenerated();
    }

    /// <summary>
    ///     Generates a new child item container to hold in the <see cref="ExtendedTreeViewItem" />.
    /// </summary>
    /// <returns>The generated child item container</returns>
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new ExtendedTreeViewItem();
    }

    /// <summary>
    ///     Checks if the item is already the correct item container. If not the <see cref="GetContainerForItemOverride" />
    ///     will be used to generate the right container.
    /// </summary>
    /// <param name="item">The item to shown in the <see cref="ExtendedTreeViewItem" />.</param>
    /// <returns>True if the item is the correct item container already.</returns>
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is ExtendedTreeViewItem;
    }

    private void RaiseContainerGenerated()
    {
        var newEventArgs = new RoutedEventArgs(ContainerGeneratedEvent);
        RaiseEvent(newEventArgs);
    }
}