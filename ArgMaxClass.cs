using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    static class ArgMaxClass
    {
        static int ArgMax<T>(this IEnumerable<T> en) where T:IComparable
        {
            int i = 0;
            int indexMax = 0;
            T max = en.First();
            foreach (var item in en)
            {
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
