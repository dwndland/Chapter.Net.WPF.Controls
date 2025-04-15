// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNavigationViewControl.xaml.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ChapterNavigationViewControl : INotifyPropertyChanged
{
    private object _selectedItem;

    public ChapterNavigationViewControl()
    {
        InitializeComponent();
        DataContext = this;
    }

    public object SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            SelectedItemString = _selectedItem?.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItemString)));
        }
    }

    public string SelectedItemString { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}