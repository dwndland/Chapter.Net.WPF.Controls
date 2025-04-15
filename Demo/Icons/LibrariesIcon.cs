// -----------------------------------------------------------------------------------------------------------------
// <copyright file="LibrariesIcon.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Demo.Icons;

public class LibrariesIcon : Control
{
    static LibrariesIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(LibrariesIcon), new FrameworkPropertyMetadata(typeof(LibrariesIcon)));
    }
}