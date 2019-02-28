using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    static class Functions
    {
        public static int Score(this Photo[] tab)
        {
            int result = 0;
            for(int iTab = 0; iTab < tab.Length-1; iTab++)
            {
                result += tab[iTab].Score(tab[iTab + 1]);
            }
            return result;
        }
        public static int[,] GenPairs(this Photo[] list)
        {
            var tab = new int[list.Length, list.Length];
            foreach(var mover in list)
            {
                foreach(var plox in list)
                {
                    if(mover.horizontal == false && plox.horizontal == false)
                    {
                        tab[mover.id, plox.id] = -1;
                        tab[plox.id, mover.id] = -1;
                        continue;
                    }
                    tab[mover.id, plox.id] = tab[plox.id, mover.id] = mover.Score(plox);
                }
            }
            return tab;
        }
    }

}
