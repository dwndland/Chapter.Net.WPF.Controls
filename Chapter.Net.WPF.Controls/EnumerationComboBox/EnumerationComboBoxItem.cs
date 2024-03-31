// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerationComboBoxItem.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Represents an item inside the <see cref="EnumerationComboBox" /> which holds the appropriate enumeration object.
    /// </summary>
    public class EnumerationComboBoxItem : ComboBoxItem
    {
        static EnumerationComboBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumerationComboBoxItem), new FrameworkPropertyMetadata(typeof(EnumerationComboBoxItem)));
        }
    }
}