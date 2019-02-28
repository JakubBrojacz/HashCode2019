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
            for (int i = 0; i < N; i++)
            {
                int a = sh.Next(1, res.Length - 2);
                int b = sh.Next(1, res.Length - 2);
                int A1, A2, B1, B2;
                A1 = Functions.Score(res[a], res[a - 1]) + Functions.Score(res[a], res[a + 1]);
                A2 = Functions.Score(res[b], res[a - 1]) + Functions.Score(res[b], res[a + 1]);
                B1 = Functions.Score(res[b], res[b - 1]) + Functions.Score(res[b], res[b + 1]);
                B2 = Functions.Score(res[a], res[b - 1]) + Functions.Score(res[a], res[b + 1]);
                if (A1 + B1 < A2 + B2)
                {
                    Photo tmp = res[a];
                    res[a] = res[b];
                    res[b] = tmp;
                }
            }

            int Score = res.ToList<Photo>().Score();
            Console.WriteLine("------{0}-------", Score);
            return res;

        }
        public static Photo[] RunProbab(Photo[] input, int N)
        {
            Photo[] res = input.Merge().ToArray();
            Random sh = new Random();
            //Array.Sort(res, ((prop1, prop2) => sh.Next() % 3 - 1));
            for (int i = 0; i < N; i++)
            {
                int a = sh.Next(1, res.Length - 2);
                int b = sh.Next(1, res.Length - 2);
                int A1, A2, B1, B2;
                A1 = Functions.Score(res[a], res[a - 1]) + Functions.Score(res[a], res[a + 1]);
                A2 = Functions.Score(res[b], res[a - 1]) + Functions.Score(res[b], res[a + 1]);
                B1 = Functions.Score(res[b], res[b - 1]) + Functions.Score(res[b], res[b + 1]);
                B2 = Functions.Score(res[a], res[b - 1]) + Functions.Score(res[a], res[b + 1]);

                int prevSum = A1 + B1;
                int nextSum = A2 + B2;
                double coef;
                if (prevSum != 0)
                    coef = (nextSum - prevSum) / prevSum;
                else
                    coef = 1;

                if (coef > 0)
                {
                    Photo tmp = res[a];
                    res[a] = res[b];
                    res[b] = tmp;
                }
                else
                {
                    double r = sh.Next(1000) / 1000;
                    if (Math.Exp(coef * 7) < r)
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

namespace Project
    {
        public static class RandomSol2
        {
            public static Photo[] run2(Photo[] input, int N, Photo[] source)
            {
                Photo[] res = input;
                Random sh = new Random();
                //Array.Sort(res, ((prop1, prop2) => sh.Next() % 3 - 1));
                for (int i = 0; i < N; i++)
                {
                    int a = sh.Next(1, res.Length - 2);
                    int b = sh.Next(1, res.Length - 2);
                    int A1, A2, B1, B2;
                    A1 = Functions.Score(res[a], res[a - 1]) + Functions.Score(res[a], res[a + 1]);
                    A2 = Functions.Score(res[b], res[a - 1]) + Functions.Score(res[b], res[a + 1]);
                    B1 = Functions.Score(res[b], res[b - 1]) + Functions.Score(res[b], res[b + 1]);
                    B2 = Functions.Score(res[a], res[b - 1]) + Functions.Score(res[a], res[b + 1]);
                    int StartScore = A1 + B1;
                    int prevSum = A1 + B1;
                    int nextSum = A2 + B2;
                    double coef;
                    if (prevSum != 0)
                        coef = (nextSum - prevSum) / prevSum;
                    else
                        coef = 1;

                    if (coef > 0)
                    {
                        Photo tmp = res[a];
                        res[a] = res[b];
                        res[b] = tmp;
                        StartScore = A2 + B2;
                    }
                    else
                    {
                        double r = sh.Next(1000) / 1000;
                        if (Math.Exp(coef * 7) < r)
                        {
                            Photo tmp = res[a];
                            res[a] = res[b];
                            res[b] = tmp;
                            StartScore = A2 + B2;
                        }
                    }
                    //if (A1+B1<A2+B2)
                    //{
                    //    Photo tmp = res[a];
                    //    res[a] = res[b];
                    //    res[b] = tmp;
                    //    StartScore = A2 + B2;
                    //}
                    if (res[a].id2 != -1 && res[a].id2 != -1)
                    {
                        int a1, a2, b1, b2;
                        int aa = sh.Next(1);
                        if (aa == 0)
                        {
                            a1 = res[a].id;
                            a2 = res[a].id2;
                        }
                        else
                        {
                            a1 = res[a].id2;
                            a2 = res[a].id;
                        }
                        aa = sh.Next(1);
                        if (aa == 0)
                        {
                            b1 = res[b].id;
                            b2 = res[b].id2;
                        }
                        else
                        {
                            b1 = res[b].id2;
                            b2 = res[b].id;
                        }
                        Photo tmp1 = Photo.Concatenate(source[A1], source[B2]);
                        Photo tmp2 = Photo.Concatenate(source[A2], source[B1]);
                        int nextScore = tmp1.Score(res[a - 1]) + tmp1.Score(res[a + 1]) + tmp2.Score(res[b - 1]) + tmp2.Score(res[b + 1]);
                        prevSum = StartScore;
                        nextSum = nextScore;
                        if (prevSum != 0)
                            coef = (nextSum - prevSum) / prevSum;
                        else
                            coef = 1;

                        if (coef > 0)
                        {
                            res[a] = tmp1;
                            res[b] = tmp2;
                        }
                        else
                        {
                            double r = sh.Next(1000) / 1000;
                            if (Math.Exp(coef * 7) < r)
                            {
                                res[a] = tmp1;
                                res[b] = tmp2;
                            }
                        }
                        //if (nextScore>StartScore)
                        //{
                        //    res[a] = tmp1;
                        //    res[b] = tmp2;
                        //}


                    }

                }

                int Score = res.ToList<Photo>().Score();
                Console.WriteLine("------{0}-------", Score);
                return res;

            }
            public static Photo[] RunProbab2(Photo[] input, int N)
            {
                Photo[] res = input.Merge().ToArray();
                Random sh = new Random();
                //Array.Sort(res, ((prop1, prop2) => sh.Next() % 3 - 1));
                for (int i = 0; i < N; i++)
                {
                    int a = sh.Next(1, res.Length - 2);
                    int b = sh.Next(1, res.Length - 2);
                    int A1, A2, B1, B2;
                    A1 = Functions.Score(res[a], res[a - 1]) + Functions.Score(res[a], res[a + 1]);
                    A2 = Functions.Score(res[b], res[a - 1]) + Functions.Score(res[b], res[a + 1]);
                    B1 = Functions.Score(res[b], res[b - 1]) + Functions.Score(res[b], res[b + 1]);
                    B2 = Functions.Score(res[a], res[b - 1]) + Functions.Score(res[a], res[b + 1]);

                    int prevSum = A1 + B1;
                    int nextSum = A2 + B2;
                    double coef;
                    if (prevSum != 0)
                        coef = (nextSum - prevSum) / prevSum;
                    else
                        coef = 1;

                    if (coef > 0)
                    {
                        Photo tmp = res[a];
                        res[a] = res[b];
                        res[b] = tmp;
                    }
                    else
                    {
                        double r = sh.Next(1000) / 1000;
                        if (Math.Exp(coef) > r)
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

}
}
