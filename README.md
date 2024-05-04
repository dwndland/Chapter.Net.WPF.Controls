<img src="https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Icon.png" alt="logo" width="64"/>

# Chapter.Net.WPF.Controls Library

## Overview
A set of new WPF controls which are not yet build in.

## Features
- **ChapterTextBox:** Enhances the WPF TextBox by the possibilities to show background text, drop files and folders and place additional controls in.
- **ArcPanel:** Arranges child elements in an arc form.
- **BrowseTextBox:** Adds a browse button to the ChapterTextBox.
- **DynamicTabControl:** Enhances the TabControl with buttons for add new tab item and close buttons of existing tab items.
- **EllipsePanel:** Arranges child elements in a configurable ellipse form.
- **EnumerationComboBox:** Represents a ComboBox which takes an enumeration value and shows all possible states inside the dropdown menu for let choosing a value.
- **ExtendedTreeView:** Enhances ExtendedTreeView multi select, select an item by right click on it and a two way bindable SelectedItem.
- **FormatterTextBlock:** Formats the given translation.
- **HeaderItemsControl:** Provides the possibility to automatically align Headers and contents.
- **ImageButton:** Enhances the WPF Button to show an disabled image. The bound image will be shown monochrome if the button is disabled.
- **ItemsPanel:** A UniformGrid with only one row or one column, depending on the orientation, which adds a spacing between the items.
- **NumberBox:** Displays a TextBox to accept numeric values only, so the text can be bound to a numeric property directly without converting.
- **OptionButton:** A custom checkbox where a slider shows the checked and unchecked state.
- **PasswordBox:** Hosts and enhances the WPF PasswordBox to be able to bind the password value and show info text in the background.
- **Resizer:** Brings the possibility to resize every UI control manually by hold and drag the corners or sides.
- **SearchTextBox:** Adds search and cancel buttons to the ChapterTextBox to represent a search box shown like in the Windows explorer.
- **SpacingStackPanel:** A StackPanel which adds a spacing between the items.
- **SplitButton:** A button with a drop down where more commands can be available.
- **TimeBox:** Shows textboxes to let the user input a time.
- **TitledItemsControl:** Provides the possibility to automatically align titles and contents.
- **TreeListView:** Shows a TreeView with the possibility to expand or collapse child elements shown in a GridView. The expander can be placed in every column cell template.
- **UniformPanel:** A UniformGrid with only one row or one column, depending on the orientation, which adds a spacing between the items.
- **UniformWrapPanel:** Enhances the WrapPanel by the feature that all items will have the same size.

## Getting Started

1. **Installation:**
    - Install the Chapter.Net.WPF.Controls library via NuGet Package Manager:
    ```bash
    dotnet add package Chapter.Net.WPF.Controls
    ```

2. **ChapterTextBox:**
    - Usage
    ```xaml
    <chapter:ChapterTextBox InfoText="Required"
                            AllowedDropType="Files"
                            Separator=";"
                            WhitespaceHandling="Trim"
                            InputLimiter="{controls:AlphaInputLimiter}"
                            TextModificator="{controls:ToUpperModificator OnLostFocus}" />
    ```
    ![ChapterTextBox](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/ChapterTextBox.png)

3. **ArcPanel:**
    - Usage
    ```xaml
    <ItemsControl ItemsSource="{Binding Cards}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <chapter:ArcPanel Width="210" Height="100" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
    </ItemsControl>

    <chapter:ArcPanel Width="300" Height="100">
        <Button Content="One" />
        <Button Content="Two" />
        <Button Content="Three" />
        <Button Content="Four" />
    </chapter:ArcPanel>
    ```
    ![ArcPanel](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/ArcPanel.png)

4. **BrowseTextBox:**
    - Usage
    ```xaml
    <chapter:BrowseTextBox ShowBrowseButton="True"
                           BrowseCommand="{Binding BrowseCommand}" />
    ```
    ![BrowseTextBox](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/BrowseTextBox.png)

5. **DynamicTabControl:**
    - Usage
    ```xaml
    <chapter:DynamicTabControl ShowAddButton="True"
                               TabItemAddingCommand="{Binding AddItemCommand}"
                               TabItemClosingCommand="{Binding RemoveItemCommand}" />
    ```
    ![DynamicTabControl](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/DynamicTabControl.png)

6. **EllipsePanel:**
    - Usage
    ```xaml
    <ItemsControl ItemsSource="{Binding Player}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <chapter:EllipsePanel ElementStartPosition="Bottom"
                                       EllipseRotateDirection="Clockwise"
                                       ElementsRotateDirection="Outroversive"
                                       RotateElements="True" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
    </ItemsControl>

    <chapter:EllipsePanel>
        <Button Content="One" />
        <Button Content="Two" />
        <Button Content="Three" />
        <Button Content="Four" />
    </chapter:EllipsePanel>
    ```
    ![EllipsePanel](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/EllipsePanel.png)

