// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EnumDescriptionConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Returns the description of a given enum value.
/// </summary>
[ValueConversion(typeof(Enum), typeof(string))]
public class EnumDescriptionConverter : IValueConverter
{
    /// <summary>
    ///     Takes the value and tries to cast it to System.Enum to read it description attribute.
    /// </summary>
    /// <param name="value">The enum value which description should be read.</param>
    /// <param name="targetType">This parameter is not used.</param>
    /// <param name="parameter">This parameter is not used.</param>
    /// <param name="culture">This parameter is not used.</param>
    /// <returns>
    ///     The description text of the enum value if any; the enum name as a string. If the parameter is not an
    ///     System.Enum it returns string.Empty
    /// </returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !(value is Enum @enum) ? string.Empty : GetDescription(@enum);
    }

    /// <summary>
    ///     Not implemented.
    /// </summary>
    /// <param name="value">This parameter is not used.</param>
    /// <param name="targetType">This parameter is not used.</param>
    /// <param name="parameter">This parameter is not used.</param>
    /// <param name="culture">This parameter is not used.</param>
    /// <returns>nothing</returns>
    /// <exception cref="System.NotImplementedException">The convert back is not intended to be used.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    private static string GetDescription(Enum @enum)
    {
        var enumType = @enum.GetType();
        var enumField = enumType.GetField(@enum.ToString());

        var descriptionAttribute = Attribute.GetCustomAttribute(enumField!, typeof(DescriptionAttribute)) as DescriptionAttribute;
        return descriptionAttribute == null ? enumField.ToString() : descriptionAttribute.Description;
    }
}