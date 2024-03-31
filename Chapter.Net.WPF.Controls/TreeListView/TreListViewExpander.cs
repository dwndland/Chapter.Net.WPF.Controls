// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TreListViewExpander.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls.Primitives;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Represents the expander shown in the <see cref="TreeListView" /> to show or collapse child elements.
    /// </summary>
    public class TreeListViewExpander : ToggleButton
    {
        static TreeListViewExpander()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewExpander), new FrameworkPropertyMetadata(typeof(TreeListViewExpander)));
        }
    }
}