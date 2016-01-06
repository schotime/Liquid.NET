﻿using System;

using Liquid.NET.Constants;

namespace Liquid.NET.Utils
{
    public static class LiquidConversionExtensions
    {
        public static Option<ILiquidValue> ToLiquid(this object obj)
        {
            return new LiquidValueConverter().Convert(obj);
        }

        public static Option<ILiquidValue> ToLiquid(this object obj, LiquidValueConverterOptions options)
        {
            return new LiquidValueConverter { Options = options }.Convert(obj);
        }
    }
}
