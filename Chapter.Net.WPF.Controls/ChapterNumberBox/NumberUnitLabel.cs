// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberUnitLabel.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents the currency symbol shown in the <see cref="ChapterNumberBox" />.
/// </summary>
public class NumberUnitLabel : LabelBase
{
    static NumberUnitLabel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberUnitLabel), new FrameworkPropertyMetadata(typeof(NumberUnitLabel)));
    }
}