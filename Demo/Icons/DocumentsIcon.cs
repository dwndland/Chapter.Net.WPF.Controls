// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentsIcon.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Demo.Icons;

public class DocumentsIcon : Control
{
    static DocumentsIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DocumentsIcon), new FrameworkPropertyMetadata(typeof(DocumentsIcon)));
    }
}