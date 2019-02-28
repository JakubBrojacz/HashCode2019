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
            photos.Shuffle();
            return Merge(photos);
        }
    }
}
