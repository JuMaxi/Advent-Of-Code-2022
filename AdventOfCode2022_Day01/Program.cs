using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Authentication.ExtendedProtection;

namespace AdventOfCode2022_Day01
{
    internal class Program
    {
        private static int AddArray = 1;

        static int[] AddLenghtArray(int[] SumArray)
        {
            AddArray = AddArray + 1;

            int[] AddPositionArray = new int[AddArray];

            for (int PositionAdd = 0; PositionAdd < AddArray - 1; PositionAdd++)
            {
                AddPositionArray[PositionAdd] = SumArray[PositionAdd];
            }

            SumArray = AddPositionArray;

            return SumArray;
        }
        static void Main(string[] args)
        {
            //string Way = @"C:\Dev\AdventOfCode2022_Day01\Example.txt";
            string Way = @"C:\Dev\AdventOfCode2022_Day01\Input-Day01.txt";
            string[] ReadText = File.ReadAllLines(Way);

            int[] Numbers = new int[ReadText.Length];

            for (int Position = 0; Position < ReadText.Length; Position++)
            {
                if (ReadText[Position] == "")
                {
                    ReadText[Position] = "0";
                }

                Numbers[Position] = Convert.ToInt32(ReadText[Position]);
            }

            int[] SumCaloriesElf = new int[1];

            for (int Position = 0; Position < Numbers.Length; Position++)
            {
                if (Numbers[Position] == 0)
                {
                    SumCaloriesElf = AddLenghtArray(SumCaloriesElf);
                }

                SumCaloriesElf[AddArray - 1] = SumCaloriesElf[AddArray - 1] + Numbers[Position];
            }


            int MostCalories = 0;
            for (int PositionStart = 0; PositionStart < SumCaloriesElf.Length - 1; PositionStart++)
            {
                for (int Position = 0; Position < SumCaloriesElf.Length - 1; Position++)
                {
                    if (SumCaloriesElf[Position] > SumCaloriesElf[Position + 1])
                    {
                        MostCalories = SumCaloriesElf[Position];
                        SumCaloriesElf[Position] = SumCaloriesElf[Position + 1];
                        SumCaloriesElf[Position + 1] = MostCalories;
                    }
                }
            }

            int SumMostCalories = 0;
            for(int Position = SumCaloriesElf.Length-1; Position > SumCaloriesElf.Length-4; Position--)
            {
                SumMostCalories = SumMostCalories + SumCaloriesElf[Position];
            }

            Console.WriteLine("The Sum of three Elves with most calories is " + SumMostCalories);


        }

    }
}
