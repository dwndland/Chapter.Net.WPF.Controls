// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Windows.Controls;

namespace Demo;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();

        BasicInput =
        [
            new ControlItem("ChapterButton", new ChapterButtonControl()),
            new ControlItem("ChapterCheckBox", new ChapterCheckBoxControl()),
            new ControlItem("ChapterSplitButton", new ChapterSplitButtonControl()),
            new ControlItem("ChapterToggleButton", new ChapterToggleButtonControl()),
            new ControlItem("ChapterToggleSwitch", new ChapterToggleSwitchControl())
        ];

        Collections =
        [
            new ControlItem("ChapterComboBox", new ChapterComboBoxControl()),
            new ControlItem("ChapterTabControl", new ChapterTabControlControl()),
            new ControlItem("ChapterTreeListView", new ChapterTreeListViewControl()),
            new ControlItem("ChapterTreeView", new ChapterTreeViewControl())
        ];

        Text =
        [
            new ControlItem("ChapterBrowseTextBox", new ChapterBrowseTextBoxControl()),
            new ControlItem("ChapterNumberBox", new ChapterNumberBoxControl()),
            new ControlItem("ChapterPasswordBox", new ChapterPasswordBoxControl()),
            new ControlItem("ChapterSearchTextBox", new ChapterSearchTextBoxControl()),
            new ControlItem("ChapterTextBox", new ChapterTextBoxControl()),
            new ControlItem("ChapterTimeBox", new ChapterTimeBoxControl())
        ];

        Layout =
        [
            new ControlItem("ChapterArcPanel", new ChapterArcPanelControl()),
            new ControlItem("ChapterCard", new ChapterCardControl()),
            new ControlItem("ChapterEllipsePanel", new ChapterEllipsePanelControl()),
            new ControlItem("ChapterHeaderedContentControl", new ChapterHeaderedContentControlControl()),
            new ControlItem("ChapterResizer", new ChapterResizerControl()),
            new ControlItem("ChapterStackPanel", new ChapterStackPanelControl()),
            new ControlItem("ChapterTitledItemsControl", new ChapterTitledItemsControlControl()),
            new ControlItem("ChapterItemsPanel", new ChapterItemsPanelControl()),
            new ControlItem("ChapterUniformPanel", new ChapterUniformPanelControl()),
            new ControlItem("ChapterWrapPanel", new ChapterWrapPanelControl())
        ];

        StatusAndInfo =
        [
            new ControlItem("ChapterBadge", new ChapterBadgeControl())
        ];

        MenusAndToolBars =
        [
            new ControlItem("ChapterAccordion", new ChapterAccordionControl()),
            new ControlItem("ChapterNavigationView", new ChapterNavigationViewControl())
        ];

        DataContext = this;
    }

    public List<ControlItem> BasicInput { get; }
    public List<ControlItem> Collections { get; }
    public List<ControlItem> Text { get; }
    public List<ControlItem> Layout { get; }
    public List<ControlItem> StatusAndInfo { get; }
    public List<ControlItem> MenusAndToolBars { get; }
}

public class ControlItem
{
    public ControlItem(string title, UserControl control)
    {
        Title = title;
        Control = control;
    }

    public string Title { get; set; }
    public UserControl Control { get; set; }
}