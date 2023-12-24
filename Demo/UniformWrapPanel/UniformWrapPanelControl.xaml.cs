// -----------------------------------------------------------------------------------------------------------------
// <copyright file="UniformWrapPanelControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class UniformWrapPanelControl
{
    public UniformWrapPanelControl(string group)
    {
        Group = group;
        InitializeComponent();

        Items = new List<string>
        {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Fifth",
            "Sixth",
            "Seventh",
            "Eighth",
            "Ninth",
            "Tenth",
            "Eleventh",
            "Twelfth",
            "Thirteenth",
            "Fourteenth",
            "Fifteenth",
            "Sixteenth",
            "Seventeenth",
            "Eighteenth",
            "Nineteenth",
            "Twentieth"
        };

        DataContext = this;
    }

    public string Group { get; }

    public List<string> Items { get; }
}