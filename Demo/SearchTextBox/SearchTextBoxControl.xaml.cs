// -----------------------------------------------------------------------------------------------------------------
// <copyright file="SearchTextBoxControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class SearchTextBoxControl
{
    public SearchTextBoxControl(string group)
    {
        Group = group;
        InitializeComponent();
    }

    public string Group { get; }

    private void OnSearchClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Search Clicked");
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Cancel Clicked");
    }
}