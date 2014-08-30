//  
// Copyright (c) 2011-2014,  Michal Kuritka
// www.coffeewheat.wordpress.com
// 
using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CommodityQuotations.Extensions
{
    public static class QuotationExtensions
    {
        public static int GetSettlementYear(this Quotation Quotation)
        {
            Contract.Requires(Quotation.Code.Length >= 4);
            int year;
            var reverse = Quotation.Code.ToCharArray().Reverse().ToArray();
            var strYear = (string.Format("{0}{1}", reverse[1], reverse[0]));
            Int32.TryParse(strYear, out year);
            return year + 2000;
        }

        public static int GetSettlementMonth(this Quotation Quotation)
        {
            Contract.Requires(Quotation.Code.Length >= 4);
            return "FGHJKMNQUVXZ".IndexOf(Quotation.GetMonthCode()) + 1;
        }

        /// <summary>
        /// Returns CPI for current Quotation. If CPI for current Quotation doesn't exist, it returns last possible CPI
        /// </summary>        
        public static decimal GetCpi(this Quotation Quotation)
        {
            Contract.Requires(Quotation != null);
            Contract.Requires(Quotation.Date != DateTime.MinValue);
            Contract.Requires(Quotation.Date.Date > new DateTime(Data.Cpi.Last().Year, Data.Cpi.Last().Monthly.Count(), 1));
            var yearCpi = Data.Cpi.FirstOrDefault(d => d.Year == Quotation.Date.Year);
            if(yearCpi == null)
            {
                return Data.Cpi.OrderBy(d => d.Year).Last().Monthly.Last();
            }
            return yearCpi.Monthly.Contains(Quotation.Date.Month - 1) ? yearCpi.Monthly[Quotation.Date.Month - 1] : yearCpi.Monthly.Last();
        }

        private static char GetMonthCode(this Quotation Quotation)
        {
            Contract.Requires(Quotation.Code.Length >= 4);
            return Quotation.Code.ToCharArray().Reverse().ToArray()[2];
        }
       
    }
}
