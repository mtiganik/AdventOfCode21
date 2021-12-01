using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("input.txt");
            string line = sr.ReadLine();

            int current = int.Parse(line);
            int previous;
            int increasecounter = 0;
            line = sr.ReadLine();

            while (line != null)
            {
                previous = current;
                current = int.Parse(line);
                if (current > previous)
                {
                    increasecounter++;
                    Console.WriteLine(increasecounter);
                }
                line = sr.ReadLine();

                
            }
            Console.WriteLine(increasecounter);
            Console.ReadLine();


        }


    }
}
