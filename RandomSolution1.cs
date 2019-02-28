using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    class RandomSolution1
    {
        public List<Photo> Task(Photo[] photos)
        {
            Console.WriteLine(photos.Count(f => !f.horizontal));
            var everyevery = photos.GenPairs();
            int N = photos.Count();
            bool[] used = new bool[N];
            List<Photo> solution = new List<Photo>();
            solution.Add(photos[0]);
            used[0] = true;
            int actId = 0;
            while(true)
            {
                
                actId = everyevery[actId].ArgMax(i => used[i]);
                Console.WriteLine(actId);
                Console.WriteLine(used[actId]);
                if (actId == -1)
                    break;
                used[actId] = true;
                solution.Add(photos[actId]);
                if (!photos[actId].horizontal)
                {
                    actId = photos.First(f => !f.horizontal).id;
                    used[actId] = true;
                    solution.Add(photos[actId]);
                }
            }
            return solution;
        }
    }
}
