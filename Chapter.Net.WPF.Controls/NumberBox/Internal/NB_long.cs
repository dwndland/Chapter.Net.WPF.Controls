// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NB_long.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

internal class NB_long : Number<long?>
{
    public override bool CanIncrease => _current + _step <= _maximum;

    public override bool CanDecrease => _current - _step >= _minimum;

    public override bool AcceptNegative => _minimum < 0;

    public override bool NumberIsBelowMinimum => _current < _minimum;

    protected override long? GetMinValue()
    {
        return long.MinValue;
    }

    protected override long? GetMaxValue()
    {
        return long.MaxValue;
    }

    protected override long? GetDefaultStep()
    {
        return 1;
    }

    protected override void StepUp()
    {
        _current += _step;
    }

    protected override void StepDown()
    {
        _current -= _step;
    }

    protected override bool IsInRange(long? parsedNumber)
    {
        if (parsedNumber == null)
            return true;
        return parsedNumber <= _maximum;
    }

    protected override bool TryParse(string numberString, out long? parsed)
    {
        if (string.IsNullOrWhiteSpace(numberString))
        {
            parsed = null;
            return true;
        }

        var result = long.TryParse(numberString, NumberStyles.Integer, _parsingCulture, out var tmp);
        parsed = tmp;
        return result;
    }

    public override string ToString()
    {
        if (_current == null)
            return string.Empty;
        return _current.Value.ToString(_parsingCulture);
    }
}