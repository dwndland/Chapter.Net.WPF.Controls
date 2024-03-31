// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberChangedEventArgs.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Holds the data passed when a <see cref="NumberBox" /> has changed its value.
    /// </summary>
    public sealed class NumberChangedEventArgs : RoutedEventArgs
    {
        internal NumberChangedEventArgs(object oldVal, object newVal)
            : base(NumberBox.NumberChangedEvent)
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
}