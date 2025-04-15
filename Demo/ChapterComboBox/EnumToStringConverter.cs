// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EnumToStringConverter.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Demo;

public class EnumToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return "Converted: " + value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value.ToString().Replace("Converted: ", "");
    }
}