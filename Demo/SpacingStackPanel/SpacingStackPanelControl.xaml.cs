﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="SpacingStackPanelControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class SpacingStackPanelControl
{
    public SpacingStackPanelControl()
    {
        InitializeComponent();

        Items = new List<string>
        {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Fifth",
            "Sixth"
        };

        DataContext = this;
    }

    public List<string> Items { get; }
}