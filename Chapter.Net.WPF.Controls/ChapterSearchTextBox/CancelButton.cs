// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CancelButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     The button which calls the cancel command in the <see cref="ChapterSearchTextBox" />.
    /// </summary>
    public class CancelButton : Button
    {
        static CancelButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CancelButton), new FrameworkPropertyMetadata(typeof(CancelButton)));
        }
    }
}