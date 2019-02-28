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
            Func<Photo[], List<Photo>> Solution = new Func<Photo[], List<Photo>>();
            int points = 0;
            Photo[] tab = null;
            List<Photo> s = null;
            string[] paths = { "a_example.in", "b_small.in", "c_medium.in", "d_big.in" };
            foreach (var path in paths)
            {
                Console.WriteLine(path);
                tab = Input.ReadData(path);
                s = Solution(tab);
                points = CalcPoints(s);
                //Output.WriteData("a_example.out", s);
                Console.WriteLine($"Points: {points}");
                Console.WriteLine("________");
            }
            return;
        }
    }
}
