// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterControlHeaderPresenter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     A header presenter to display optional headers in the chapter controls.
    /// </summary>
    public class ChapterControlHeaderPresenter : ContentControlBase
    {
        /// <summary>
        ///     The ChapterControlHeaderPresenter style key.
        /// </summary>
        public static readonly ComponentResourceKey StyleKey = new ComponentResourceKey(typeof(ChapterControlHeaderPresenter), "ChapterControlHeaderPresenter");

        static ChapterControlHeaderPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterControlHeaderPresenter), new FrameworkPropertyMetadata(typeof(ChapterControlHeaderPresenter)));
        }
    }
}