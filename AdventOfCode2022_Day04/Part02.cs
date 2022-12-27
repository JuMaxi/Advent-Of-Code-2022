using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022_Day04
{
    internal class Part02
    {
        public int SumPairsRepeat(PairsElf Elfs)
        {
            if ((Elfs.Elf2Start <= Elfs.Elf1Finish && Elfs.Elf1Start <= Elfs.Elf2Finish))
            {
                return 1;
            }
            return 0;
        }
        public void Solve02()
        {
            //string Way = @"C:\Dev\AdventOfCode2022_Day01\AdventOfCode2022_Day04\Example-Day04.txt";
            string Way = @"C:\Dev\AdventOfCode2022_Day01\AdventOfCode2022_Day04\input-Day04.txt";
            string[] Read = File.ReadAllLines(Way);
            int Sum = 0;


            foreach (string Line in Read)
            {
                PairsElf FirstPar = new PairsElf();

                FirstPar.Initializar(Line);

                Sum = Sum + SumPairsRepeat(FirstPar);

            }
            Console.WriteLine("There are " + Sum + " pairs that are contain in other.");
        }
    }
}
