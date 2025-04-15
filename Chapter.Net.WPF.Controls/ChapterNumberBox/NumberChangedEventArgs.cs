// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberChangedEventArgs.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Holds the data passed when a <see cref="ChapterNumberBox" /> has changed its value.
/// </summary>
public sealed class NumberChangedEventArgs : RoutedEventArgsBase
{
    internal NumberChangedEventArgs(object oldVal, object newVal)
        : base(ChapterNumberBox.NumberChangedEvent)
    {
        OldNumber = oldVal;
        NewNumber = newVal;
    }

    /// <summary>
    ///     Gets the old number.
    /// </summary>
    public object OldNumber { get; }

    /// <summary>
    ///     Gets the new number
    /// </summary>
    public object NewNumber { get; }
}