// -----------------------------------------------------------------------------------------------------------------
// <copyright file="LayoutIcon.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Demo.Icons;

public class LayoutIcon : Control
{
    static LayoutIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutIcon), new FrameworkPropertyMetadata(typeof(LayoutIcon)));
    }
}