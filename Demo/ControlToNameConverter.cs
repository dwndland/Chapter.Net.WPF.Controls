// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ControlToNameConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

namespace Demo;

public class ControlToNameConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return string.Empty;

        var name = value.ToString()!.Replace("Demo.", "");
        return name.Substring(0, name.Length - "Control".Length);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}