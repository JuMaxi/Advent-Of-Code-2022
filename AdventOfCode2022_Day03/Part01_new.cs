using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022_Day03
{
    
    internal class Rucksack
    {
        public string Bolso1;
        public string Bolso2;
        public string TodosItens;

        public void Inicializar(string line)
        {
            TodosItens = line;
            Bolso1 = line.Substring(0, (line.Length / 2));
            Bolso2 = line.Substring((line.Length/ 2), (line.Length / 2));
        }

        public char FindRepeatItem()
        {
            for (int PositionFirstCompartment = 0; PositionFirstCompartment < Bolso1.Length; PositionFirstCompartment++)
            {
                char Character = Bolso1[PositionFirstCompartment];
                if (Bolso2.IndexOf(Character) >= 0)
                {
                    return Character;
                }
            }
            return ' ';
        }
       
        public int GetPriorityItem(char ValuePriority)
        {
            string Priority = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if(Priority.IndexOf(ValuePriority) >= 0)
            {
                return (Priority.IndexOf(ValuePriority)) + 1;
            }
            return 0;
        }
    }

    internal class Part01_new
    {
        public void Solve()
        {
            int Sum = 0;
            //string Way = @"C:\Dev\AdventOfCode2022_Day01\AdventOfCode2022_Day03\Example1.txt";
            string Way = @"C:\Dev\AdventOfCode2022_Day01\AdventOfCode2022_Day03\Input-Day03.txt";
            string[] Read = File.ReadAllLines(Way);

            foreach (string line in Read)
            {
                Rucksack mochila = new Rucksack();
                mochila.Inicializar(line);
                char FindRepeatItem = mochila.FindRepeatItem();
                int GetPriorityItem = mochila.GetPriorityItem(FindRepeatItem);

                Sum = Sum + GetPriorityItem;
            }


            Console.WriteLine("Sum of priorities is: " + Sum);
        }
    }
}
