// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberChangedEventHandler.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     The event handler for the <see cref="ChapterNumberBox.NumberChanged" /> event.
    /// </summary>
    /// <param name="sender">The corresponding ChapterNumberBox.</param>
    /// <param name="e">The object with the old and new number.</param>
    public delegate void NumberChangedEventHandler(object sender, NumberChangedEventArgs e);
}