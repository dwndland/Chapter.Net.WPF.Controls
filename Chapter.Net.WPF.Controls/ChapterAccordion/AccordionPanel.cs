// -----------------------------------------------------------------------------------------------------------------
// <copyright file="AccordionPanel.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     The panel measure and arrange the <see cref="ChapterAccordionItem" /> inside a <see cref="ChapterAccordion" />
///     depending on their expand state and accordion orientation.
/// </summary>
public class AccordionPanel : StackPanelBase
{
    /// <inheritdoc />
    protected override Size ArrangeOverride(Size arrangeSize)
    {
        var expandedChildren = InternalChildren.OfType<ChapterAccordionItem>().Where(x => x.IsExpanded).ToList();
        var collapsedChildren = InternalChildren.OfType<ChapterAccordionItem>().Where(x => !x.IsExpanded).ToList();

        if (Orientation == Orientation.Vertical)
        {
            var spaceForExpandedChildren = (arrangeSize.Height - collapsedChildren.Sum(x => x.DesiredSize.Height)) / expandedChildren.Count;

            var top = 0d;
            foreach (ChapterAccordionItem child in InternalChildren)
                if (child.IsExpanded)
                {
                    child.Arrange(new Rect(new Point(0, top), new Size(arrangeSize.Width, spaceForExpandedChildren)));
                    top += spaceForExpandedChildren;
                }
                else
                {
                    child.Arrange(new Rect(new Point(0, top), new Size(arrangeSize.Width, child.DesiredSize.Height)));
                    top += child.DesiredSize.Height;
                }
        }
        else
        {
            var spaceForExpandedChildren = (arrangeSize.Width - collapsedChildren.Sum(x => x.DesiredSize.Width)) / expandedChildren.Count;

            var left = 0d;
            foreach (ChapterAccordionItem child in InternalChildren)
                if (child.IsExpanded)
                {
                    child.Arrange(new Rect(new Point(left, 0), new Size(spaceForExpandedChildren, arrangeSize.Height)));
                    left += spaceForExpandedChildren;
                }
                else
                {
                    child.Arrange(new Rect(new Point(left, 0), new Size(child.DesiredSize.Width, arrangeSize.Height)));
                    left += child.DesiredSize.Width;
                }
        }

        return arrangeSize;
    }
}