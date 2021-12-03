using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string line = sr.ReadLine();
            List<int[]> input = new List<int[]>();
            while(line != null)
            {
                int[] ints = new int[line.Length];
                for(int i = 0; i < line.Length; i++)
                {
                    ints[i] = line[i] -'0';
                }
                input.Add(ints);
                line = sr.ReadLine();
            }


            int[] lineSums = GetLineSums(input);

            // for O2 last index goes 1, for CO2 it goes 1
            List<int[]> discard = GetDiscardedList(input, 0, 0);
            for(int m= 1; m<input[0].Length; m++)
            {
                if (discard.Count == 1) break;
                for (int i = 0; i < discard.Count; i++)
                {
                    for (int j = 0; j < discard[0].Length; j++)
                    {
                        Console.Write(discard[i][j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Discard length: " + discard.Count());

                lineSums = GetLineSums(discard);

                int valuetoCheck;
                //for CO2
                if (lineSums[m] == 0) valuetoCheck = 1;
                else valuetoCheck = 0;
                //for O2
                //if (lineSums[m] == 1) valuetoCheck = 1;
                //else valuetoCheck = 0;


                discard = GetDiscardedList(discard, m, valuetoCheck);
            }
            Console.WriteLine("discard size:" + discard.Count());
            for(int i = 0; i < discard[0].Length; i++)
            {
                Console.Write(discard[0][i]);
            }


            Console.ReadKey();

        }

        static List<int[]> GetDiscardedList(List<int[]> input, int index, int valuesToCheck)
        {
            List<int[]> output = new List<int[]>();
            foreach(int[] t in input)
            {
                if (t[index] == valuesToCheck) output.Add(t);
            }

            return output;
        }

        static int[] GetLineSums(List<int[]> input)
        {
            int[] lineSums = new int[input[0].Length];
            int nulls = 0;
            int ones = 0;

            for (int j = 0; j < input[0].Length; j++)
            {
                 nulls = 0;
                 ones = 0;

                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i][j] == 0) nulls++;
                    else ones++;
                }
                if (nulls > ones)
                {
                    lineSums[j] = 0;
                }
                else
                {
                    lineSums[j] = 1;

                }
            }
            //Console.WriteLine("LineSum: zeros: " + nulls + " ones:" + ones);
            return lineSums;

        }
    }
}
