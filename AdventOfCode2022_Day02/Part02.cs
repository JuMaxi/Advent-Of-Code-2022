using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022_Day02
{
    internal class Part02
    {
        static int ScoreRound(string[] BreakArray)
        {
            if ((BreakArray[1] == "X" && BreakArray[0] == "A")
                || (BreakArray[1] == "Y" && BreakArray[0] == "C")
                || (BreakArray[1] == "Z" && BreakArray[0] == "B"))
            {
                return 3;
            }
            else
            {
                if ((BreakArray[1] == "X" && BreakArray[0] == "B")
                || (BreakArray[1] == "Y" && BreakArray[0] == "A")
                || (BreakArray[1] == "Z" && BreakArray[0] == "C"))
                {
                    return 1;
                }
                else
                {
                    {
                        return 2;
                    }
                }
            }
        }
        internal void Solve02()
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

                if (BreakArray[1] == "Y")
                {
                    Draw = Draw + 3;
                }
                else
                {
                    if (BreakArray[1] == "Z")
                    {
                        Win = Win + 6;
                    }
                }
            }
            Console.WriteLine("Pontuacao total do jogador 2 e: " + (Score + Draw + Win));
        }
    }
}