7. **EnumerationComboBox:**
    - Usage
    ```csharp
    public enum Number
    {
        [Description("The Number One")]
        One,

        [Description("The Number Two")]
        Two,

        [Description("The Number Three")]
        Three
    }

    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Number = Number.One;
        }

        public Number Number
        {
            get { return _number; }
            set
            {
                _number = value;
                NotifyPropertyChanged("Number");
            }
        }
        private Number _number;
    }
    ```
    ```xaml
    <!-- The items will be shown like "Name: One; Description: The Number One". -->
    <!-- (The EnumDescriptionConverter will return the description value unchanged) -->
    <!-- DisplayKind is not set so the default will be taken which is EnumDisplayKind.Custom -->
    <chapter:EnumerationComboBox EnumType="{x:Type Demo:Number}" SelectedItem="{Binding Number}">
        <chapter:EnumerationComboBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="Name: " />
                    <TextBlock Text="{Binding }" />
                    <TextBlock Text="; Description: " />
                    <TextBlock Text="{Binding Converter={StaticResource EnumDescriptionConverter}}" />
                </StackPanel>
            </DataTemplate>
        </chapter:EnumerationComboBox.ItemTemplate>
    </chapter:EnumerationComboBox>
    
    <!-- The items will be shown like "The Number One". -->
    <chapter:EnumerationComboBox EnumType="{x:Type Demo:Number}" SelectedItem="{Binding Number}" DisplayKind="Description" />

    <!-- The items will be shown like "One". -->    
    <chapter:EnumerationComboBox EnumType="{x:Type Demo:Number}" SelectedItem="{Binding Number}" DisplayKind="ToString" />
    
    <!-- The items will be shown how you defined in the EnumToStringConverter. -->
    <chapter:EnumerationComboBox EnumType="{x:Type Demo:Number}" SelectedItem="{Binding Number}" DisplayKind="Converter" ItemConverter="{StaticResource EnumToStringConverter}" />
    ```
    ![EnumerationComboBox](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/EnumerationComboBox.png)

8. **ExtendedTreeView:**
    - Usage
    ```xaml
    <chapter:ExtendedTreeView ItemsSource="{Binding Folders}"
                               SelectedElement="{Binding SelectedItem, Mode=TwoWay}"
                               AutoExpandSelected="True">
        <chapter:ExtendedTreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Folders}">
                <TextBlock Text="{Binding Name}" />
            </HierarchicalDataTemplate>
        </chapter:ExtendedTreeView.ItemTemplate>
    </chapter:ExtendedTreeView>
    ```
    ![ExtendedTreeView](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/ExtendedTreeView.png)

9. **FormatterTextBlock:**
    - Usage
    ```xaml
    <ListBox ItemsSource="{Binding Patients}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <chapter:FormatterTextBlock Formatter="{DynamicResource NameFormatter}">
                    <chapter:FormatterPair Replace="{}{firstName}" With="{Binding FirstName}" />
                    <chapter:FormatterPair Replace="{}{lastName}" With="{Binding LastName}" />
                </chapter:FormatterTextBlock>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
    ```
    ![FormatterTextBlock](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/FormatterTextBlock.png)

10. **HeaderItemsControl:**
    - Usage
    ```xaml
    <chapter:HeaderItemsControl>
        <chapter:HeaderItem Header="Name">
            <TextBox Text="{Binding Name}" />
        </chapter:HeaderItem>
        <chapter:HeaderItem Header="Family Name">
            <TextBox Text="{Binding FamilyName}" />
        </chapter:HeaderItem>
        <chapter:HeaderItem Header="Age">
            <TextBox Text="{Binding Age}" />
        </chapter:HeaderItem>
    </chapter:HeaderdItemsControl>
    ```
    ![HeaderItemsControl](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/HeaderItemsControl.png)

11. **ImageButton:**
    - Usage
    ```xaml
    <UniformGrid Rows="1" DockPanel.Dock="Bottom" HorizontalAlignment="Center">

        <chapter:ImageButton Content="Back"
                             ImageSource="/MyAssembly;component/Data/Previous.png" />

        <chapter:ImageButton Content="Next"
                             ImageSource="/MyAssembly.Demo;component/Data/Next.png" 
                             ImagePosition="Right"
                             ImageMargin="4,0,0,0" />

        <chapter:ImageButton Content="Finish"
                             IsEnabled="False"
                             ImageSource="/MyAssembly;component/Data/OK.png" />

        <chapter:ImageButton Content="Cancel"
                             ImageSource="/MyAssembly;component/Data/Cancel.png" />

    </UniformGrid>
    ```
    ![ImageButton](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/ImageButton.png)

