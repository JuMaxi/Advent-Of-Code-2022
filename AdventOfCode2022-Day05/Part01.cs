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
        public void Solve01()
        {
            //Reading the file and saving it in an Array of string.
            //string Way = @"C:\Dev\Advent-Of-Code-2022\AdventOfCode2022-Day05\Example-Day05.txt";
            string Way2 = @"C:\Dev\Advent-Of-Code-2022\AdventOfCode2022-Day05\input-Day05.txt";

            string[] Read = File.ReadAllLines(Way2);


            //Save the crates in a List<string>
            int i = 0;
            List<string> cratesLines = new List<string>();
            while (Read[i] != "")
            {
                cratesLines.Add(Read[i]);
                i++;
            }

            //Save the moves in a List<string>
            int ii = i + 1;
            List<string> moves = new List<string>();
            while (ii < Read.Length)
            {
                moves.AddRange(Read[ii].Split(" "));
                ii++;
            }

            //Find the number of Stacks
            string total = cratesLines[cratesLines.Count - 1];
            int numberStacks = Convert.ToInt32(total[total.Length - 2].ToString());

            //Creating the list of stacks.
            var stacks = new List<Stack>();
            for (int x = 0; x < numberStacks; x++)
            {
                stacks.Add(new Stack());
            }

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

            List<int> m = GetMovements(moves);

            //Doing the moves in each Stack to return the list organized with the final message.
            int index = 0;
            while (index < m.Count)
            {
                (int quantity, int fromStack, int toStack) = (m[index], m[index + 1], m[index + 2]);

                for (int amount = 0; amount < quantity; amount++)
                {
                    var item = stacks[fromStack - 1].Pop();
                    stacks[toStack - 1].Push(item);
                }

                index = index + 3;
            }

            //Write the final message
            foreach(Stack l in stacks)
            {
                l.WriteMessage();
            }
        }


        //Take the moves of the file and convert to a list of int
        private static List<int> GetMovements(List<string> moves)
        {
            List<int> m = new List<int>();

            for(int i = 1; i < moves.Count; i = i + 2)
            {
                m.Add(Convert.ToInt32(moves[i]));
            }

            return m;
        }















    }
}

