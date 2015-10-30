﻿using Liquid.NET.Constants;
using Liquid.NET.Utils;

namespace Liquid.NET.Filters.Strings
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class PrependFilter : FilterExpression<IExpressionConstant, StringValue>
    {
        private readonly StringValue _prependedStr;

        public PrependFilter(StringValue prependedStr)
        {
            _prependedStr = prependedStr;
        }

        public override LiquidExpressionResult ApplyTo(ITemplateContext ctx, IExpressionConstant liquidExpression)
        {
            var strToPrepend = _prependedStr == null ? "" : _prependedStr.StringVal;
            return LiquidExpressionResult.Success(StringUtils.Eval(liquidExpression, x => strToPrepend + x));
        }
    }
}
