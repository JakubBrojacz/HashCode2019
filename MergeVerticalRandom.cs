using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public static class MergeVerticalRandom
    {
        public static List<Photo> Merge(this Photo[] photos)
        {
            int wasVertical = -1;
            List<Photo> newPhotos = new List<Photo>();
            for (int i = 0; i < photos.Length; i++)
            {
                if(!photos[i].horizontal)
                {
                    if (wasVertical == -1)
                    {
                        wasVertical = i;
                    }
                    else
                    {
                        foreach(var tag in photos[wasVertical].tags)
                        {
                            photos[i].tags.Add(tag);
                        }
                        photos[i].id2 = photos[i].id;
                        photos[i].id = photos[wasVertical].id;
                        newPhotos.Add(photos[i]);
                        wasVertical = -1;
                    }
                }
                else
                {
                    newPhotos.Add(photos[i]);
                }
            }
            if (wasVertical != -1)
                throw new Exception("Nieparzysta liczba wertykalnych");
            return newPhotos;

        }
        public static List<Photo> MergeRandom(this Photo[] photos)
        {
            List<Photo> newPhotos = new List<Photo>();
            List<Photo> verticals = new List<Photo>();
            for (int i = 0; i < photos.Length; i++)
            {
                if (!photos[i].horizontal)
                {
                    verticals.Add(photos[i]);
                }
                else
                {
                    newPhotos.Add(photos[i]);
                }
            }
            Random rand = new Random();
            while (verticals.Any())
            {
                int i1 = rand.Next()%verticals.Count;
                int i2 = rand.Next() % verticals.Count;
                if (i1 == i2)
                    continue;
                foreach (var tag in verticals[i1].tags)
                {
                    verticals[i2].tags.Add(tag);
                }
                verticals[i2].id2 = verticals[i1].id;
                newPhotos.Add(verticals[i2]);
                verticals.Remove(verticals[i1]);
                verticals.Remove(verticals[i2]);
            }
            return newPhotos;
        }
    }
}
