// -----------------------------------------------------------------------------------------------------------------
// <copyright file="SaveIcon.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Demo.Icons;

public class SaveIcon : Control
{
    static SaveIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SaveIcon), new FrameworkPropertyMetadata(typeof(SaveIcon)));
    }
}