// -----------------------------------------------------------------------------------------------------------------
// <copyright file="StringToThicknessConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Demo.HeaderItemsControl;

public class StringToThicknessConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            // new ThicknessConverter().ConvertFromString(value?.ToString()) does not convert it as expected.
            // E.g. 5,0,0,10 will end up in "The string "5,0,0,10" cannot be converted to "Length"."

            var text = value.ToString();
            if (text.EndsWith(",") || text.Split(",").Length == 3)
                return new Thickness();

            var textBlock = (TextBlock)XamlReader.Parse(@$"<TextBlock xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" 
                                                                      xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
                                                                      Margin=""{value}"" />");

            return textBlock.Margin;
        }
        catch
        {
            return new Thickness();
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}