// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberBoxCheckBoxBehavior.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Defines what should happen to the  <see cref="NumberBox" /> if the internal checkbox is checked.
    /// </summary>
    public enum NumberBoxCheckBoxBehavior
    {
        /// <summary>
        ///     Nothing happens internally.
        /// </summary>
        None,

        /// <summary>
        ///     The <see cref="NumberBox" /> input field is disabled if the box is checked.
        /// </summary>
        DisableIfChecked,

        /// <summary>
        ///     The <see cref="NumberBox" /> input field is enabled if the box is checked.
        /// </summary>
        EnableIfChecked
    }
}