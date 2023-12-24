// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TitledItemsControlControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class TitledItemsControlControl
{
    public TitledItemsControlControl(string group)
    {
        Group = group;
        InitializeComponent();
    }

    public string Group { get; }
}