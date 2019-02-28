using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HAShCoooDe
{
    static class Functions
    {
        public static int Score(this List<Photo> list)
        {
            int result = 0;
            var tab = list.ToArray();
            for(int iTab = 0; iTab < tab.Length-1; iTab++)
            {
                result += Score(tab[iTab], tab[iTab + 1]);
            }
            return result;
        }
    }
}
