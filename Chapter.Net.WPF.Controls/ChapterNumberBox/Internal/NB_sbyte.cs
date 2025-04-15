// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NB_sbyte.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

internal class NB_sbyte : Number<sbyte?>
{
    public override bool CanIncrease => _current + _step <= _maximum;

    public override bool CanDecrease => _current - _step >= _minimum;

    public override bool AcceptNegative => _minimum < 0;

    public override bool NumberIsBelowMinimum => _current < _minimum;

    protected override sbyte? GetMinValue()
    {
        return sbyte.MinValue;
    }

    protected override sbyte? GetMaxValue()
    {
        return sbyte.MaxValue;
    }

    protected override sbyte? GetDefaultStep()
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

    protected override bool IsInRange(sbyte? parsedNumber)
    {
        if (parsedNumber == null)
            return true;
        return parsedNumber <= _maximum;
    }

    protected override bool TryParse(string numberString, out sbyte? parsed)
    {
        if (string.IsNullOrWhiteSpace(numberString))
        {
            parsed = null;
            return true;
        }

        var result = sbyte.TryParse(numberString, NumberStyles.Number, _parsingCulture, out var tmp);
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