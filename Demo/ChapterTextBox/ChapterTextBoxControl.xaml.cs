// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTextBoxControl.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ChapterTextBoxControl : INotifyPropertyChanged
{
    private bool _showFirstControl;
    private bool _showSecondControl;

    public ChapterTextBoxControl()
    {
        InitializeComponent();

        DataContext = this;
    }

    public bool ShowFirstControl
    {
        get => _showFirstControl;
        set
        {
            _showFirstControl = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowFirstControl)));
        }
    }

    public bool ShowSecondControl
    {
        get => _showSecondControl;
        set
        {
            _showSecondControl = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowSecondControl)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}