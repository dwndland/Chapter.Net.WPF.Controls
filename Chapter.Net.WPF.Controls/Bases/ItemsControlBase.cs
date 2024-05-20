// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsControlBase.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Chapter.Net.WPF.Controls.Bases
{
    /// <summary>
    ///     Base class for items controls.
    /// </summary>
    public abstract class ItemsControlBase : ItemsControl
    {
        /// <summary>
        ///     Create a new instance of ItemsControlBase.
        /// </summary>
        protected ItemsControlBase()
        {
            Loaded += OnLoaded;
        }

        /// <summary>
        ///     Callback when the control got loaded.
        /// </summary>
        /// <param name="sender">The loaded checkbox.</param>
        /// <param name="e">The loaded event parameter.</param>
        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
        }
    }
}