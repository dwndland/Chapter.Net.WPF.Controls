// -----------------------------------------------------------------------------------------------------------------
// <copyright file="RoutedEventArgsBase.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;

namespace Chapter.Net.WPF.Controls.Bases;

/// <summary>
///     Base class for markup routed event args.
/// </summary>
public abstract class RoutedEventArgsBase : RoutedEventArgs
{
    /// <summary>
    ///     Create a new instance of RoutedEventArgsBase.
    /// </summary>
    /// <param name="routedEvent">The new value that the RoutedEvent Property is being set to </param>
    protected RoutedEventArgsBase(RoutedEvent routedEvent)
        : base(routedEvent)
    {
    }

    /// <summary>
    ///     Create a new instance of RoutedEventArgsBase.
    /// </summary>
    /// <param name="source">The new value that the SourceProperty is being set to </param>
    /// <param name="routedEvent">The new value that the RoutedEvent Property is being set to </param>
    protected RoutedEventArgsBase(RoutedEvent routedEvent, object source)
        : base(routedEvent, source)
    {
    }
}