﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="AddButton.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents the add new tab Button shown in the <see cref="ChapterTabControl" />.
/// </summary>
public class AddButton : ButtonBase
{
    /// <summary>
    ///     The AddButton style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(AddButton), "AddButton");

    /// <summary>
    ///     Identifies the <see cref="StrokeThickness" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty StrokeThicknessProperty =
        DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(AddButton), new UIPropertyMetadata(1.5));

    static AddButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(AddButton), new FrameworkPropertyMetadata(typeof(AddButton)));
    }

    /// <summary>
    ///     Gets or sets the stroke thickness of the plus icon shown in the template.
    /// </summary>
    /// <value>Default: 1.5.</value>
    [DefaultValue(1.5)]
    public double StrokeThickness
    {
        get => (double)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }
}