// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NB_int.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

internal class NB_int : Number<int?>
{
    public override bool CanIncrease => _current + _step <= _maximum;

    public override bool CanDecrease => _current - _step >= _minimum;

    public override bool AcceptNegative => _minimum < 0;

    public override bool NumberIsBelowMinimum => _current < _minimum;

    protected override int? GetMinValue()
    {
        return int.MinValue;
    }

    protected override int? GetMaxValue()
    {
        return int.MaxValue;
    }

    protected override int? GetDefaultStep()
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

    protected override bool IsInRange(int? parsedNumber)
    {
        if (parsedNumber == null)
            return true;
        return parsedNumber <= _maximum;
    }

    protected override bool TryParse(string numberString, out int? parsed)
    {
        if (string.IsNullOrWhiteSpace(numberString))
        {
            parsed = null;
            return true;
        }

        var result = int.TryParse(numberString, NumberStyles.Integer, _parsingCulture, out var tmp);
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