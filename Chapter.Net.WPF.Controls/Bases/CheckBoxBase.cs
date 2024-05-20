// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CheckBoxBase.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Chapter.Net.WPF.Controls.Bases
{
    /// <summary>
    ///     Base class for checkboxes.
    /// </summary>
    public abstract class CheckBoxBase : CheckBox
    {
        /// <summary>
        ///     Create a new instance of CheckBoxBase.
        /// </summary>
        protected CheckBoxBase()
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