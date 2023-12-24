// -----------------------------------------------------------------------------------------------------------------
// <copyright file="FormatterTextBlockControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class FormatterTextBlockControl : INotifyPropertyChanged
{
    private string _input;

    public FormatterTextBlockControl(string group)
    {
        Group = group;
        InitializeComponent();

        Input = "example";
        DataContext = this;
    }

    public string Group { get; }

    public string Input
    {
        get => _input;
        set
        {
            _input = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Input)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}