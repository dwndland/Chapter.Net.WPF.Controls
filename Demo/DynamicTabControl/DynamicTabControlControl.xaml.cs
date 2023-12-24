// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicTabControlControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class DynamicTabControlControl
{
    public DynamicTabControlControl(string group)
    {
        Group = group;
        InitializeComponent();
    }

    public string Group { get; }

    private void OnCloseClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Close Clicked");
    }

    private void OnAddClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Add Clicked");
    }
}