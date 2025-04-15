// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTabControlControl.xaml.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ChapterTabControlControl
{
    public ChapterTabControlControl()
    {
        InitializeComponent();
    }

    private void OnCloseClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Close Clicked");
    }

    private void OnAddClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Add Clicked");
    }
}