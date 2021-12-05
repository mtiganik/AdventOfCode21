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
            bool CO2Check = false;

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
            List<int[]> discard = new List<int[]>();
            if (CO2Check)
            {
                GetDiscardedList(input, 0, 0);
            }
            else
            {
                GetDiscardedList(input, 0, 1);
            }

            for (int m= 1; m<input[0].Length; m++)
            {
                if (discard.Count == 1) break;

                lineSums = GetLineSums(discard);

                int valuetoCheck;
                if (CO2Check)
                {
                    if (lineSums[m] == 0) valuetoCheck = 1;
                    else valuetoCheck = 0;

                }
                else valuetoCheck = lineSums[m];


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
            return lineSums;

        }
    }
}
