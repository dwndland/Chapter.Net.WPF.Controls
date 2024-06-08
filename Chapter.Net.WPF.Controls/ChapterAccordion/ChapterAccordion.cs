// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterAccordion.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     An accordion with sub items which can be expanded or collapsed.
/// </summary>
public class ChapterAccordion : ItemsControlBase
{
    /// <summary>
    ///     The ChapterAccordion style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterAccordion), "ChapterAccordion");

    /// <summary>
    ///     The AllowExpandMultiple dependency property.
    /// </summary>
    public static readonly DependencyProperty AllowExpandMultipleProperty =
        DependencyProperty.Register(nameof(AllowExpandMultiple), typeof(bool), typeof(ChapterAccordion), new PropertyMetadata(true));

    /// <summary>
    ///     The AllowCollapseAll dependency property.
    /// </summary>
    public static readonly DependencyProperty AllowCollapseAllProperty =
        DependencyProperty.Register(nameof(AllowCollapseAll), typeof(bool), typeof(ChapterAccordion), new PropertyMetadata(true));

    /// <summary>
    ///     The ExpandDirection dependency property.
    /// </summary>
    public static readonly DependencyProperty ExpandDirectionProperty =
        DependencyProperty.Register(nameof(ExpandDirection), typeof(AccordionExpandDirection), typeof(ChapterAccordion), new PropertyMetadata(AccordionExpandDirection.Forward));

    /// <summary>
    ///     The Orientation dependency property.
    /// </summary>
    public static readonly DependencyProperty OrientationProperty =
        DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(ChapterAccordion), new PropertyMetadata(Orientation.Vertical));

    static ChapterAccordion()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterAccordion), new FrameworkPropertyMetadata(typeof(ChapterAccordion)));
    }

    /// <summary>
    ///     Creates a new instance of ChapterAccordion.
    /// </summary>
    public ChapterAccordion()
    {
        AddHandler(Expander.ExpandedEvent, new RoutedEventHandler(OnItemExpanded));
        AddHandler(Expander.CollapsedEvent, new RoutedEventHandler(OnItemCollapsed));
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the accordion allows expanding of multiple items.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool AllowExpandMultiple
    {
        get => (bool)GetValue(AllowExpandMultipleProperty);
        set => SetValue(AllowExpandMultipleProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the accordion allows collapse of all items.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool AllowCollapseAll
    {
        get => (bool)GetValue(AllowCollapseAllProperty);
        set => SetValue(AllowCollapseAllProperty, value);
    }

    /// <summary>
    ///     Gets or sets the direction how the <see cref="ChapterAccordionItem" /> shall expand.
    /// </summary>
    /// <value>Default: AccordionExpandDirection.Forward.</value>
    [DefaultValue(AccordionExpandDirection.Forward)]
    public AccordionExpandDirection ExpandDirection
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

    /// <inheritdoc />
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is ChapterAccordionItem;
    }

    /// <inheritdoc />
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new ChapterAccordionItem();
    }

    private void OnItemExpanded(object sender, RoutedEventArgs e)
    {
        if (!AllowExpandMultiple && e.OriginalSource is ChapterAccordionItem item)
            CollapseAllOther(item);

        InvalidateMeasure();
    }

    private void OnItemCollapsed(object sender, RoutedEventArgs e)
    {
        if (!AllowCollapseAll && GetAllContainers().All(x => !x.IsExpanded) && e.OriginalSource is ChapterAccordionItem item)
            item.SetValue(Expander.IsExpandedProperty, true);

        InvalidateMeasure();
    }

    private void CollapseAllOther(ChapterAccordionItem sender)
    {
        foreach (var item in GetAllContainers().Except(new[] { sender }))
            item.SetValue(Expander.IsExpandedProperty, false);
    }

    private List<ChapterAccordionItem> GetAllContainers()
    {
        var items = new List<ChapterAccordionItem>();
        foreach (var item in Items)
        {
            var container = item as ChapterAccordionItem ?? ItemContainerGenerator.ContainerFromItem(item) as ChapterAccordionItem;
            if (container != null) items.Add(container);
        }

        return items;
    }
}