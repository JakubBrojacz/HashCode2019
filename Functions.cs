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
        public static int Score(this List<Photo> list)
        {
            return Score(list.ToArray());
        }
        public static int Score(Photo a,Photo b)
        {
            Photo[] tab = { a, b };
            return tab.Score();
        }
        public static int[][] GenPairs(this Photo[] list)
        {
            var tab = new int[list.Length][];
            for(int i = 0; i < list.Length; i++)
            {
                tab[i] = new int[list.Length];
            }
            foreach(var mover in list)
            {
                foreach(var plox in list)
                {
                    if(mover.horizontal == false && plox.horizontal == false)
                    {
                        tab[mover.id][plox.id] = -1;
                        tab[plox.id][mover.id] = -1;
                        continue;
                    }
                    tab[mover.id][plox.id] = tab[plox.id][mover.id] = mover.Score(plox);
                }
            }
            return tab;
        }
        static public void PrintList<T>(this List<T> l, System.Func<T, string> f)
        {
            string tmp = "";
            foreach (var o in l)
                tmp += f(o) + " ";
            Console.WriteLine(tmp);
        }

        private static Random rng = new Random(0);

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

}
