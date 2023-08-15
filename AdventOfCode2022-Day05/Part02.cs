using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022_Day05
{
    
    internal class Part02
    {
        Part01 _part01 = new Part01();

        public List<Stack> OrganizeStacksToPart02(List<Stack> stacks, List<int> movesInt)
        {
            //Doing the moves in the list of stack to pop the item and save in the new stack in the correct order
            int index = 0;
            while (index < movesInt.Count)
            {
                List<char> tempStack= new List<char>();

                (int quantity, int fromStack, int toStack) = (movesInt[index], movesInt[index + 1], movesInt[index + 2]);

                for (int amount = 0; amount < quantity; amount++)
                {
                    var item = stacks[fromStack - 1].Pop();
                    tempStack.Add(item);
                }

                stacks = SaveNewOrderStack(tempStack, stacks, toStack);

                index = index + 3;
            }
            return stacks;
        }
        
        public List<Stack> SaveNewOrderStack(List<char> tempStack, List<Stack> stacks, int toStack)
        {
            //To save the crates(char) in the correct stack in the correct order
            for (int iTempStack = tempStack.Count - 1; iTempStack >= 0; iTempStack--)
            {
                stacks[toStack - 1].Push(tempStack[iTempStack]);
            }
            return stacks;
        }

        public void Solve02()
        {
            string[] File = _part01.ReadFile();

            List<string> cratesLines = _part01.SaveCratesToList(File);

            List<string> moves = _part01.SaveMovesToList(File);

            int numberStacks = _part01.FindNumberStacks(cratesLines);

            List<Stack> stacks = _part01.CreateListStacks(numberStacks);

            stacks = _part01.SaveCratesToEachStack(cratesLines, stacks);

            List<int> movesInt = _part01.GetMovements(moves);

            stacks = OrganizeStacksToPart02(stacks, movesInt);

            _part01.WriteFinalMessage(stacks);
        }
    }
}
