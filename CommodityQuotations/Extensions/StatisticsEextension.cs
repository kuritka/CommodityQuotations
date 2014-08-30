//  
// Copyright (c) 2011-2014,  Michal Kuritka
// www.coffeewheat.wordpress.com
// 
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CommodityQuotations.Extensions
{
    public static class StatisticsEextension
    {

        public static decimal StandardDeviation(this IEnumerable<decimal> values)
        {
            Contract.Requires(values != null);
            decimal ret = 0;
            var count = values.Count();
            if (count > 1)
            {
                var avg = values.Average();
                var sum = values.Sum(d => (d - avg) * (d - avg));
                ret = (decimal) Math.Sqrt((double) (sum / count));
            }
            return ret;
        }



        public static decimal Median(this IEnumerable<decimal> values)
        {
            Contract.Requires(values != null);
            var orderedValues = values.OrderBy(d=>d);
            var count = orderedValues.Count();
            var itemIndex = count / 2;
            return count%2 == 0
                ? (orderedValues.ElementAt(itemIndex) + orderedValues.ElementAt(itemIndex - 1))/2
                : orderedValues.ElementAt(itemIndex);            
        }



        public static decimal Range(this IEnumerable<decimal> values)
        {
            Contract.Requires(values != null);
            return values.Max() - values.Min();
        }


        /// <summary>
        /// Returns IEnumerable of SMA(x). First (period-1) values returns null value
        /// </summary>        
        public static IEnumerable<decimal?> SimpleMovingAverage(this IEnumerable<decimal> values, int period)
        {
            Contract.Requires(values != null);
            Contract.Requires(period >0 && period <= values.Count());
            var result = Enumerable.Range(1 - period, values.Count()).Select(c => values.Skip(c).Take(period).Sum()/period);                
            return Enumerable.Range(0, period - 1).Select(i => null as decimal?).Concat(result.Skip(period - 1).Cast<decimal?>());            
        }
    }
}
