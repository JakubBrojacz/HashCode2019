using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Project
{
    public static class Input
    {
        public static List<Photo> ReadData(string path)
        {
            List<Photo> _return = new List<Photo>();
            var lines = File.ReadLines(path);
            string firstLine = lines.First();
            string[] v = firstLine.Split(' ');
            int N = int.Parse(v[0]);
            lines = lines.Skip(1);
            int id = 0;
            foreach (string line in lines)
            {
                Photo newPhoto = new Photo();
                newPhoto.id = id;
                id++;
                string[] vv = line.Split(' ');
                if (vv[0][0] == 'H')
                    newPhoto.horizontal = true;
                else
                    newPhoto.horizontal = false;
                newPhoto.tags = new HashSet<string>();
                for (int i = 2; i < vv.Length; i++)
                {
                    newPhoto.tags.Add(vv[i]);
                }
            }
            return _return;
        }
    }

    public static class Output
    {
        public static void WriteData(string path, List<Slice> list)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path))
            {
                file.WriteLine(list.Count);
                foreach (var v1 in list)
                {
                    file.WriteLine(v1.sx + " " + v1.sy + " " + (v1.ex - 1) + " " + (v1.ey - 1));
                }
            }
        }
    }
}
