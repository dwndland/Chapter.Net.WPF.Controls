// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterItemsPanelControl.xaml.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ChapterItemsPanelControl : INotifyPropertyChanged
{
    private bool _isUniform;

    public ChapterItemsPanelControl()
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

    public bool IsUniform
    {
        get => _isUniform;
        set
        {
            _isUniform = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsUniform)));
        }
    }

    public List<string> Items { get; }

    public event PropertyChangedEventHandler PropertyChanged;
}