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
        public static IEnumerable<Quotation> CleanFromInflation(this IEnumerable<Quotation> Quotations)
        {
            Contract.Requires(Quotations.Count() >= 1);
            var firstCpi = Quotations.First().GetCpi();
            Quotations.ForEach(d => SubInflation(d, d.GetCpi() / firstCpi - 1));
            return Quotations;
        }

        private static void SubInflation(Quotation Quotation, decimal inflation)
        {
            Quotation.Close = Quotation.Close * (1 - inflation);
            Quotation.Open = Quotation.Open * (1 - inflation);
            Quotation.High = Quotation.High * (1 - inflation);
            Quotation.Low = Quotation.Low * (1 - inflation);
        }
    }
}
