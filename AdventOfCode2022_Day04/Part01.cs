using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022_Day04
{

    internal class PairsElf
    {
        public int Elf1Start;
        public int Elf1Finish;
        public int Elf2Start;
        public int Elf2Finish;

        public void Initializar(string Line)
        {
            List<string> Part = BreakArray(Line);
            List<int> PartInt = ConvertInt(Part);

            Elf1Start = PartInt[0];
            Elf1Finish = PartInt[1];
            Elf2Start = PartInt[2];
            Elf2Finish = PartInt[3];
        }

        public List<string> BreakArray(string Line)
        {
            List<string> list = new List<string>();

            string[] BreakRead = Line.Split(',');

            foreach (string LineB in BreakRead)
            {
                string[] Break = LineB.Split("-");
                list.Add(Break[0]);
                list.Add(Break[1]);
            }
            return list;
        }

        public List<int> ConvertInt(List<string> list)
        {
            List<int> listint = new List<int>();

            foreach (string Line in list)
            {
                listint.Add(Convert.ToInt32(Line));
            }
            return listint;
        }


        public int SumAssigmentsPars()
        {
            if ((Elf1Start <= Elf2Start && Elf1Finish >= Elf2Finish)
                || (Elf1Start >= Elf2Start && Elf1Finish <= Elf2Finish))
            {
                return 1;
            }
            return 0;
        }
    }
    internal class Part01
    {
        public void Solve01()
        {
            //string Way = @"C:\Dev\AdventOfCode2022_Day01\AdventOfCode2022_Day04\Example-Day04.txt";
            string Way = @"C:\Dev\AdventOfCode2022_Day01\AdventOfCode2022_Day04\input-Day04.txt";
            string[] Read = File.ReadAllLines(Way);
            int Sum = 0;


            foreach (string Line in Read)
            {
                PairsElf FirstPar = new PairsElf();

                FirstPar.Initializar(Line);

                Sum = Sum + FirstPar.SumAssigmentsPars();
            }
            Console.WriteLine("There are " + Sum + " " +
                "pairs that are fully contain in other.");












        }
    }
}
