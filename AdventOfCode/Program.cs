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
            int increasecounter = 0;


            int prev2x = int.Parse(line);
            line = sr.ReadLine();
            int prev = int.Parse(line);
            int sumOfdigits = 0;
            int current;
            int prevSum = 0; ;
            line= sr.ReadLine();
            string writeString;
            while (line != null)
            {
                current = int.Parse(line);
                sumOfdigits = prev2x + prev + current;

                if (sumOfdigits > prevSum && prevSum != 0)
                {
                    increasecounter++;
                    writeString = "Increased";

                }
                else
                {
                    writeString = "Not increased";

                }
                Console.WriteLine(sumOfdigits + writeString);

                //everything ready for new cycle
                prev2x = prev;
                prev = current;

                prevSum = sumOfdigits;
                line = sr.ReadLine();

                
            }
            Console.WriteLine(increasecounter);
            Console.ReadLine();


        }

        static void firstTask()
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
