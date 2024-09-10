# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]
### Changed
- Adjusted ChapterHeaderedContentControl to use the ChapterControlHeaderPresenter and ChapterControlFooterPresenter to present the header and footer.
- Removed icon handling inside the ChapterButton.
- Removed icon handling inside the ChapterRepeatButton.
- Removed icon handling inside the ChapterToggleButton.
- Removed icon handling inside the ChapterSelectorBar.
- Remove option to hide the browse button within the ChapterBrowseTextBox.
### Fixed
- Fixed crash of the ChapterStackPanel if used empty.

## [3.0.0] - 2024-06-07
### Added
- Added ChapterAccordion which is an accordion with sub items which can be expanded or collapsed.
- Added ChapterBadge which allows to attach a notification icon to any control.
- Added ChapterCard which is a container control to crate card like groups of elements.
- Added ChapterCheckBox which is a regular check box but with a build in header and footer.
- Added ChapterNavigationView which is a menu side bar collapsable by a burger button.
- Added ChapterRepeatButton which is a repeat button with more features like oval endings, corner radius, header, footer and optional icon either as image or object.
- Added ChapterSelectorBar which is an item bar like a more simple tab control.
- Added ChapterToggleButton which is a toggle button with more features like oval endings, corner radius, header, footer and optional icon either as image or object.
### Changed
- Update to support .Net 8 only.
- Extended ChapterButton which is a button with more features like oval endings, corner radius, header, footer and optional icon either as image or object.
- Renewed the ChapterHeaderedContentControl to be a headered content control with more possible customization and a footer.

## [2.0.0] - 2024-04-20
### Removed
- Removed FormatterTextBlock. That got moved to the Chapter.Net.WPF.Localization.
### Changed
- Renamed AdvancedTextBox to ChapterTextBox.
- Renamed ArcPanel to ChapterArcPanel.
- Renamed BrowseTextBox to ChapterBrowseTextBox.
- Renamed DynamicTabControl to ChapterTabControl.
- Renamed EllipsePanel to ChapterEllipsePanel.
- Renamed EnumerationComboBox to ChapterComboBox.
- Renamed ExtendedTreeView to ChapterTreeView.
- Renamed FormatterTextBlock to ChapterTextBlock.
- Renamed HeaderItemsControl to ChapterHeaderedContentControl.
- Renamed ImageButton to ChapterButton.
- Renamed ItemsPanel to ChapterItemsPanel.
- Renamed NumberBox to ChapterNumberBox.
- Renamed OptionButton to ChapterToggleSwitch.
- Renamed PasswordBox to ChapterPasswordBox.
- Renamed Resizer to ChapterResizer.
- Renamed SearchTextBox to ChapterSearchTextBox.
- Renamed SpacingStackPanel to ChapterStackPanel.
- Renamed SplitButton to ChapterSplitButton.
- Renamed TimeBox to ChapterTimeBox.
- Renamed TitledItemsControl to ChapterTitledItemsControl.
- Renamed TreeListView to ChapterTreeListView.
- Renamed UniformPanel to ChapterUniformPanel.
- Renamed UniformWrapPanel to ChapterWrapPanel.
- Change default for IsUniform within the ChapterWrapPanel from true to false.
### Supported .Net Versions
- .Net Core 3.0
- .Net Framework 4.5
- .Net 5 (Windows)
- .Net 6 (Windows)
- .Net 7 (Windows)
- .Net 8 (Windows)

## [1.2.0] - 2024-03-31
### Added
- Added more supported .net versions.
### Supported .Net Versions
- .Net Core 3.0
- .Net Framework 4.5
- .Net 5 (Windows)
- .Net 6 (Windows)
- .Net 7 (Windows)
- .Net 8 (Windows)

## [1.1.0] - 2024-03-28
### Added
- Add possibility to define the amount of decimal places on the number box.
### Supported .Net Versions
- .Net 6
- .Net 7
- .Net 8

## [1.0.2] - 2024-02-02
### Removed
- Remove dependency to the Chapter.Net.Converters.
### Supported .Net Versions
- .Net 6
- .Net 7
- .Net 8

## [1.0.1] - 2024-01-30
### Fixed
- The ChapterTreeView did not allow a select by code anymore if the selected item was set to null once.
### Supported .Net Versions
- .Net 6
- .Net 7
- .Net 8

## [1.0.0] - 2023-12-24
### Added
- Init project
### Supported .Net Versions
- .Net 6
- .Net 7
- .Net 8
