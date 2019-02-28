using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Project
{
    public class RandomSolution2
    {
        public List<Photo> Task(Photo[] photos)
        {
            var t = new System.Diagnostics.Stopwatch();
            var t1 = new System.Diagnostics.Stopwatch();
            var t2 = new System.Diagnostics.Stopwatch();
            //var unused = photos.ToList();
            var unused1 = photos.Merge();
            var unused = new LinkedList<Photo>(unused1);
            var solution = new List<Photo>(unused.Count);
            var current_photo = unused.First();
            solution.Add(current_photo);
            unused.Remove(current_photo);
            while(unused.Count>0)
            {
                if (unused.Count % 10000 == 0)
                    Console.WriteLine("aa");
                int sc = -1;
                Photo newPhoto = null;
                t.Start();
                newPhoto = unused.First();
                t.Stop();
                int it = 0;
                foreach (var ph in unused)
                {
                    if (it > 10)
                        break;
                    int tmp = ph.Score(current_photo);
                    if (tmp > sc)
                    {
                        sc = tmp;
                        newPhoto = ph;
                    }
                    it++;
                }
                if (newPhoto == null)
                    break;
                current_photo = newPhoto;
                //Console.WriteLine(current_photo.id);
                //unused.Remove(current_photo);
                t1.Start();
                unused.Remove(newPhoto);
                t1.Stop();
                t2.Start();
                solution.Add(current_photo);
                t2.Stop();
            }
            Console.WriteLine(t.ElapsedTicks);
            Console.WriteLine(t1.ElapsedTicks);
            Console.WriteLine(t2.ElapsedTicks);
            //solution.PrintList(p => p.id.ToString());
            if (photos.Count() > 1000)
                return RandomSol.RunProbab(solution.ToArray(), 100000).ToList();
            return solution;
        }
    }
}
