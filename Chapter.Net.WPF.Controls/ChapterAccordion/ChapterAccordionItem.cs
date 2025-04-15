// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterAccordionItem.cs" company="dwndland">
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
///     Represents a single expandable item inside the <see cref="ChapterAccordion" />.
/// </summary>
public class ChapterAccordionItem : ExpanderBase
{
    /// <summary>
    ///     The ChapterAccordionItem style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterAccordionItem), "ChapterAccordionItem");

    /// <summary>
    ///     The ExpandDirection dependency property.
    /// </summary>
    public new static readonly DependencyProperty ExpandDirectionProperty =
        DependencyProperty.Register(nameof(ExpandDirection), typeof(AccordionExpandDirection), typeof(ChapterAccordionItem), new PropertyMetadata(AccordionExpandDirection.Forward));

    /// <summary>
    ///     The Orientation dependency property.
    /// </summary>
    public static readonly DependencyProperty OrientationProperty =
        DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(ChapterAccordionItem), new PropertyMetadata(Orientation.Vertical));

    static ChapterAccordionItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterAccordionItem), new FrameworkPropertyMetadata(typeof(ChapterAccordionItem)));
    }

    /// <summary>
    ///     Gets or sets the direction how the <see cref="ChapterAccordionItem" /> shall expand.
    /// </summary>
    /// <value>Default: AccordionExpandDirection.Forward.</value>
    [DefaultValue(AccordionExpandDirection.Forward)]
    public new AccordionExpandDirection ExpandDirection
    {
        get => (AccordionExpandDirection)GetValue(ExpandDirectionProperty);
        set => SetValue(ExpandDirectionProperty, value);
    }

    /// <summary>
    ///     Gets or sets the orientation alignment of all items.
    /// </summary>
    /// <value>Default: Orientation.Vertical.</value>
    [DefaultValue(Orientation.Vertical)]
    public Orientation Orientation
    {
        get => (Orientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }
}