12. **ItemsPanel:**
    - Usage
    ```xaml
    <Window>
        <DockPanel>
            <controls:ItemsPanel DockPanel.Dock="Bottom"
                                 IsUniform="True"
                                 HorizontalAlignment="Right"
                                 Orientation="Horizontal"
                                 Spacing="10">
                <Button Content="Back" />
                <Button Content="Next" />
                <Button Content="Finish" />
                <Button Content="Cancel" />
            </controls:ItemsPanel>

            <Grid />
        </DockPanel>
    </Window>

    <Window>
        <DockPanel>
            <controls:ItemsPanel DockPanel.Dock="Bottom"
                                 IsUniform="False"
                                 HorizontalAlignment="Right"
                                 Orientation="Horizontal"
                                 Spacing="10">
                <Button Content="Back" />
                <Button Content="Next" />
                <Button Content="Finish" />
                <Button Content="Cancel" />
            </controls:ItemsPanel>

            <controls:ItemsPanel Spacings="10">
                <TextBox />
                <TextBox />
            </controls:ItemsPanel>
        </DockPanel>
    </Window>
    ```
    ![ItemsPanel](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/ItemsPanel.png)

13. **NumberBox:**
    - Usage
    ```xaml
    <!-- Many properties are set only for display the possibilities -->
    <chapter:NumberBox NumberType="Double"

                       Number="{Binding MyDoubleValue}"
                       Minimum="-12.5"
                       Maximum="55.5"
                       DefaultNumber="5"

                       ShowCurrency="True"
                       Currency="€"
                       CurrencyPosition="Right"

                       HasCheckBox="True"
                       CheckBoxBehavior="EnableIfChecked"
                       IsChecked="{Binding MyDoubleValueIsChecked}"
                       CheckBoxPosition="Left"

                       UpDownBehavior="ArrowsAndButtons"
                       Step="0.5"
                       UpDownButtonsPosition="Right"

                       NumberSelectionBehavior="OnFocusAndUpDown"

                       LostFocusBehavior="{Toolkit:LostFocusBehavior PlaceDefaultNumber, TrimLeadingZero=True, FormatText={}{0:D2}}"

                       PredefinesCulture="en-US" />
    ```
    ![NumberBox](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/NumberBox.png)

14. **OptionButton:**
    - Usage
    ```xaml
    <chapter:OptionButton SliderShape="Round" BackShape="Round" IsChecked="{Binding IsOn}" />

    <chapter:OptionButton SliderShape="Square" BackShape="Square" SliderWidth="18" IsChecked="{Binding IsOn}" />

    <chapter:OptionButton SliderShape="Square" BackShape="Square" SliderWidth="18" BackMargin="10,6" HasText="False" IsChecked="{Binding IsOn}" />
    ```
    ![OptionButton](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/OptionButton.png)

15. **PasswordBox:**
    - Usage
    ```xaml
    <chapter:PasswordBox Password="{Binding Password}" InfoText="Required" InfoAppearance="OnEmpty" />
    ```
    ![PasswordBox](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/PasswordBox.png)

16. **Resizer:**
    - Usage
    ```xaml
    <StackPanel Orientation="Horizontal" VerticalAlignment="Top">
        <chapter:Resizer FrameSizes="0,0,4,4" Margin="0,0,20,0" VerticalAlignment="Top" CornerSize="12">
            <Button Content="Button" Padding="12" />
        </chapter:Resizer>
        <chapter:Resizer RightWidth="4" Margin="0,0,20,0" VerticalAlignment="Top">
            <Button Content="Button" Padding="12" />
        </chapter:Resizer>
        <chapter:Resizer BottomHeight="4" VerticalAlignment="Top">
            <Button Content="Button" Padding="12" />
        </chapter:Resizer>
    </StackPanel>
    ```
    ![Resizer](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/Resizer.png)

17. **SearchTextBox:**
    - Usage
    ```xaml
    <chapter:SearchTextBox ShowSearchButton="True"
                           SearchCommand="{Binding SearchCommand}"
                           IsSearching="{Binding IsSearching}"
                           CancelCommand="{Binding CancelSearchCommand}" />
    ```
    ![SearchTextBox](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/SearchTextBox.png)

18. **SpacingStackPanel:**
    - Usage
    ```xaml
    <chapter:SpacingStackPanel DockPanel.Dock="Bottom"
                         HorizontalAlignment="Right"
                         Orientation="Horizontal"
                         Spacing="10">
        <Button Content="Back" />
        <Button Content="Next" />
        <Button Content="Finish" />
        <Button Content="Cancel" />
    </chapter:SpacingStackPanel>

    <chapter:SpacingStackPanel Spacings="10">
        <TextBox />
        <TextBox />
    </chapter:SpacingStackPanel>
    ```
    ![SpacingStackPanel](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/SpacingStackPanel.png)

