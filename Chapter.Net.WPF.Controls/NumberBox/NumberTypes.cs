// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberTypes.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Defines which kind of numbers the <see cref="NumberBox" /> is accepting.
    /// </summary>
    /// <remarks>
    ///     Number type references:<br />
    ///     <a href="https://msdn.microsoft.com/en-us/library/exx3b86w.aspx">Integral Types Table</a><br />
    ///     <a href="https://msdn.microsoft.com/en-us/library/9ahet949.aspx">Floating-Point Types Table</a><br />
    ///     <a href="https://msdn.microsoft.com/en-us/library/364x0z75.aspx">Decimal</a><br />
    ///     <a href="https://msdn.microsoft.com/de-de/library/vstudio/system.numerics.biginteger(v=vs.100)">
    ///         System.Numerics.BigInteger
    ///         Structure
    ///     </a>
    /// </remarks>
    public enum NumberType
    {
        /// <summary>
        ///     Represents sbyte or sbyte?.
        /// </summary>
        SByte,

        /// <summary>
        ///     Represents byte or byte?.
        /// </summary>
        Byte,

        /// <summary>
        ///     Represents short or short?.
        /// </summary>
        Short,

        /// <summary>
        ///     Represents ushort or ushort?.
        /// </summary>
        UShort,

        /// <summary>
        ///     Represents int or int?.
        /// </summary>
        Int,

        /// <summary>
        ///     Represents uint or uint?.
        /// </summary>
        UInt,

        /// <summary>
        ///     Represents long or long?.
        /// </summary>
        Long,

        /// <summary>
        ///     Represents ulong or ulong?.
        /// </summary>
        ULong,

        /// <summary>
        ///     Represents BigInteger or BigInteger?.
        /// </summary>
        BigInteger,

        /// <summary>
        ///     Represents float or float?.
        /// </summary>
        Float,

        /// <summary>
        ///     Represents double or double?.
        /// </summary>
        Double,

        /// <summary>
        ///     Represents decimal or decimal?.
        /// </summary>
        Decimal
    }
}