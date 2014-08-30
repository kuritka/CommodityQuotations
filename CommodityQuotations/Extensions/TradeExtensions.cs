//  
// Copyright (c) 2011-2014,  Michal Kuritka
// www.coffeewheat.wordpress.com
// 
using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CommodityQuotations.Extensions
{
    public static class TradeExtensions
    {
        public static int GetSettlementYear(this Trade trade)
        {
            Contract.Requires(trade.Code.Length >= 4);
            int year;
            var reverse = trade.Code.ToCharArray().Reverse().ToArray();
            var strYear = (string.Format("{0}{1}", reverse[1], reverse[0]));
            Int32.TryParse(strYear, out year);
            return year + 2000;
        }

        public static int GetSettlementMonth(this Trade trade)
        {
            Contract.Requires(trade.Code.Length >= 4);
            return "FGHJKMNQUVXZ".IndexOf(trade.GetMonthCode()) + 1;
        }

        /// <summary>
        /// Returns CPI for current trade. If CPI for current trade doesn't exist, it returns last possible CPI
        /// </summary>        
        public static decimal GetCpi(this Trade trade)
        {
            Contract.Requires(trade != null);
            Contract.Requires(trade.Date != DateTime.MinValue);
            Contract.Requires(trade.Date.Date > new DateTime(Data.Cpi.Last().Year, Data.Cpi.Last().Monthly.Count(), 1));
            var yearCpi = Data.Cpi.FirstOrDefault(d => d.Year == trade.Date.Year);
            if(yearCpi == null)
            {
                return Data.Cpi.OrderBy(d => d.Year).Last().Monthly.Last();
            }
            return yearCpi.Monthly.Contains(trade.Date.Month - 1) ? yearCpi.Monthly[trade.Date.Month - 1] : yearCpi.Monthly.Last();
        }

        private static char GetMonthCode(this Trade trade)
        {
            Contract.Requires(trade.Code.Length >= 4);
            return trade.Code.ToCharArray().Reverse().ToArray()[2];
        }
       
    }
}
