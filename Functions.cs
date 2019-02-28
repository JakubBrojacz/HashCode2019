using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HAShCoooDe
{
    class Functions
    {
        public int Score(List<Photo> list)
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
