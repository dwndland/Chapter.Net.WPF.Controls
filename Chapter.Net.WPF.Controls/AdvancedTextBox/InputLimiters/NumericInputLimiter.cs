// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumericInputLimiter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Text.RegularExpressions;
using System.Windows.Input;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Allows only numeric input ([0-9]) on a <see cref="AdvancedTextBox" />.
    /// </summary>
    public sealed class NumericInputLimiter : InputLimiter
    {
        private readonly Regex _regex;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NumericInputLimiter" /> class.
        /// </summary>
        public NumericInputLimiter()
        {
            _regex = new Regex(@"^[0-9]*$");
        }

        /// <inheritdoc />
        public override bool AcceptKey(Key key)
        {
            return key != Key.Space;
        }

        /// <inheritdoc />
        public override bool AcceptText(string input)
        {
            return _regex.IsMatch(input);
        }
    }
}