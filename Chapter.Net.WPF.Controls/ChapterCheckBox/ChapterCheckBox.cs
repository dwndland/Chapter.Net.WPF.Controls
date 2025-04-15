// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterCheckBox.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A checkbox with additional features.
/// </summary>
public class ChapterCheckBox : CheckBoxBase
{
    /// <summary>
    ///     The ChapterCheckBox style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterCheckBox), "ChapterCheckBox");

    /// <summary>
    ///     The Header dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(object), typeof(ChapterCheckBox), new PropertyMetadata(null));

    /// <summary>
    ///     The Footer dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterProperty =
        DependencyProperty.Register(nameof(Footer), typeof(object), typeof(ChapterCheckBox), new PropertyMetadata(null));

    static ChapterCheckBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterCheckBox), new FrameworkPropertyMetadata(typeof(ChapterCheckBox)));
    }

    /// <summary>
    ///     Gets or sets the header.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    /// <summary>
    ///     Gets or sets the footer.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object Footer
    {
        get => GetValue(FooterProperty);
        set => SetValue(FooterProperty, value);
    }
}