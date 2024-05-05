// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NB_BigInteger.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Numerics;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    internal class NB_BigInteger : Number<BigInteger?>
    {
        public override bool CanIncrease
        {
            get
            {
                if (_maximum == null)
                    return true;
                return _current + _step <= _maximum;
            }
        }

        public override bool CanDecrease
        {
            get
            {
                if (_minimum == null)
                    return true;
                return _current - _step >= _minimum;
            }
        }

        public override bool AcceptNegative => _minimum == null || _minimum.Value < 0;

        public override bool NumberIsBelowMinimum => _current < _minimum;

        protected override BigInteger? GetMinValue()
        {
            return null;
        }

        protected override BigInteger? GetMaxValue()
        {
            return null;
        }

        protected override BigInteger? GetDefaultStep()
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

        protected override bool IsInRange(BigInteger? parsedNumber)
        {
            if (parsedNumber == null)
                return true;
            if (_maximum != null && parsedNumber > _maximum)
                return false;
            return true;
        }

        protected override bool TryParse(string numberString, out BigInteger? parsed)
        {
            if (string.IsNullOrWhiteSpace(numberString))
            {
                parsed = null;
                return true;
            }

            var result = BigInteger.TryParse(numberString, NumberStyles.Integer, _parsingCulture, out var tmp);
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