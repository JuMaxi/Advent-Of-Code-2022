using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022_Day02
{
    internal class Part01
    {

        static int ScoreRound(string[] BreakArray)
        {
            if (BreakArray[1] == "X")
            {
                return 1;
            }
            else
            {
                if (BreakArray[1] == "Y")
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
        }
        static bool WasDraw(string[] BreakArray)
        {
            return (BreakArray[0] == "A" && BreakArray[1] == "X")
                     || (BreakArray[0] == "B" && BreakArray[1] == "Y")
                     || (BreakArray[0] == "C" && BreakArray[1] == "Z");
        }

        static bool Won(string[] BreakArray)
        {
            return (BreakArray[1] == "Z" && BreakArray[0] == "B")
                     || (BreakArray[1] == "Y" && BreakArray[0] == "A")
                     || (BreakArray[1] == "X" && BreakArray[0] == "C");
        }
        internal void Solve01()
        {
            //string Way = @"C:\Dev\AdventOfCode2022_Day02\Example.txt";
            string Way = @"C:\Dev\AdventOfCode2022_Day02\Input-Day02.txt";
            string[] Round = File.ReadAllLines(Way);
            int Draw = 0;
            int Score = 0;
            int Win = 0;

            foreach (string Line in Round)
            {
                string[] BreakArray = Line.Split(" ");

                Score = Score + ScoreRound(BreakArray);

                if (WasDraw(BreakArray))
                {
                    Draw = Draw + 3;
                }
                else
                {
                    if (Won(BreakArray))
                    {
                        Win = Win + 6;
                    }
                }
            }
            Console.WriteLine("Pontuacao total do jogador 2 e: " + (Score + Draw + Win));
        }
    }
}
