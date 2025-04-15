// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionsIcon.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Demo.Icons;

public class CollectionsIcon : Control
{
    static CollectionsIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CollectionsIcon), new FrameworkPropertyMetadata(typeof(CollectionsIcon)));
    }
}