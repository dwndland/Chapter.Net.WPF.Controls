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

        Controls = new List<UserControl>
        {
            new ImageButtonControl("Buttons"),
            new OptionButtonControl("Buttons"),
            new SplitButtonControl("Buttons"),

            new ResizerControl("Docking"),

            new EnumerationComboBoxControl("Dropdowns"),

            new AdvancedTextBoxControl("Input"),
            new BrowseTextBoxControl("Input"),
            new NumberBoxControl("Input"),
            new PasswordBoxControl("Input"),
            new SearchTextBoxControl("Input"),
            new TimeBoxControl("Input"),
            
            new FormatterTextBlockControl("Labeling"),

            new HeaderItemsControlControl("Layouting"),
            new TitledItemsControlControl("Layouting"),

            new ExtendedTreeViewControl("Listing"),
            new TreeListViewControl("Listing"),
            new DynamicTabControlControl("Listing"),

            new ArcPanelControl("Panels"),
            new EllipsePanelControl("Panels"),
            new ItemsPanelControl("Panels"),
            new SpacingStackPanelControl("Panels"),
            new UniformPanelControl("Panels"),
            new UniformWrapPanelControl("Panels")
        };

        DataContext = this;
    }

    public List<UserControl> Controls { get; }
}