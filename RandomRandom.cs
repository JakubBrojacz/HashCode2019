using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public static class RandomSol
    {
        public static Photo[] run(Photo[] input, int N)
        {
            Photo[] res = input.Merge().ToArray();
            Random sh = new Random();
            //Array.Sort(res, ((prop1, prop2) => sh.Next() % 3 - 1));
            for (int i=0;i<N;i++)
            {
                int a = sh.Next(1,res.Length-2);
                int b = sh.Next(1,res.Length-2);
                int A1, A2, B1, B2;
                A1 = Functions.Score(res[a], res[a - 1]) + Functions.Score(res[a], res[a + 1]);
                A2 = Functions.Score(res[b], res[a - 1]) + Functions.Score(res[b], res[a + 1]);
                B1 = Functions.Score(res[b], res[b - 1]) + Functions.Score(res[b], res[b + 1]);
                B2 = Functions.Score(res[a], res[b - 1]) + Functions.Score(res[a], res[b + 1]);
                if (A1+B1<A2+B2)
                {
                    Photo tmp = res[a];
                    res[a] = res[b];
                    res[b] = tmp;
                }
            }

            int Score = res.ToList<Photo>().Score();
            Console.WriteLine("------{0}-------",Score);
            return res;

        }
        public static Photo[] RunProbab(Photo[] input)
        {
            Photo[] res = input.Merge().ToArray();
            Random sh = new Random();
            //Array.Sort(res, ((prop1, prop2) => sh.Next() % 3 - 1));
            for (int i = 0; i < 9999; i++)
            {
                int a = sh.Next(1, res.Length - 2);
                int b = sh.Next(1, res.Length - 2);
                int A1, A2, B1, B2;
                A1 = Functions.Score(res[a], res[a - 1]) + Functions.Score(res[a], res[a + 1]);
                A2 = Functions.Score(res[b], res[a - 1]) + Functions.Score(res[b], res[a + 1]);
                B1 = Functions.Score(res[b], res[b - 1]) + Functions.Score(res[b], res[b + 1]);
                B2 = Functions.Score(res[a], res[b - 1]) + Functions.Score(res[a], res[b + 1]);

                int tmpFF = sh.Next(100);
                if (A1 + B1 < A2 + B2)
                {
                    if (tmpFF > 3)
                    {
                        Photo tmp = res[a];
                        res[a] = res[b];
                        res[b] = tmp;
                    }
                }
                else
                {
                    if(tmpFF <= 3)
                    {
                        Photo tmp = res[a];
                        res[a] = res[b];
                        res[b] = tmp;
                    }
                }
               
            }

            int Score = res.ToList<Photo>().Score();
            Console.WriteLine("------{0}-------", Score);
            return res;

        }
    }
}
