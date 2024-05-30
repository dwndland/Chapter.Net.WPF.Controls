// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationBurgerButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     A burger button placed on the <see cref="ChapterNavigationView" />.
    /// </summary>
    public class ChapterNavigationBurgerButton : ToggleButtonBase
    {
        /// <summary>
        ///     The ChapterNavigationBurgerButton style key.
        /// </summary>
        public static readonly ComponentResourceKey StyleKey = new ComponentResourceKey(typeof(ChapterNavigationBurgerButton), "ChapterNavigationBurgerButton");

        static ChapterNavigationBurgerButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNavigationBurgerButton), new FrameworkPropertyMetadata(typeof(ChapterNavigationBurgerButton)));
        }
    }
}