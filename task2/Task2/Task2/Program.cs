using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Numerics;

namespace Task2
{
    class Program
    {
        static void Main(string[] args) {

            string n;
            //Console.WriteLine("Set File1 and then press Enter\n");
            //n = Console.ReadLine();

            string m;
            //Console.WriteLine("\nSet File2 and then press Enter\n");
            //m = Console.ReadLine();


            string[] read = Console.ReadLine().Split(' ');
            n = read[0];
            m = read[1];


            List<string> circlePoints = new List<string>();

            foreach (string line in File.ReadLines(n)) {
                circlePoints.Add(line);             
            }

            string s = circlePoints[0];

            MatchCollection matches = Regex.Matches(s, @"\d+");

            string[] result = matches.Cast<Match>()
                                     .Take(2)
                                     .Select(match => match.Value)
                                     .ToArray();

            


            float x = float.Parse(result[0]);

            float y = float.Parse(result[1]); 

            s = circlePoints[1];

            float radius = float.Parse(s);




            List<string> pointsString = new List<string>();

            List<Vector2> v2 = new List<Vector2>();

            foreach (string line in File.ReadLines(m)) {

                MatchCollection match = Regex.Matches(line, @"\d+");

                string[] res = match.Cast<Match>()
                                         .Take(2)
                                         .Select(match => match.Value)
                                         .ToArray();

                float px = float.Parse(res[0]);

                float py = float.Parse(res[1]);

                v2.Add(new Vector2(px, py));
            }

            Console.WriteLine();

            foreach (var vector in v2) {

                double d = Math.Sqrt(Math.Pow(vector.X - x, 2) + Math.Pow(vector.Y - y, 2));

                if (d == radius) {
                    Console.WriteLine("0 - точка лежит на окружности");
                }

                if (d < radius) {
                    Console.WriteLine("1 - точка внутри");
                }

                if (d > radius) {
                    Console.WriteLine("2 - точка снаружи");
                }  
            }

            Console.ReadKey(true);
        }
    }
}
