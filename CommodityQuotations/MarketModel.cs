//  
// Copyright (c) 2011-2014,  Michal Kuritka
// www.coffeewheat.wordpress.com
// 
using System.Collections.ObjectModel;


namespace CommodityQuotations
{
    public class MarketModel
    {
        public ContractSpecification ContractSpecification { get; set; }

        public ReadOnlyCollection<Trade> WeeklyData { get;  set; }
    }
}
