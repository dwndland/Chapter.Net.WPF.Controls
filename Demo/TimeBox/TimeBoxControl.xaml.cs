﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TimeBoxControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class TimeBoxControl
{
    public TimeBoxControl(string group)
    {
        Group = group;
        InitializeComponent();
    }

    public string Group { get; }
}