using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class RandomSolution2
    {
        public List<Photo> Task(Photo[] photos)
        {
            var unused = photos.Merge();
            var solution = new List<Photo>();
            var current_photo = unused.First();
            solution.Add(current_photo);
            unused.RemoveAt(0);
            while(unused.Any())
            {
                int sc = -1;
                Photo newPhoto = null;
                //newPhoto = unused.First();
                foreach (var ph in unused)
                {
                    int tmp = ph.Score(current_photo);
                    if (tmp > sc)
                    {
                        sc = tmp;
                        newPhoto = ph;
                    }
                }
                if (newPhoto == null)
                    break;
                current_photo = newPhoto;
                unused.Remove(current_photo);
                solution.Add(current_photo);
            }
            return solution;
        }
    }
}
