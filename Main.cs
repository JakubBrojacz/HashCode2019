using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    static class MainTutaj
    {
        static public void Main()
        {
            var sol = new RandomSolution2();
            Func<Photo[], List<Photo>> Solution = new Func<Photo[], List<Photo>>(sol.Task);
            int points = 0;
            Photo[] tab = null;
            List<Photo> s = null;
            string[] paths = { "a_example.txt", "b_lovely_landscapes.txt", "c_memorable_moments.txt", "d_pet_pictures.txt","e_shiny_selfies.txt" };
            foreach (var path in paths)
            {
                Console.WriteLine(path);
                tab = Input.ReadData(path);
                s = Solution(tab);
                points = s.Score();
                //Output.WriteData("a_example.out", s);
                Console.WriteLine($"Points: {points}");
                Console.WriteLine("________");
            }
            return;
        }
    }
}
