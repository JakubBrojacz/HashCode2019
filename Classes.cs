using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Collection
    {
        Photo[] photos;
    }
    class Photo
    {
        public int id;
        public bool horizontal;
        public List<string> tags;
    }
}
