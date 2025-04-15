// -----------------------------------------------------------------------------------------------------------------
// <copyright file="Element.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;

// ReSharper disable once CheckNamespace

namespace Demo;

public class Element : INotifyPropertyChanged
{
    private bool _isSelected;

    public Element(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Items = new List<Element>();
    }

    public string FirstName { get; }

    public string LastName { get; }

    public int Age { get; }

    public List<Element> Items { get; }

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