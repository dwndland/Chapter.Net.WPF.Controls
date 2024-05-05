// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DemoEnum.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

// ReSharper disable once CheckNamespace

namespace Demo;

public enum DemoEnum
{
    [Description("Description: First")] First,

    [Description("Description: Second")] Second,

    [Description("Description: Third")] Third
}