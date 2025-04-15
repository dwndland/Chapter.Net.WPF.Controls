// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTreeViewItem.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Enhances the <see cref="ChapterTreeViewItem" /> to be used in the <see cref="ChapterTreeView" />.
/// </summary>
public class ChapterTreeViewItem : TreeViewItemBase
{
    internal static readonly RoutedEvent ContainerGeneratedEvent =
        EventManager.RegisterRoutedEvent("ContainerGenerated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChapterTreeViewItem));

    /// <summary>
    ///     Generates a new child item container to hold in the <see cref="ChapterTreeViewItem" />.
    /// </summary>
    /// <returns>The generated child item container</returns>
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new ChapterTreeViewItem();
    }

    /// <summary>
    ///     Checks if the item is already the correct item container. If not the <see cref="GetContainerForItemOverride" />
    ///     will be used to generate the right container.
    /// </summary>
    /// <param name="item">The item to shown in the <see cref="ChapterTreeViewItem" />.</param>
    /// <returns>True if the item is the correct item container already.</returns>
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is ChapterTreeViewItem;
    }

    /// <inheritdoc />
    protected override void OnLoaded(object sender, RoutedEventArgs e)
    {
        RaiseContainerGenerated();
    }

    /// <inheritdoc />
    protected override void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        RaiseContainerGenerated();
    }

    private void RaiseContainerGenerated()
    {
        var newEventArgs = new RoutedEventArgs(ContainerGeneratedEvent);
        RaiseEvent(newEventArgs);
    }
}