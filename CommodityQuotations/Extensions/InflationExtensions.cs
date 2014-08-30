//  
// Copyright (c) 2011-2014,  Michal Kuritka
// www.coffeewheat.wordpress.com
// 
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CommodityQuotations.Extensions
{
    public static class InflationExtensions
    {
        public static IEnumerable<Trade> CleanFromInflation(this IEnumerable<Trade> trades)
        {
            Contract.Requires(trades.Count() >= 1);
            var firstCpi = trades.First().GetCpi();
            trades.ForEach(d => SubInflation(d, d.GetCpi() / firstCpi - 1));
            return trades;
        }

        private static void SubInflation(Trade trade, decimal inflation)
        {
            trade.Close = trade.Close * (1 - inflation);
            trade.Open = trade.Open * (1 - inflation);
            trade.High = trade.High * (1 - inflation);
            trade.Low = trade.Low * (1 - inflation);
        }
    }
}
