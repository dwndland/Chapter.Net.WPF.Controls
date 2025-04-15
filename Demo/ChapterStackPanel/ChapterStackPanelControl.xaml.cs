// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterStackPanelControl.xaml.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ChapterStackPanelControl
{
    public ChapterStackPanelControl()
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