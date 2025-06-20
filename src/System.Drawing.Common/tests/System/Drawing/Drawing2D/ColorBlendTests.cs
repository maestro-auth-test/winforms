﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Drawing.Drawing2D.Tests;

public class ColorBlendTests
{
    [Fact]
    public void Ctor_Default()
    {
        ColorBlend blend = new();
        Assert.Equal(new Color[1], blend.Colors);
        Assert.Equal(new float[1], blend.Positions);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(2)]
    public void Ctor_Count(int count)
    {
        ColorBlend blend = new(count);
        Assert.Equal(new Color[count], blend.Colors);
        Assert.Equal(new float[count], blend.Positions);
    }

    [Fact]
    public void Ctor_InvalidCount_ThrowsOverflowException()
    {
        Assert.Throws<OverflowException>(() => new ColorBlend(-1));
    }

    [Fact(Skip = "Condition not met", SkipType = typeof(PlatformDetection), SkipUnless = nameof(PlatformDetection.IsNotIntMaxValueArrayIndexSupported))]
    public void Ctor_LargeCount_ThrowsOutOfMemoryException()
    {
        Assert.Throws<OutOfMemoryException>(() => new ColorBlend(int.MaxValue));
    }

    [Fact]
    public void Colors_Set_GetReturnsExpected()
    {
        ColorBlend blend = new() { Colors = null };
        Assert.Null(blend.Colors);

        blend.Colors = new Color[10];
        Assert.Equal(new Color[10], blend.Colors);
    }

    [Fact]
    public void Positions_Set_GetReturnsExpected()
    {
        ColorBlend blend = new() { Positions = null };
        Assert.Null(blend.Positions);

        blend.Positions = new float[10];
        Assert.Equal(new float[10], blend.Positions);
    }
}
