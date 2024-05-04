// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendedTreeViewControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ExtendedTreeViewControl : INotifyPropertyChanged
{
    private Item _selectedItem;

    public ExtendedTreeViewControl()
    {
        InitializeComponent();

        Items = new List<Item>
        {
            new("Me"),
            new("Brother"),
            new("Sister")
        };

        Items[0].Items.Add(new Item("Mom"));
        Items[0].Items.Add(new Item("Dad"));

        Items[0].Items[1].Items.Add(new Item("Grandma"));
        Items[0].Items[1].Items.Add(new Item("Granddad"));

        FlatItems = new List<Item>
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

    public List<Item> Items { get; }

    public List<Item> FlatItems { get; }

    public Item SelectedItem
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