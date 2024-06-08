// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterHeaderedContentControl.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A headered content control with more possible customization and a footer.
/// </summary>
public class ChapterHeaderedContentControl : HeaderedContentControl
{
    /// <summary>
    ///     The ChapterBadge style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterHeaderedContentControl), "ChapterHeaderedContentControl");

    /// <summary>
    ///     A HeaderPosition dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderPositionProperty =
        DependencyProperty.Register(nameof(HeaderPosition), typeof(Dock), typeof(ChapterHeaderedContentControl), new PropertyMetadata(Dock.Top));

    /// <summary>
    ///     A HorizontalHeaderAlignment dependency property.
    /// </summary>
    public static readonly DependencyProperty HorizontalHeaderAlignmentProperty =
        DependencyProperty.Register(nameof(HorizontalHeaderAlignment), typeof(HorizontalAlignment), typeof(ChapterHeaderedContentControl), new PropertyMetadata(HorizontalAlignment.Left));

    /// <summary>
    ///     A VerticalHeaderAlignment dependency property.
    /// </summary>
    public static readonly DependencyProperty VerticalHeaderAlignmentProperty =
        DependencyProperty.Register(nameof(VerticalHeaderAlignment), typeof(VerticalAlignment), typeof(ChapterHeaderedContentControl), new PropertyMetadata(VerticalAlignment.Top));

    /// <summary>
    ///     A HeaderMargin dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderMarginProperty =
        DependencyProperty.Register(nameof(HeaderMargin), typeof(Thickness), typeof(ChapterHeaderedContentControl), new PropertyMetadata(new Thickness(0, 0, 0, 8)));

    /// <summary>
    ///     A FooterPosition dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterPositionProperty =
        DependencyProperty.Register(nameof(FooterPosition), typeof(Dock), typeof(ChapterHeaderedContentControl), new PropertyMetadata(Dock.Bottom));

    /// <summary>
    ///     A HorizontalFooterAlignment dependency property.
    /// </summary>
    public static readonly DependencyProperty HorizontalFooterAlignmentProperty =
        DependencyProperty.Register(nameof(HorizontalFooterAlignment), typeof(HorizontalAlignment), typeof(ChapterHeaderedContentControl), new PropertyMetadata(HorizontalAlignment.Left));

    /// <summary>
    ///     A VerticalFooterAlignment dependency property.
    /// </summary>
    public static readonly DependencyProperty VerticalFooterAlignmentProperty =
        DependencyProperty.Register(nameof(VerticalFooterAlignment), typeof(VerticalAlignment), typeof(ChapterHeaderedContentControl), new PropertyMetadata(VerticalAlignment.Top));

    /// <summary>
    ///     A FooterMargin dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterMarginProperty =
        DependencyProperty.Register(nameof(FooterMargin), typeof(Thickness), typeof(ChapterHeaderedContentControl), new PropertyMetadata(new Thickness(0)));

    /// <summary>
    ///     A FooterTemplateSelector dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterTemplateSelectorProperty =
        DependencyProperty.Register(nameof(FooterTemplateSelector), typeof(DataTemplateSelector), typeof(ChapterHeaderedContentControl), new PropertyMetadata(null));

    /// <summary>
    ///     A Footer dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterProperty =
        DependencyProperty.Register(nameof(Footer), typeof(object), typeof(ChapterHeaderedContentControl), new PropertyMetadata(default(object)));

    /// <summary>
    ///     A FooterStringFormat dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterStringFormatProperty =
        DependencyProperty.Register(nameof(FooterStringFormat), typeof(string), typeof(ChapterHeaderedContentControl), new PropertyMetadata(null));

    /// <summary>
    ///     A FooterTemplate dependency property.
    /// </summary>
    public static readonly DependencyProperty FooterTemplateProperty =
        DependencyProperty.Register(nameof(FooterTemplate), typeof(DataTemplate), typeof(ChapterHeaderedContentControl), new PropertyMetadata(null));

