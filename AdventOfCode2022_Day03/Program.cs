using System;

namespace AdventOfCode2022_Day03
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            Part01_new part01new = new Part01_new();
            part01new.Solve();

            Part01 Part01 = new Part01();

            Part01.Solve01();

            Part02 Part02 = new Part02();

            Part02.Solve02();
        }
    }
}
