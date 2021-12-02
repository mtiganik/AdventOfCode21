using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("input.txt");
            string line = sr.ReadLine();
            List<Tuple<string, int>> input = new List<Tuple<string, int>>();
            while (line != null)
            {
                string[] temp = line.Split(' ');
                int value = int.Parse(temp[1]);
                string direction ="";
                if (temp[0] == "forward") direction = "forward";
                if (temp[0] == "down") direction = "down";
                if (temp[0] == "up") direction = "up";
                input.Add(Tuple.Create(direction, value));


                line = sr.ReadLine();
            }

            int aim = 0;
            int forward = 0;
            int depth = 0;
            foreach(var t in input)
            {
                Console.WriteLine(t.Item1 + t.Item2);
                if (t.Item1 == "down") aim += t.Item2;
                if (t.Item1 == "up") aim -= t.Item2;
                if (t.Item1 == "forward")
                {
                    forward += t.Item2;
                    depth += aim * t.Item2;
                }
            }

            Console.WriteLine("Depth =" + depth + " forward = " + forward);
            Console.WriteLine(depth * forward);

            Console.ReadKey();

        }

        static void firstTask(List<Tuple<string, int>> input)
        {
            int depth = 0;
            int forward = 0;
            foreach (var t in input)
            {
                Console.WriteLine(t.Item1 + t.Item2);
                if (t.Item1 == "forward") forward += t.Item2;
                if (t.Item1 == "down") depth += t.Item2;
                if (t.Item1 == "up") depth -= t.Item2;
            }

            Console.WriteLine("Depth =" + depth + " forward = " + forward);
            Console.WriteLine(depth * forward);
        }
    }
}
