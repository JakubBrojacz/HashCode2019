using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Photo
    {
        public int id, id2=-1;
        public bool horizontal;
        public HashSet<string> tags;
        public int Score(Photo other)
        {
            return Math.Min(tags.Intersect(other.tags).Count(), Math.Min(tags.Except(other.tags).Count(), other.tags.Except(tags).Count()));
        }

        public static Photo Concatenate(Photo a,Photo b)
        {
            Photo res = new Photo();
            res.id = -1;
            res.horizontal = true;
            res.tags = new HashSet<string>();
            res.tags.UnionWith(a.tags);
            res.tags.UnionWith(b.tags);
            return res;
        }
    }
}
