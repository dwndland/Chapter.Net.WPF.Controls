// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationBackButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using Chapter.Net.WPF.Controls.Bases;
using System.Windows;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    public class ChapterNavigationBackButton : ButtonBase
    {
        static ChapterNavigationBackButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationBackButton), new FrameworkPropertyMetadata(typeof(ChapterNavigationBackButton)));
        }
    }
}