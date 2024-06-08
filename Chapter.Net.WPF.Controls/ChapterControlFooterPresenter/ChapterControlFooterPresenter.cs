// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterControlFooterPresenter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A header presenter to display optional footer in the chapter controls.
/// </summary>
public class ChapterControlFooterPresenter : ContentControlBase
{
    /// <summary>
    ///     The ChapterControlFooterPresenter style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterControlFooterPresenter), "ChapterControlFooterPresenter");

    static ChapterControlFooterPresenter()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterControlFooterPresenter), new FrameworkPropertyMetadata(typeof(ChapterControlFooterPresenter)));
    }
}