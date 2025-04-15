// -----------------------------------------------------------------------------------------------------------------
// <copyright file="INumber.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

internal interface INumber
{
    object CurrentNumber { get; }
    bool CanIncrease { get; }
    bool CanDecrease { get; }
    bool AcceptNegative { get; }
    bool NumberIsBelowMinimum { get; }
    void Initialize(object number, object minimum, object maximum, int decimalPlaces, object step, object defaultNumber, CultureInfo parsingCulture, CultureInfo predefinedCulture);
    void TakeCulture(object culture);
    bool CanTakeNumber(object newNumber);
    bool TakeNumber(object newNumber);
    void TakeMinimum(object newMinimum);
    void TakeMaximum(object newMaximum);
    void TakeDecimalPlaces(int decimalPlaces);
    void TakeStep(object newStep);
    void TakeDefaultNumber(object newDefaultValue);
    void Increase();
    void Decrease();
    void Reset();
    void ToMaximum();
    void ToMinimum();
}