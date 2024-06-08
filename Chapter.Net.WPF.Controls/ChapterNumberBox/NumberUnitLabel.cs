// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberUnitLabel.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents the currency symbol shown in the <see cref="ChapterNumberBox" />.
/// </summary>
public class NumberUnitLabel : Label
{
    static NumberUnitLabel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberUnitLabel), new FrameworkPropertyMetadata(typeof(NumberUnitLabel)));
    }
}