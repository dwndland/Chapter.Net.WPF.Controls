// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TreeListViewScrollViewer.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Represents the scroll viewer shown in the <see cref="TreeListView" />.
    /// </summary>
    public sealed class TreeListViewScrollViewer : ScrollViewer
    {
        static TreeListViewScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewScrollViewer), new FrameworkPropertyMetadata(typeof(TreeListViewScrollViewer)));
        }
    }
}