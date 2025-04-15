// -----------------------------------------------------------------------------------------------------------------
// <copyright file="UsersIcon.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Demo.Icons;

public class UsersIcon : Control
{
    static UsersIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(UsersIcon), new FrameworkPropertyMetadata(typeof(UsersIcon)));
    }
}