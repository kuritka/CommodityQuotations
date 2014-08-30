//  
// Copyright (c) 2011-2014,  Michal Kuritka
// www.coffeewheat.wordpress.com
// 
using System.Collections.Generic;

namespace CommodityQuotations
{
    public class Inflation
    {
        public decimal Annual { get; set; }

        public int Year { get; set; }

        public List<decimal> Monthly { get; set; }
    }
}
