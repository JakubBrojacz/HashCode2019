using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public static class ArgMaxClass
    {
        public static int ArgMax<T>(this IEnumerable<T> en, Func<int,bool> f) where T:IComparable
        {
            int i = 0;
            int indexMax = 0;
            T max = en.First();
            foreach (var item in en)
            {
                if (!f(i))
                    continue;
                if(item.CompareTo(max) >= 0)
                {
                    indexMax = i;
                    max = item;
                }
                i++;
            }
            return indexMax;
        }

    }
}
