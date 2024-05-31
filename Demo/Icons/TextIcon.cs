// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TextIcon.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Demo.Icons;

public class TextIcon : Control
{
    static TextIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TextIcon), new FrameworkPropertyMetadata(typeof(TextIcon)));
    }
}