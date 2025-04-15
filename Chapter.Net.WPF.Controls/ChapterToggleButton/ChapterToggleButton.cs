// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterToggleButton.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A toggle button which brings additional features like a header, footer and icon.
/// </summary>
[TemplatePart(Name = "PART_Border", Type = typeof(FrameworkElement))]
public class ChapterToggleButton : ToggleButtonBase
{
    /// <summary>
    ///     The ChapterToggleButton style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterToggleButton), "ChapterToggleButton");

    /// <summary>
    ///     The Header dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(object), typeof(ChapterToggleButton), new PropertyMetadata(null));

    /// <summary>
    ///     The Footer dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterProperty =
        DependencyProperty.Register(nameof(Footer), typeof(object), typeof(ChapterToggleButton), new PropertyMetadata(null));

    private FrameworkElement _border;

    static ChapterToggleButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterToggleButton), new FrameworkPropertyMetadata(typeof(ChapterToggleButton)));
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

    /// <inheritdoc />
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        _border = GetTemplateChild("PART_Border") as FrameworkElement;
    }

    /// <inheritdoc />
    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);

        if (_border is { ActualHeight: > 0 })
            OvalCornerRadius = new CornerRadius(_border.ActualHeight / 2);
    }
}