// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterBadgeControl.xaml.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.CompilerServices;
using Chapter.Net.WPF.Controls;

// ReSharper disable once CheckNamespace

namespace Demo;

public partial class ChapterBadgeControl : INotifyPropertyChanged
{
    private string _content;
    private int _cornerRadius;
    private int _fontSize;
    private bool _hideOnZero;
    private double _horizontalAnchorOffset;
    private double _horizontalOffset;
    private int _minSize;
    private int _number;
    private BadgeShape _shape;
    private BadgeVariant _variant;
    private double _verticalAnchorOffset;
    private double _verticalOffset;

    public ChapterBadgeControl()
    {
        InitializeComponent();

        _shape = BadgeShape.Oval;
        _variant = BadgeVariant.Number;
        _minSize = 20;
        _cornerRadius = 6;
        _fontSize = 12;
        _number = 16;
        _content = "15335";
        _hideOnZero = false;
        _horizontalOffset = 1;
        _verticalOffset = 0;
        _horizontalAnchorOffset = 0.5;
        _verticalAnchorOffset = 0.5;

        DataContext = this;
    }

    public BadgeShape Shape
    {
        get => _shape;
        set => NotifyAndSet(ref _shape, value);
    }

    public BadgeVariant Variant
    {
        get => _variant;
        set => NotifyAndSet(ref _variant, value);
    }

    public int MinSize
    {
        get => _minSize;
        set => NotifyAndSet(ref _minSize, value);
    }

    public int CornerRadius
    {
        get => _cornerRadius;
        set => NotifyAndSet(ref _cornerRadius, value);
    }

    public int CustomFontSize
    {
        get => _fontSize;
        set => NotifyAndSet(ref _fontSize, value);
    }

    public int Number
    {
        get => _number;
        set => NotifyAndSet(ref _number, value);
    }

    public string CustomContent
    {
        get => _content;
        set => NotifyAndSet(ref _content, value);
    }

    public bool HideOnZero
    {
        get => _hideOnZero;
        set => NotifyAndSet(ref _hideOnZero, value);
    }

    public double HorizontalOffset
    {
        get => _horizontalOffset;
        set => NotifyAndSet(ref _horizontalOffset, value);
    }

    public double VerticalOffset
    {
        get => _verticalOffset;
        set => NotifyAndSet(ref _verticalOffset, value);
    }

    public double HorizontalAnchorOffset
    {
        get => _horizontalAnchorOffset;
        set => NotifyAndSet(ref _horizontalAnchorOffset, value);
    }

    public double VerticalAnchorOffset
    {
        get => _verticalAnchorOffset;
        set => NotifyAndSet(ref _verticalAnchorOffset, value);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyAndSet<T>(ref T backingField, T newValue, [CallerMemberName] string propertyName = null)
    {
        backingField = newValue;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}