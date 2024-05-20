// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace Demo;

public partial class MainWindow : INotifyPropertyChanged
{
    public MainWindow()
    {
        InitializeComponent();

        _basicInput =
        [
            new ChapterButtonControl(),
            new ChapterCheckBoxControl(),
            new ChapterSplitButtonControl(),
            new ChapterToggleSwitchControl()
        ];

        _collections =
        [
            new ChapterComboBoxControl(),
            new ChapterTabControlControl(),
            new ChapterTreeListViewControl(),
            new ChapterTreeViewControl()
        ];

        _text =
        [
            new ChapterBrowseTextBoxControl(),
            new ChapterNumberBoxControl(),
            new ChapterPasswordBoxControl(),
            new ChapterSearchTextBoxControl(),
            new ChapterTextBoxControl(),
            new ChapterTimeBoxControl()
        ];

        _layout =
        [
            new ChapterArcPanelControl(),
            new ChapterCardControl(),
            new ChapterEllipsePanelControl(),
            new ChapterHeaderedContentControlControl(),
            new ChapterResizerControl(),
            new ChapterStackPanelControl(),
            new ChapterTitledItemsControlControl(),
            new ChapterItemsPanelControl(),
            new ChapterUniformPanelControl(),
            new ChapterWrapPanelControl()
        ];

        _statusAndInfo =
        [
            new ChapterBadgeControl()
        ];

        _menusAndToolBars =
        [
            new ChapterAccordionControl()
        ];

        Controls = _basicInput;

        DataContext = this;
    }

    private List<UserControl> _basicInput { get; }
    private List<UserControl> _collections { get; }
    private List<UserControl> _text { get; }
    private List<UserControl> _layout { get; }
    private List<UserControl> _statusAndInfo { get; }
    private List<UserControl> _menusAndToolBars { get; }

    public List<UserControl> Controls { get; private set; }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnGroupChanged(object sender, SelectionChangedEventArgs e)
    {
        var box = (ListBox)sender;
        var item = (ListBoxItem)box.SelectedItem;

        switch (item.Name)
        {
            case "BasicInput":
                Controls = _basicInput;
                break;
            case "Collections":
                Controls = _collections;
                break;
            case "Text":
                Controls = _text;
                break;
            case "Layout":
                Controls = _layout;
                break;
            case "StatusAndInfo":
                Controls = _statusAndInfo;
                break;
            case "MenusAndToolBars":
                Controls = _menusAndToolBars;
                break;
        }

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Controls)));
    }
}