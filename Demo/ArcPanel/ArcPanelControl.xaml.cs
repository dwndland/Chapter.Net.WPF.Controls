// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ArcPanelControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ArcPanelControl
{
    public ArcPanelControl(string group)
    {
        Group = group;
        InitializeComponent();
    }

    public string Group { get; }
}