// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterButtonControl.xaml.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ChapterToggleButtonControl : INotifyPropertyChanged
{
    private int _iconSize;

    public ChapterToggleButtonControl()
    {
        InitializeComponent();

        IconSize = 21;

        DataContext = this;
    }

    public int IconSize
    {
        get => _iconSize;
        set
        {
            _iconSize = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IconSize)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}