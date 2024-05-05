// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTreeViewItem.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Enhances the <see cref="ChapterTreeViewItem" /> to be used in the <see cref="ChapterTreeView" />.
    /// </summary>
    public class ChapterTreeViewItem : TreeViewItem
    {
        internal static readonly RoutedEvent ContainerGeneratedEvent =
            EventManager.RegisterRoutedEvent("ContainerGenerated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChapterTreeViewItem));

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChapterTreeViewItem" /> class.
        /// </summary>
        public ChapterTreeViewItem()
        {
            DataContextChanged += (sender, args) => RaiseContainerGenerated();
            Loaded += (sender, args) => RaiseContainerGenerated();
        }

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

        private void RaiseContainerGenerated()
        {
            var newEventArgs = new RoutedEventArgs(ContainerGeneratedEvent);
            RaiseEvent(newEventArgs);
        }
    }
}