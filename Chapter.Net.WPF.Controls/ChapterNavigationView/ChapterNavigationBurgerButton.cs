// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationBurgerButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using Chapter.Net.WPF.Controls.Bases;
using System.Windows;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    public class ChapterNavigationBurgerButton : ToggleButtonBase
    {
        static ChapterNavigationBurgerButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationBurgerButton), new FrameworkPropertyMetadata(typeof(ChapterNavigationBurgerButton)));
        }
    }
}