// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterHeaderedContentControl.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A headered content control with more possible customization and a footer.
/// </summary>
public class ChapterHeaderedContentControl : HeaderedContentControlBase
{
    /// <summary>
    ///     The ChapterBadge style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterHeaderedContentControl), "ChapterHeaderedContentControl");

    /// <summary>
    ///     A Footer dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterProperty =
        DependencyProperty.Register(nameof(Footer), typeof(object), typeof(ChapterHeaderedContentControl), new PropertyMetadata(default(object)));

    static ChapterHeaderedContentControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterHeaderedContentControl), new FrameworkPropertyMetadata(typeof(ChapterHeaderedContentControl)));
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