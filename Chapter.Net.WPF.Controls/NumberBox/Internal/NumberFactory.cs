// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberFactory.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

internal static class NumberFactory
{
    internal static INumber Create(NumberType numberType)
    {
        return numberType switch
        {
            NumberType.SByte => new NB_sbyte(),
            NumberType.Byte => new NB_byte(),
            NumberType.Short => new NB_short(),
            NumberType.UShort => new NB_ushort(),
            NumberType.Int => new NB_int(),
            NumberType.UInt => new NB_uint(),
            NumberType.Long => new NB_long(),
            NumberType.ULong => new NB_ulong(),
            NumberType.BigInteger => new NB_BigInteger(),
            NumberType.Float => new NB_float(),
            NumberType.Double => new NB_double(),
            NumberType.Decimal => new NB_decimal(),
            _ => new NB_int()
        };
    }
}