using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    static public class MainTutaj
    {
        static public void Main()
        {
            List<Photo> photos0 = Input.ReadDataOutput("a_example.txt", "0output.txt");
            List<Photo> photos1 = Input.ReadDataOutput("b_lovely_landscapes.txt", "1output.txt");
            List<Photo> photos2 = Input.ReadDataOutput("c_memorable_moments.txt", "2output.txt");
            List<Photo> photos3 = Input.ReadDataOutput("d_pet_pictures.txt", "3output.txt");
            List<Photo> photos4 = Input.ReadDataOutput("e_shiny_selfies.txt", "4output.txt");

            //0

            int PROB = 100000;
            var output1 = RandomSol.run2(photos1.ToArray(), PROB,Input.ReadData("b_lovely_landscapes.txt"));
            Console.WriteLine(output1.Score());
            Output.WriteData("tmp1.txt",output1.ToList());
            Console.ReadLine();


            //var sol = new RandomSolution2();
            //Func<Photo[], List<Photo>> Solution = new Func<Photo[], List<Photo>>(sol.Task);
            //int points = 0;
            //Photo[] tab = null;
            //List<Photo> s = null;
            //int i = 0;
            //string[] paths = { "a_example.txt", "b_lovely_landscapes.txt", "c_memorable_moments.txt", "d_pet_pictures.txt","e_shiny_selfies.txt" };
            //foreach (var path in paths)
            //{
            //    Console.WriteLine(path);
            //    tab = Input.ReadData(path);
            //    s = Solution(tab);
            //    points = s.Score();
            //    Output.WriteData(i+"output.txt", s);
            //    Console.WriteLine($"Points: {points}");
            //    Console.WriteLine("________");
            //    i++;
            //}
            return;
        }
    }
}
