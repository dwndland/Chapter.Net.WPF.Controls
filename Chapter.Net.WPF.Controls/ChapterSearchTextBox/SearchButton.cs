// -----------------------------------------------------------------------------------------------------------------
// <copyright file="SearchButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     The button which calls the search command in the <see cref="ChapterSearchTextBox" />.
/// </summary>
public class SearchButton : Button
{
    /// <summary>
    ///     The SearchButton style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(SearchButton), "SearchButton");

    static SearchButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchButton), new FrameworkPropertyMetadata(typeof(SearchButton)));
    }
}