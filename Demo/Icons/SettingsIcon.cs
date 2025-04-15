// -----------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsIcon.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Demo.Icons;

public class SettingsIcon : Control
{
    static SettingsIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SettingsIcon), new FrameworkPropertyMetadata(typeof(SettingsIcon)));
    }
}