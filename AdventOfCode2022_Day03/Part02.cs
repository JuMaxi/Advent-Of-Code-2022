using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022_Day03
{
    internal class Part02
    {
        public char FindBadge(Rucksack Mochila1, Rucksack Mochila2, Rucksack Mochila3)
        {
            for (int PositionFirstCompartment = 0; PositionFirstCompartment < Mochila1.TodosItens.Length; PositionFirstCompartment++)
            {
                char Character = Mochila1.TodosItens[PositionFirstCompartment];

                if (Mochila2.TodosItens.IndexOf(Character) >= 0)
                {
                    if(Mochila3.TodosItens.IndexOf(Character) >= 0)
                    {
                        return Character;
                    }
                }
            }
            return ' ';
        }
        internal void Solve02()
        {
            //string Way = @"C:\Dev\AdventOfCode2022_Day01\AdventOfCode2022_Day03\Example1.txt";
            string Way = @"C:\Dev\AdventOfCode2022_Day01\AdventOfCode2022_Day03\Input-Day03.txt";
            string[] Read = File.ReadAllLines(Way);
            int Sum = 0;

            
            for (int Position = 0; Position < Read.Length; Position = Position + 3)
            {
                Rucksack mochila1 = new Rucksack();
                mochila1.Inicializar(Read[Position]);

                Rucksack mochila2 = new Rucksack();
                mochila2.Inicializar(Read[Position+1]);

                Rucksack mochila3 = new Rucksack();
                mochila3.Inicializar(Read[Position+2]);

                FindBadge(mochila1, mochila2, mochila3);

                int GetPriorityItem = mochila1.GetPriorityItem(FindBadge(mochila1, mochila2, mochila3));

                Sum = Sum + GetPriorityItem;
            }

            Console.WriteLine("The sum of group three Elves is: " + Sum);

        }

    }
}
