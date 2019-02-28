using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    class RandomSol
    {
        public Photo[] run(Photo[] input)
        {
            Photo[] tab = { };//tablica do wprowadzenia z inputap
            Photo[] res = new Photo[tab.Length];
            Random sh = new Random();
            Array.Sort(res, ((prop1, prop2) => sh.Next() % 3 - 1));
            for(int i=0;i<9999;i++)
            {
                int a=sh.Next(res.Length);
            }

        }
    }
}
