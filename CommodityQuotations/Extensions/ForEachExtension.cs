using System;
using System.Collections.Generic;

namespace CommodityQuotations.Extensions
{
    public static class ForEachExtension
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            foreach (var item in source)
                action(item);

            return source;
        }
    }
}
