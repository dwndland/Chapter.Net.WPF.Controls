// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterSelectorBar.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     An item bar like a more simple tab control.
/// </summary>
public class ChapterSelectorBar : ListBoxBase
{
    /// <summary>
    ///     The ChapterSelectorBar style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterSelectorBar), "ChapterSelectorBar");

    /// <summary>
    ///     The Orientation dependency property.
    /// </summary>
    public static readonly DependencyProperty OrientationProperty =
        DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(ChapterSelectorBar), new PropertyMetadata(Orientation.Horizontal));

    static ChapterSelectorBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterSelectorBar), new FrameworkPropertyMetadata(typeof(ChapterSelectorBar)));
    }

    /// <summary>
    ///     Gets or sets the orientation of bar.
    /// </summary>
    /// <value>Default: Orientation.Horizontal.</value>
    [DefaultValue(Orientation.Horizontal)]
    public Orientation Orientation
    {
        get => (Orientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    /// <inheritdoc />
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is ChapterSelectorBarItem;
    }

    /// <inheritdoc />
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new ChapterSelectorBarItem();
    }
}