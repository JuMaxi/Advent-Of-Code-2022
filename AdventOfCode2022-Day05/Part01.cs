using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode2022_Day05
{
    public class Stack
    {
        private List<char> _list = new List<char>();

        public bool IsEmpty()
        {
            return _list.Count() == 0;
        }

        public void Push(char item) //Push: Add an item on the top of the stack
        {
            _list.Add(item);
        }

        public char Pop() //Pop: Removes and returns an item from the top of the stack
        {
            char item = _list.Last();
            _list.RemoveAt(_list.Count - 1);
            return item;
        }

        public void WriteMessage()
        {
            Console.WriteLine(_list.Last());
        }
    }

    internal class Part01
    {
        int i = 0;

        public string[] ReadFile()
        {
            //Reading the file and saving it in an Array of string.
            //string Way = @"C:\Dev\Advent-Of-Code-2022\AdventOfCode2022-Day05\Example-Day05.txt";
            string Way2 = @"C:\Dev\Advent-Of-Code-2022\AdventOfCode2022-Day05\input-Day05.txt";

            string[] Read = File.ReadAllLines(Way2);

            return Read;
        }

        public List<string> SaveCratesToList(string[] Read)
        {
            //Save the crates in a List<string>
            List<string> cratesLines = new List<string>();
            while (Read[i] != "")
            {
                cratesLines.Add(Read[i]);
                i++;
            }

            return cratesLines;
        }
        public List<string> SaveMovesToList(string[] Read)
        {
            //Save the moves in a List<string>
            int ii = i + 1;
            List<string> moves = new List<string>();
            while (ii < Read.Length)
            {
                moves.AddRange(Read[ii].Split(" "));
                ii++;
            }

            return moves;
        }

        public int FindNumberStacks(List<string> cratesLines)
        {
            //Find the number of Stacks
            string total = cratesLines[cratesLines.Count - 1];
            int numberStacks = Convert.ToInt32(total[total.Length - 2].ToString());

            return numberStacks;
        }

        public List<Stack> CreateListStacks(int numberStacks)
        {
            // Creating the list of stacks.
            var stacks = new List<Stack>();
            for (int x = 0; x < numberStacks; x++)
            {
                stacks.Add(new Stack());
            }

            return stacks;
        }

        public List<Stack> SaveCratesToEachStack(List<string> cratesLines, List<Stack> stacks)
        {
            //Save the crates inside each list of Stack
            for (int x = cratesLines.Count - 2; x >= 0; x--)
            {
                string line = cratesLines[x];
                int stackNumber = 0;
                for (int position = 1; position < line.Length; position = position + 4)
                {
                    if (line[position] != ' ')
                    {
                        stacks[stackNumber].Push(line[position]);
                    }
                    stackNumber++;
                }
            }
            return stacks;
        }
        private static List<int> GetMovements(List<string> moves)
        {
            //Take the moves of the file and convert to a list of int
            List<int> movesInt = new List<int>();

            for (int i = 1; i < moves.Count; i = i + 2)
            {
                movesInt.Add(Convert.ToInt32(moves[i]));
            }

            return movesInt;
        }

        public List<Stack> OrganizeMoveStacks(List<Stack> stacks, List<int> movesInt)
        {
            //Doing the moves in each Stack to return the list organized with the final message.
            int index = 0;
            while (index < movesInt.Count)
            {
                (int quantity, int fromStack, int toStack) = (movesInt[index], movesInt[index + 1], movesInt[index + 2]);

                for (int amount = 0; amount < quantity; amount++)
                {
                    var item = stacks[fromStack - 1].Pop();
                    stacks[toStack - 1].Push(item);
                }

                index = index + 3;
            }
            return stacks;
        }

        public void WriteFinalMessage(List<Stack> stacks)
        {
            //Write the final message
            foreach (Stack l in stacks)
            {
                l.WriteMessage();
            }
        }
        public void Solve01()
        {
            string[] File = ReadFile();

            List<string> cratesLines = SaveCratesToList(File);

            List<string> moves = SaveMovesToList(File);

            int numberStacks = FindNumberStacks(cratesLines);

            List<Stack> stacks = CreateListStacks(numberStacks);

            stacks = SaveCratesToEachStack(cratesLines, stacks);
            
            List<int> movesInt = GetMovements(moves);

            stacks = OrganizeMoveStacks(stacks, movesInt);

            WriteFinalMessage(stacks);
        }

        
    }
}

