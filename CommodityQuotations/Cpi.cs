//  
// Copyright (c) 2011-2014,  Michal Kuritka
// www.coffeewheat.wordpress.com
// 
using System.Collections.Generic;
using System.Linq;

namespace CommodityQuotations
{
    public class Cpi
    {
        public int Year { get; set; }

        public List<decimal> Monthly { get; set; }

        public decimal Annual
        {
            get { return Monthly.Sum() / Monthly.Count; }
        }
    }
}
