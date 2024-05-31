// -----------------------------------------------------------------------------------------------------------------
// <copyright file="StatusAndInfoIcon.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Demo.Icons;

public class StatusAndInfoIcon : Control
{
    static StatusAndInfoIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(StatusAndInfoIcon), new FrameworkPropertyMetadata(typeof(StatusAndInfoIcon)));
    }
}