// -----------------------------------------------------------------------------------------------------------------
// <copyright file="SplitMainButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     The main button placed in the <see cref="ChapterSplitButton" />.
/// </summary>
public class SplitMainButton : ButtonBase
{
    static SplitMainButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitMainButton), new FrameworkPropertyMetadata(typeof(SplitMainButton)));
    }
}