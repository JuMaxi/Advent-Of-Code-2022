using System;
using System.IO;
using System.Net;

namespace AdventOfCode2022_Day02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Part01 Part01 = new Part01();

            Part01.Solve01();

            Part02 Part02 = new Part02();

            Part02.Solve02();
        }
    }
}
