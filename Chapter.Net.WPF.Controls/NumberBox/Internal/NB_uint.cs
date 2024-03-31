// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NB_uint.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    internal class NB_uint : Number<uint?>
    {
        public override bool CanIncrease => _current + _step <= _maximum;

        public override bool CanDecrease => _current - _step >= _minimum;

        public override bool AcceptNegative => false;

        public override bool NumberIsBelowMinimum => _current < _minimum;

        protected override uint? GetMinValue()
        {
            return uint.MinValue;
        }

        protected override uint? GetMaxValue()
        {
            return uint.MaxValue;
        }

        protected override uint? GetDefaultStep()
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

        protected override bool IsInRange(uint? parsedNumber)
        {
            if (parsedNumber == null)
                return true;
            return parsedNumber <= _maximum;
        }

        protected override bool TryParse(string numberString, out uint? parsed)
        {
            if (string.IsNullOrWhiteSpace(numberString))
            {
                parsed = null;
                return true;
            }

            var result = uint.TryParse(numberString, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, _parsingCulture, out var tmp);
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
}