// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberCheckBox.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Represents the check box shown in the <see cref="ChapterNumberBox" />.
/// </summary>
public class NumberCheckBox : CheckBox
{
    static NumberCheckBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberCheckBox), new FrameworkPropertyMetadata(typeof(NumberCheckBox)));
    }
}