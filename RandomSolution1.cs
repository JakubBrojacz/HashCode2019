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
            var everyevery = photos.GenPairs();
            int N = photos.Count();
            bool[] used = new bool[N];
            List<Photo> solution = new List<Photo>();
            solution.Add(photos[0]);
            used[0] = true;
            int actId = 0;
            while(true)
            {
                int newId = everyevery[0]
            }
        }
    }
}
