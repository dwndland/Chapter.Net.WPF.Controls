// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberFactory.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    internal static class NumberFactory
    {
        internal static INumber Create(NumberType numberType)
        {
            switch (numberType)
            {
                case NumberType.SByte:
                    return new NB_sbyte();
                case NumberType.Byte:
                    return new NB_byte();
                case NumberType.Short:
                    return new NB_short();
                case NumberType.UShort:
                    return new NB_ushort();
                case NumberType.Int:
                    return new NB_int();
                case NumberType.UInt:
                    return new NB_uint();
                case NumberType.Long:
                    return new NB_long();
                case NumberType.ULong:
                    return new NB_ulong();
                case NumberType.BigInteger:
                    return new NB_BigInteger();
                case NumberType.Float:
                    return new NB_float();
                case NumberType.Double:
                    return new NB_double();
                case NumberType.Decimal:
                    return new NB_decimal();
                default:
                    return new NB_int();
            }
        }
    }
}