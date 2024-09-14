// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterTitledItem.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents a single line in the <see cref="ChapterTitledItemsControl" />.
/// </summary>
public class ChapterTitledItem : ContentControlBase
{
    /// <summary>
    ///     The ChapterTitledItem style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterTitledItem), "ChapterTitledItem");

    /// <summary>
    ///     The DependencyProperty for the Title VerticalTitleAlignments.
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(object), typeof(ChapterTitledItem), new UIPropertyMetadata(null));

    /// <summary>
    ///     The DependencyProperty for the VerticalTitleAlignment VerticalTitleAlignments.
    /// </summary>
    public static readonly DependencyProperty VerticalTitleAlignmentProperty =
        DependencyProperty.Register(nameof(VerticalTitleAlignment), typeof(VerticalAlignment), typeof(ChapterTitledItem), new UIPropertyMetadata(VerticalAlignment.Center));

    /// <summary>
    ///     The DependencyProperty for the HorizontalTitleAlignment VerticalTitleAlignments.
    /// </summary>
    public static readonly DependencyProperty HorizontalTitleAlignmentProperty =
        DependencyProperty.Register(nameof(HorizontalTitleAlignment), typeof(HorizontalAlignment), typeof(ChapterTitledItem), new UIPropertyMetadata(HorizontalAlignment.Left));

    /// <summary>
    ///     The DependencyProperty for the TitleMargin VerticalTitleAlignments.
    /// </summary>
    public static readonly DependencyProperty TitleMarginProperty =
        DependencyProperty.Register(nameof(TitleMargin), typeof(Thickness), typeof(ChapterTitledItem), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

    /// <summary>
    ///     The DependencyProperty for the ContentMargin VerticalTitleAlignments.
    /// </summary>
    public static readonly DependencyProperty ContentMarginProperty =
        DependencyProperty.Register(nameof(ContentMargin), typeof(Thickness), typeof(ChapterTitledItem), new UIPropertyMetadata(new Thickness(0, 2, 0, 2)));

    static ChapterTitledItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterTitledItem), new FrameworkPropertyMetadata(typeof(ChapterTitledItem)));
    }

    /// <summary>
    ///     Gets or sets the title of the row.
    /// </summary>
    /// <remarks>Default: null</remarks>
    [DefaultValue(null)]
    public object Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    ///     Gets or sets the VerticalAlignment of the title.
    /// </summary>
    /// <remarks>Default: VerticalAlignment.Center</remarks>
    [DefaultValue(VerticalAlignment.Center)]
    public VerticalAlignment VerticalTitleAlignment
    {
        get => (VerticalAlignment)GetValue(VerticalTitleAlignmentProperty);
        set => SetValue(VerticalTitleAlignmentProperty, value);
    }

    /// <summary>
    ///     Gets or sets the HorizontalAlignment of the title.
    /// </summary>
    /// <remarks>Default: HorizontalAlignment.Left</remarks>
    [DefaultValue(HorizontalAlignment.Left)]
    public HorizontalAlignment HorizontalTitleAlignment
    {
        get => (HorizontalAlignment)GetValue(HorizontalTitleAlignmentProperty);
        set => SetValue(HorizontalTitleAlignmentProperty, value);
    }

    /// <summary>
    ///     Gets or sets the margin of the title.
    /// </summary>
    /// <remarks>Default: new Thickness(5, 0, 5, 0)</remarks>
    public Thickness TitleMargin
    {
        get => (Thickness)GetValue(TitleMarginProperty);
        set => SetValue(TitleMarginProperty, value);
    }

    /// <summary>
    ///     Gets or sets the margin of the content.
    /// </summary>
    /// <remarks>Default: new Thickness(0, 2, 0, 2)</remarks>
    public Thickness ContentMargin
    {
        get => (Thickness)GetValue(ContentMarginProperty);
        set => SetValue(ContentMarginProperty, value);
    }
}