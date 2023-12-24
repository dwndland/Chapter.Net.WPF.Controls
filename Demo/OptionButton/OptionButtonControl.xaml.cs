﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="OptionButtonControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class OptionButtonControl
{
    public OptionButtonControl(string group)
    {
        Group = group;
        InitializeComponent();
    }

    public string Group { get; }
}