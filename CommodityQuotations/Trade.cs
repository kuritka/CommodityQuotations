//  
// Copyright (c) 2011-2014,  Michal Kuritka
// www.coffeewheat.wordpress.com
// 
using System;

namespace CommodityQuotations
{
    public class Trade
    {
        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Open { get; set; }

        public decimal Close { get; set; }

        public int Volume { get; set; }

        public int Interest { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }
    }
}
