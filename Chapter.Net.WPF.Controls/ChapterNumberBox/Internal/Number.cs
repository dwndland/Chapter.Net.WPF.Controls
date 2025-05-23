// -----------------------------------------------------------------------------------------------------------------
// <copyright file="Number.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

internal abstract class Number<T> : INumber
{
    protected T _current;
    protected int _decimalPlaces;
    protected T _default;
    protected T _maximum;
    protected T _minimum;
    protected CultureInfo _parsingCulture;
    protected T _step;

    public object CurrentNumber => _current;

    public void Initialize(object number, object minimum, object maximum, int decimalPlaces, object step, object defaultNumber, CultureInfo parsingCulture, CultureInfo predefinedCulture)
    {
        TakeCulture(predefinedCulture);
        TakeMinimum(minimum);
        TakeMaximum(maximum);
        TakeStep(step);
        TakeDefaultNumber(defaultNumber);
        TakeNumber(number);
        TakeCulture(parsingCulture);
    }

    public void TakeCulture(object culture)
    {
        var casted = culture as CultureInfo;
        _parsingCulture = casted ?? CultureInfo.CurrentUICulture;
    }

    public bool CanTakeNumber(object newNumber)
    {
        return TryParse(newNumber, out var parsedNumber) && IsInRange(parsedNumber);
    }

    public bool TakeNumber(object newNumber)
    {
        if (TryParse(newNumber, out var parsedNumber) && IsInRange(parsedNumber))
        {
            _current = parsedNumber;
            return true;
        }

        return false;
    }

    public void TakeMinimum(object newMinimum)
    {
        if (newMinimum == null)
        {
            _minimum = GetMinValue();
            return;
        }

        if (TryParse(newMinimum, out var parsedNumber))
            _minimum = parsedNumber;
    }

    public void TakeMaximum(object newMaximum)
    {
        if (newMaximum == null)
        {
            _maximum = GetMaxValue();
            return;
        }

        if (TryParse(newMaximum, out var parsedNumber))
            _maximum = parsedNumber;
    }

    public void TakeDecimalPlaces(int decimalPlaces)
    {
        _decimalPlaces = decimalPlaces;
    }

    public void TakeStep(object newStep)
    {
        TryParse(newStep, out var parsedStep);
        _step = parsedStep ?? GetDefaultStep();
    }

    public void TakeDefaultNumber(object newDefaultValue)
    {
        if (TryParse(newDefaultValue, out var parsedNumber))
            _default = parsedNumber;
    }

    public void Increase()
    {
        if (!CanIncrease)
            return;

        StepUp();
    }

    public void Decrease()
    {
        if (!CanDecrease)
            return;

        StepDown();
    }

    public void Reset()
    {
        _current = _default;
    }

    public void ToMaximum()
    {
        _current = _maximum;
    }

    public void ToMinimum()
    {
        _current = _minimum;
    }

    public abstract bool CanIncrease { get; }
    public abstract bool CanDecrease { get; }
    public abstract bool AcceptNegative { get; }
    public abstract bool NumberIsBelowMinimum { get; }

    private bool TryParse(object number, out T parsed)
    {
        parsed = default;
        if (number == null)
            return true;

        if (TryParse(number.ToString(), out var parsedNumber))
        {
            parsed = parsedNumber;
            return true;
        }

        return false;
    }

    protected abstract T GetMinValue();
    protected abstract T GetMaxValue();
    protected abstract T GetDefaultStep();
    protected abstract void StepUp();
    protected abstract void StepDown();
    protected abstract bool IsInRange(T parsedNumber);
    protected abstract bool TryParse(string numberString, out T parsed);

    protected bool IsAllowedDecimalFractionLength(string text, int allowedDecimalPlaces)
    {
        if (allowedDecimalPlaces == -1) // It's turned off.
            return true;

        var separator = _parsingCulture.NumberFormat.NumberDecimalSeparator;
        var index = text.IndexOf(separator, StringComparison.Ordinal);
        if (index < 0) // No separator yet.
            return true;

        if (index + 1 >= text.Length) // Separator but no number after yet.
            return true;

        var decimalPart = text.Substring(index + 1);
        return decimalPart.Length <= allowedDecimalPlaces;
    }
}