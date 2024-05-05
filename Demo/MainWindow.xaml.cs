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
    private List<UserControl> _basicInput { get; }
    private List<UserControl> _collections { get; }
    private List<UserControl> _text { get; }
    private List<UserControl> _layout { get; }

    public MainWindow()
    {
        InitializeComponent();

        _basicInput =
        [
            new ImageButtonControl(),
            new OptionButtonControl(),
            new SplitButtonControl(),
            new EnumerationComboBoxControl()
        ];

        _collections =
        [
            new ExtendedTreeViewControl(),
            new TreeListViewControl(),
            new DynamicTabControlControl()
        ];

        _text =
        [
            new FormatterTextBlockControl(),
            new ChapterTextBoxControl(),
            new ChapterBrowseTextBoxControl(),
            new NumberBoxControl(),
            new PasswordBoxControl(),
            new SearchTextBoxControl(),
            new TimeBoxControl()
        ];

        _layout =
        [
            new ResizerControl(),
            new HeaderItemsControlControl(),
            new TitledItemsControlControl(),
            new ChapterArcPanelControl(),
            new EllipsePanelControl(),
            new ItemsPanelControl(),
            new SpacingStackPanelControl(),
            new UniformPanelControl(),
            new UniformWrapPanelControl()
        ];

        Controls = _basicInput;

        DataContext = this;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public List<UserControl> Controls { get; private set; }

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
        }

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Controls)));
    }
}