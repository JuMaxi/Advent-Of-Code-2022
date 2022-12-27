using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022_Day03
{
    internal class Part01
    {
        internal void Solve01()
        {
            string Way = @"C:\Dev\AdventOfCode2022_Day01\AdventOfCode2022_Day03\Example1.txt";
            //string Way = @"C:\Dev\AdventOfCode2022_Day01\AdventOfCode2022_Day03\Input-Day03.txt";
            string[] Read = File.ReadAllLines(Way);
            
            char Same = 'A';
            string Priority = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] ValuePriority = new char[52];
            int SumValuePriority = 0;

            foreach (string ActualLine in Read)
            {
                List<char> FirstCompartment = new List<char>();
                List<char> SecondCompartment = new List<char>();

                for ( int Position = 0; Position < (ActualLine.Length/2); Position++)
                {
                    FirstCompartment.Add(ActualLine[Position]);
                }
                for(  int Position = (ActualLine.Length/2); Position < ActualLine.Length; Position++)
                {
                    SecondCompartment.Add(ActualLine[Position]);
                }
                
                for(int PositionFirstCompartment = 0; PositionFirstCompartment < FirstCompartment.Count; PositionFirstCompartment++)
                {
                    char Character = FirstCompartment[PositionFirstCompartment];

                    for(int PositionSecondCompartment = 0; PositionSecondCompartment < SecondCompartment.Count; PositionSecondCompartment++)
                    {
                        if(Character == SecondCompartment[PositionSecondCompartment])
                        {
                            Same = SecondCompartment[PositionSecondCompartment];
                        }
                    }
                }
                
                for(int Position = 0; Position < ValuePriority.Length; Position++)
                {
                    ValuePriority[Position] = Priority[Position];

                    if (ValuePriority[Position] == Same)
                    {
                        SumValuePriority = SumValuePriority + (Position + 1);
                        Position = 52;
                    }
                }
            }

            Console.WriteLine("The sum of prioritys is: " + SumValuePriority);
        }
    }

}
