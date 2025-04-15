// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterSearchTextBoxControl.xaml.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ChapterSearchTextBoxControl
{
    public ChapterSearchTextBoxControl()
    {
        InitializeComponent();
    }

    private void OnSearchClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Search Clicked");
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Cancel Clicked");
    }
}