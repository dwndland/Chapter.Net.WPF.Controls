// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TreeListViewControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class TreeListViewControl : INotifyPropertyChanged
{
    private Element _selectedItem;

    public TreeListViewControl(string group)
    {
        Group = group;
        InitializeComponent();

        Items = new List<Element>
        {
            new("John", "Smith", 24),
            new("Michael ", "Smith", 22),
            new("Emily", "Smith", 18)
        };

        Items[0].Items.Add(new Element("Sarah", "Johnson", 44));
        Items[0].Items.Add(new Element("Christopher", "Johnson", 46));

        Items[0].Items[1].Items.Add(new Element("Jessica", "Brown", 66));
        Items[0].Items[1].Items.Add(new Element("David ", "Brown", 67));

        FlatItems = new List<Element>
        {
            Items[0],
            Items[0].Items[0],
            Items[0].Items[1],
            Items[0].Items[1].Items[0],
            Items[0].Items[1].Items[1],
            Items[1],
            Items[2]
        };

        DataContext = this;
    }

    public string Group { get; }

    public List<Element> Items { get; }

    public List<Element> FlatItems { get; }

    public Element SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}