using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Photo
    {
        public int id;
        public bool horizontal;
        public HashSet<string> tags;
        public int Score(Photo other)
        {
            return Math.Min(tags.Intersect(other.tags).Count(), Math.Min(tags.Except(other.tags).Count(), other.tags.Except(tags).Count()));
        }
    }
}
