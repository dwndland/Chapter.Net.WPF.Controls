// -----------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyPanel.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Demo;

public class PropertyPanel : ItemsControl
{
    static PropertyPanel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyPanel), new FrameworkPropertyMetadata(typeof(PropertyPanel)));
    }
}