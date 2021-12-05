using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string[] firstLine = sr.ReadLine().Split(',');
            List<int> numbers = new List<int>();


            foreach (string t in firstLine)
            {
                numbers.Add(int.Parse(t));
            }

            string line = sr.ReadLine();
            line = sr.ReadLine();


            List<Bingo> Bingos = new List<Bingo>();
            int index = 0;
            while (line != null)
            {
                List<string> BingoRows = new List<string>();

                while (true && line != null)
                {
                    if (line.Length < 1) break;
                    BingoRows.Add(line);

                    line = sr.ReadLine();
                }
                Bingos.Add(new Bingo(BingoRows, index));
                index++;


                line = sr.ReadLine();
            }

            bool checker = false;
            int boardIndex = 0;
            int lastNumber = 0;
            for (int n = 0; n < numbers.Count; n++)
            {
                checker = false;
                foreach (Bingo b in Bingos)
                {
                    checker = b.MarkNumber(numbers[n]);
                    if (checker && !b.HasBoardFinished)
                    {
                        Console.WriteLine("Bingo " + b.Index + " has solution at "+ n +" number:" +numbers[n] );
                        boardIndex = b.Index;
                        lastNumber = numbers[n];
                        b.HasBoardFinished = true;
                    }
                }
                if(Bingos.Where(u => u.HasBoardFinished).Count() == Bingos.Count)break;
            }
            Console.WriteLine("Last board is " + Bingos[boardIndex].Index);
            Bingos[boardIndex].PrintBoard();
            Bingos[boardIndex].sumOfAllNonMarked(lastNumber);
            Console.WriteLine("End of program");

            Console.ReadKey();

        }



        public class Bingo
        {
            public Bingo(List<string> BingoRows, int index)
            {
                Index = index;
                Board = new List<List<int>>();
                Marked = new List<List<bool>>();
                List<bool> MarkedVals = new List<bool>() { false, false, false, false, false };
                foreach (var t in BingoRows)
                {
                    MarkedVals = new List<bool>() { false, false, false, false, false };

                    string copy = t;
                    copy = Regex.Replace(copy, @"\s+", " ");
                    copy = copy.Trim();
                    List<string> temp1 = copy.Split(' ').ToList();
                    List<int> temp = temp1.Select(int.Parse).ToList();

                    Board.Add(temp);
                    Marked.Add(MarkedVals);

                }
            }
            public Tuple<int, bool> Values;
            public List<List<int>> Board;
            public List<List<bool>> Marked;
            public int Index;
            public bool HasBoardFinished = false;

            public bool MarkNumber(int value)
            {
                for(int i = 0; i<5; i++)
                {
                    for(int j = 0; j<5; j++)
                    {
                        if(Board[i][j] == value)
                        {
                            Marked[i][j] = true;
                            
                            return CheckForWin();
                        }
                    }
                }
                return false;
            }

            private bool CheckForWin()
            {
                for(int i=0; i<5; i++)
                {
                    if (
                        Marked[i][0] &&
                        Marked[i][1] &&
                        Marked[i][2] &&
                        Marked[i][3] &&
                        Marked[i][4])
                        //HasBoardFinished = true;
                        return true;
                    if (
                        Marked[0][i] &&
                        Marked[1][i] &&
                        Marked[2][i] &&
                        Marked[3][i] &&
                        Marked[4][i])
                        //HasBoardFinished = true;
                        return true;
                }
                return false;
            }

            public void sumOfAllNonMarked(int currentVal)
            {
                int sum = 0;
                for(int i = 0; i<5; i++)
                {
                    for(int j = 0; j<5; j++)
                    {
                        if (!Marked[i][j]) sum += Board[i][j];
                    }
                }
                Console.WriteLine("Sum is " + sum + " x " + currentVal + " = " + sum*currentVal);
            }
            public void PrintBoard()
            {

                for(int i = 0; i < 5; i++)
                {
                    for(int j = 0; j<5; j++)
                    {
                        Console.Write(Board[i][j]);
                        if (Board[i][j] < 10 && Marked[i][j] == true) Console.Write(". ");
                        if (Board[i][j] >= 10 && Marked[i][j] == true) Console.Write(".");
                        if (Board[i][j] < 10 && Marked[i][j] == false) Console.Write("  ");
                        if (Board[i][j] >= 10 && Marked[i][j] == false) Console.Write(" ");

                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }


        }

        private static void FirstPartSolution(List<int> numbers, List<Bingo> Bingos)
        {
            bool checker = false;
            for (int n = 0; n < numbers.Count; n++)
            {
                foreach (Bingo b in Bingos)
                {
                    checker = b.MarkNumber(numbers[n]);
                    if (checker)
                    {
                        Console.WriteLine("We found solution:");
                        b.PrintBoard();
                        b.sumOfAllNonMarked(numbers[n]);
                        break;
                    }
                }
                if (checker) break;
            }
        }
    }
}