    static ChapterHeaderedContentControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterHeaderedContentControl), new FrameworkPropertyMetadata(typeof(ChapterHeaderedContentControl)));
    }

    /// <summary>
    ///     Gets or sets the header position.
    /// </summary>
    /// <value>Default: Dock.Top.</value>
    [DefaultValue(Dock.Top)]
    public Dock HeaderPosition
    {
        get => (Dock)GetValue(HeaderPositionProperty);
        set => SetValue(HeaderPositionProperty, value);
    }

    /// <summary>
    ///     Gets or sets the horizontal header alignment.
    /// </summary>
    /// <value>Default: HorizontalAlignment.Left.</value>
    [DefaultValue(HorizontalAlignment.Left)]
    public HorizontalAlignment HorizontalHeaderAlignment
    {
        get => (HorizontalAlignment)GetValue(HorizontalHeaderAlignmentProperty);
        set => SetValue(HorizontalHeaderAlignmentProperty, value);
    }

    /// <summary>
    ///     Gets or sets the vertical header alignment.
    /// </summary>
    /// <value>Default: VerticalAlignment.Top.</value>
    [DefaultValue(VerticalAlignment.Top)]
    public VerticalAlignment VerticalHeaderAlignment
    {
        get => (VerticalAlignment)GetValue(VerticalHeaderAlignmentProperty);
        set => SetValue(VerticalHeaderAlignmentProperty, value);
    }

    /// <summary>
    ///     Gets or sets header margin.
    /// </summary>
    /// <value>Default: 0,0,0,8.</value>
    public Thickness HeaderMargin
    {
        get => (Thickness)GetValue(HeaderMarginProperty);
        set => SetValue(HeaderMarginProperty, value);
    }

    /// <summary>
    ///     Gets or sets the footer position.
    /// </summary>
    /// <value>Default: Dock.Bottom.</value>
    [DefaultValue(Dock.Bottom)]
    public Dock FooterPosition
    {
        get => (Dock)GetValue(FooterPositionProperty);
        set => SetValue(FooterPositionProperty, value);
    }

    /// <summary>
    ///     Gets or sets horizontal footer alignment.
    /// </summary>
    /// <value>Default: HorizontalAlignment.Left.</value>
    [DefaultValue(HorizontalAlignment.Left)]
    public HorizontalAlignment HorizontalFooterAlignment
    {
        get => (HorizontalAlignment)GetValue(HorizontalFooterAlignmentProperty);
        set => SetValue(HorizontalFooterAlignmentProperty, value);
    }

    /// <summary>
    ///     Gets or sets vertical footer alignment.
    /// </summary>
    /// <value>Default: VerticalAlignment.Top.</value>
    [DefaultValue(VerticalAlignment.Top)]
    public VerticalAlignment VerticalFooterAlignment
    {
        get => (VerticalAlignment)GetValue(VerticalFooterAlignmentProperty);
        set => SetValue(VerticalFooterAlignmentProperty, value);
    }

    /// <summary>
    ///     Gets or sets footer margin.
    /// </summary>
    /// <value>Default: 0.</value>
    public Thickness FooterMargin
    {
        get => (Thickness)GetValue(FooterMarginProperty);
        set => SetValue(FooterMarginProperty, value);
    }

    /// <summary>
    ///     Gets or sets footer data template selector.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public DataTemplateSelector FooterTemplateSelector
    {
        get => (DataTemplateSelector)GetValue(FooterTemplateSelectorProperty);
        set => SetValue(FooterTemplateSelectorProperty, value);
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

    /// <summary>
    ///     Gets or sets the footer string format.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public string FooterStringFormat
    {
        get => (string)GetValue(FooterStringFormatProperty);
        set => SetValue(FooterStringFormatProperty, value);
    }

    /// <summary>
    ///     Gets or sets the footer data template.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public DataTemplate FooterTemplate
    {
        get => (DataTemplate)GetValue(FooterTemplateProperty);
        set => SetValue(FooterTemplateProperty, value);
    }
}