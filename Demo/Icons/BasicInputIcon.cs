// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BasicInputIcon.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Demo.Icons;

public class BasicInputIcon : Control
{
    static BasicInputIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(BasicInputIcon), new FrameworkPropertyMetadata(typeof(BasicInputIcon)));
    }
}