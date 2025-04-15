// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberResetButton.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents the reset to default button shown in the <see cref="ChapterNumberBox" />.
/// </summary>
public class NumberResetButton : ButtonBase
{
    static NumberResetButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberResetButton), new FrameworkPropertyMetadata(typeof(NumberResetButton)));
    }
}