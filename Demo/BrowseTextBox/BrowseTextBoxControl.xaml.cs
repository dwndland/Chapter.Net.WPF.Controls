// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BrowseTextBoxControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class BrowseTextBoxControl
{
    public BrowseTextBoxControl(string group)
    {
        Group = group;
        InitializeComponent();
    }

    public string Group { get; }

    private void OnBrowseClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Browse Clicked");
    }
}