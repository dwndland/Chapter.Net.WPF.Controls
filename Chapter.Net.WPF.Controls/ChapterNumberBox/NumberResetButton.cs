// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberResetButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Represents the reset to default button shown in the <see cref="ChapterNumberBox" />.
    /// </summary>
    public class NumberResetButton : Button
    {
        static NumberResetButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberResetButton), new FrameworkPropertyMetadata(typeof(NumberResetButton)));
        }
    }
}