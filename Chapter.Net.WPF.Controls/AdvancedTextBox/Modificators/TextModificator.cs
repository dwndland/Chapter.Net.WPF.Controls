// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TextModificator.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows.Markup;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Allows modification of the text in the <see cref="AdvancedTextBox" />.
    /// </summary>
    public abstract class TextModificator : MarkupExtension
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TextModificator" /> class.
        /// </summary>
        public TextModificator()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextModificator" /> class.
        /// </summary>
        /// <param name="modificationTime">The time when the <see cref="Modify" /> will be called.</param>
        public TextModificator(ModificationTime modificationTime)
        {
            ModificationTime = modificationTime;
        }

        /// <summary>
        ///     Gets or sets the time when the modification will be executed.
        /// </summary>
        public ModificationTime ModificationTime { get; set; }

        /// <summary>
        ///     Modifies the text.
        /// </summary>
        /// <param name="input">The user input.</param>
        /// <returns>The new modified text.</returns>
        public abstract string Modify(string input);

        /// <summary>
        ///     Provides the TextModificator.
        /// </summary>
        /// <param name="serviceProvider">Unused.</param>
        /// <returns>The current text modificator.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}