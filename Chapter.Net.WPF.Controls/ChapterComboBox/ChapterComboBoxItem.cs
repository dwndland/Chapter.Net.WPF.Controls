// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterComboBoxItem.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents an item inside the <see cref="ChapterComboBox" /> which holds the appropriate enumeration object.
/// </summary>
public class ChapterComboBoxItem : ComboBoxItem
{
    static ChapterComboBoxItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterComboBoxItem), new FrameworkPropertyMetadata(typeof(ChapterComboBoxItem)));
    }
}