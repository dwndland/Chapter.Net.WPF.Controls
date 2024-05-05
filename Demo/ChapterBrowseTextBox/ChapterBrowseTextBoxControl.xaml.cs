// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterBrowseTextBoxControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ChapterBrowseTextBoxControl
{
    public ChapterBrowseTextBoxControl()
    {
        InitializeComponent();
    }

    private void OnBrowseClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Browse Clicked");
    }
}