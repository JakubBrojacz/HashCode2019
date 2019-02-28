using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Project
{
    public static class Input
    {
        public static Photo[] ReadData(string path)
        {
            
            var lines = File.ReadLines(path);
            string firstLine = lines.First();
            string[] v = firstLine.Split(' ');
            int N = int.Parse(v[0]);
            Photo[] _return = new Photo[N];
            lines = lines.Skip(1);
            int id = 0;
            foreach (string line in lines)
            {
                Photo newPhoto = new Photo();
                newPhoto.id = id;
                newPhoto.id2 = -1;
                
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
                _return[id] = newPhoto;
                id++;
            }
            return _return;
        }
        public static List<Photo> ReadDataOutput(string pathInput, string pathOutput)
        {
            List<Photo> _return = new List<Photo>();
            Photo[] dupa = ReadData(pathInput);
            var lines = File.ReadLines(pathOutput);
            lines = lines.Skip(1);
            foreach (var line in lines)
            {
                string[] v = line.Split(' ');
                if(v.Length == 1)
                {
                    _return.Add(Array.Find(dupa, (x) => x.id == int.Parse(v[0])));
                }
                else
                {
                    _return.Add(Array.Find(dupa, (x) => x.id == int.Parse(v[0])));
                    _return.Add(Array.Find(dupa, (x) => x.id2 == int.Parse(v[1])));
                }
            }
            _return = (_return.ToArray().Merge());
            return _return;
        }
    }

    public static class Output
    {
        public static void WriteData(string path, List<Photo> photos)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path))
            {
                file.WriteLine(photos.Count);
                foreach (var photo in photos)
                {
                    if (photo.id2 != -1)
                        file.WriteLine(photo.id + " " + photo.id2);
                    else
                        file.WriteLine(photo.id);
                }
            }
        }
    }
}
