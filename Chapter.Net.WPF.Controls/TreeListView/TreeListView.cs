﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TreeListView.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Shows a <see cref="TreeView" /> with the possibility to expand or collapse child elements shown in a GridView. The
///     expander can be placed in every column cell template.
/// </summary>
public class TreeListView : ExtendedTreeView
{
    /// <summary>
    ///     Identifies the View dependency property.
    /// </summary>
    public static readonly DependencyProperty ViewProperty =
        DependencyProperty.Register(nameof(View), typeof(GridView), typeof(TreeListView), new UIPropertyMetadata(null));

    static TreeListView()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListView), new FrameworkPropertyMetadata(typeof(TreeListView)));
    }

    /// <summary>
    ///     Gets or sets the <see cref="GridView" /> shown in the control.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public GridView View
    {
        get => (GridView)GetValue(ViewProperty);
        set => SetValue(ViewProperty, value);
    }

    /// <summary>
    ///     Generates a new child item container to hold in the <see cref="TreeListView" />.
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
    /// <param name="item">The item to shown in the <see cref="TreeListView" />.</param>
    /// <returns>True if the item is the correct item container already.</returns>
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is TreeListViewItem;
    }
}