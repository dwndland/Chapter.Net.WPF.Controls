// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterSplitButtonControl.xaml.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ChapterSplitButtonControl
{
    public ChapterSplitButtonControl()
    {
        InitializeComponent();
    }

    private void MainClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Main Clicked");
    }

    private void FirstClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("First Clicked");
    }

    private void SecondClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Second Clicked");
    }

    private void ThirdClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Third Clicked");
    }

    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Build In Clicked");
    }
}