19. **SplitButton:**
    - Usage
    ```xaml
    <chapter:SplitButton Content="Any Button" Padding="12,4" Command="{Binding SplitButtonCommand}">
        <chapter:SplitButtonItem Content="Sub Item 1" Command="{Binding SplitButtonItemCommand}" CommmandParameter="1" />
        <chapter:SplitButtonItem Content="Sub Item 2" Command="{Binding SplitButtonItemCommand}" CommmandParameter="2" />
        <chapter:SplitButtonItem Content="Sub Item 3" Command="{Binding SplitButtonItemCommand}" CommmandParameter="3" />
    </chapter:SplitButton>

    <chapter:SplitButton Content="Any Button" Padding="12,4" ItemsSource="{Binding Items}" Command="{Binding SplitButtonCommand}">
        <chapter:SplitButton.ItemContainerStyle>
            <Style TargetType="{x:Type chapter:SplitButtonItem}">
                <Setter Property="Command" Value="{Binding DataContext.SplitButtonItemCommand, RelativeSource={RelativeSource AncestorType={x:Type buttons:SplitButton}}}" />
                 <Setter Property="CommandParameter" Value="{Binding Index}" />
                 <Setter Property="HorizontalContentAlignment" Value="Left" />
             </Style>
         </chapter:SplitButton.ItemContainerStyle>
         <chapter:SplitButton.ItemTemplate>
             <DataTemplate>
                 <TextBlock Text="{Binding }" />
             </DataTemplate>
         </chapter:SplitButton.ItemTemplate>
     </chapter:SplitButton>
    ```
    ![SplitButton](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/SplitButton.png)

20. **TimeBox:**
    - Usage
    ```xaml
    <chapter:TimeBox HasUpDownButtons="True" TimeFormat="Long" Time="{Binding CurrentTime}" />
    ```
    ![TimeBox](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/TimeBox.png)

21. **TitledItemsControl:**
    - Usage
    ```xaml
    <chapter:TitledItemsControl>
        <chapter:TitledItem Text="Name">
            <TextBox Text="{Binding Name}" />
        </chapter:TitledItem>
        <chapter:TitledItem Text="Family Name">
            <TextBox Text="{Binding FamilyName}" />
        </chapter:TitledItem>
        <chapter:TitledItem Text="Age">
            <TextBox Text="{Binding Age}" />
        </chapter:TitledItem>
    </chapter:TitledItemsControl>
    ```
    ![TitledItemsControl](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/TitledItemsControl.png)

22. **TreeListView:**
    - Usage
    ```xaml
    <chapter:TreeListView ItemsSource="{Binding Customer}">
        <chapter:TreeListView.Resources>
            <HierarchicalDataTemplate DataType="{x:Type Data:Customer}" ItemsSource="{Binding Customer}" />
        </chapter:TreeListView.Resources>
        <chapter:TreeListView.View>
            <GridView>
                <GridViewColumn Header="Name">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <DockPanel>
                                <chapter:ListViewExpander DockPanel.Dock="Left" />
                                <TextBlock Text="{Binding Name}" Margin="5,0,0,0" />
                            </DockPanel>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn Header="Family Name" DisplayMemberBinding="{Binding FamilyName}" />
            </GridView>
        </chapter:TreeListView.View>
    </chapter:TreeListView>
    ```
    ![TreeListView](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/TreeListView.png)

23. **UniformPanel:**
    - Usage
    ```xaml
    <chapter:UniformPanel DockPanel.Dock="Bottom"
                          HorizontalAlignment="Right"
                          Orientation="Horizontal"
                          Spacing="10">
        <Button Content="Back" />
        <Button Content="Next" />
        <Button Content="Finish" />
        <Button Content="Cancel" />
    </chapter:UniformPanel>
    ```
    ![UniformPanel](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/UniformPanel.png)

24. **UniformWrapPanel:**
    - Usage
    ```xaml
    <ItemsControl ItemsSource="{Binding Images}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <chapter:UniformWrapPanel />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
    </ItemsControl>

    <chapter:UniformWrapPanel Orientation="Horizontal" MinItemWidth="100">
        <Button Content="One" />
        <Button Content="Two" />
        <Button Content="Three" />
    </chapter:UniformWrapPanel>
    ```
    ![UniformWrapPanel](https://raw.githubusercontent.com/dwndland/Chapter.Net.WPF.Controls/master/Images/UniformWrapPanel.png)

(Note: The shown images are taken from the demo project and are not made by the code next to it.)

## Links
* [NuGet](https://www.nuget.org/packages/Chapter.Net.WPF.Controls)
* [GitHub](https://github.com/dwndland/Chapter.Net.WPF.Controls)

## License
Copyright (c) David Wendland. All rights reserved.
Licensed under the MIT License. See LICENSE file in the project root for full license information.
