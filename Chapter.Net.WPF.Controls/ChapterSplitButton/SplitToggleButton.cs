// -----------------------------------------------------------------------------------------------------------------
// <copyright file="SplitToggleButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     The drop down toggle button placed in the <see cref="ChapterSplitButton" />.
/// </summary>
public class SplitToggleButton : ToggleButtonBase
{
    static SplitToggleButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitToggleButton), new FrameworkPropertyMetadata(typeof(SplitToggleButton)));
    }
}