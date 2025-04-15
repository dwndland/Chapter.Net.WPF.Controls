// -----------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;

// ReSharper disable once CheckNamespace

namespace Demo;

public class Item : INotifyPropertyChanged
{
    private bool _isSelected;

    public Item(string name)
    {
        Name = name;
        Items = new List<Item>();
    }

    public string Name { get; }

    public List<Item> Items { get; }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}