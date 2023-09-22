using System.Collections.Generic;

namespace AdventOfCode2022_Day07
{
    public class SolutionDay07
    {
        public class Directory
        {
            public long Size { get; set; }
            public string Name { get; set; }

        }
        public long Part01(string[] input)
        {
            List<Directory> alreadyCalculated = new();
            List<Directory> actualPath = new();

            foreach (string line in input)
            {
                actualPath = CheckIfIsCd(line, actualPath);
                actualPath = CheckIfIsFile(line, actualPath);


                if (line.EndsWith("..") || line == input[input.Length - 1])
                {
                    actualPath[actualPath.Count - 2].Size += actualPath[actualPath.Count - 1].Size;

                    alreadyCalculated.Add(actualPath[actualPath.Count - 1]);
                    actualPath.RemoveAt(actualPath.Count - 1);
                }
            }

            long sum = ReturnSumCdLessOrEqual100_000(alreadyCalculated);

            return sum;
        }

        public List<Directory> CheckIfIsCd(string line, List<Directory> actualPath)
        {
            Directory directory = new();

            if (line.Contains("$ cd"))
            {
                if (!line.Contains(".."))
                {
                    directory.Name = line;
                    actualPath.Add(directory);
                }
            }
            return actualPath;
        }

        public List<Directory> CheckIfIsFile(string line, List<Directory> actualPath)
        {
            Directory directory = new();

            if (!line.StartsWith("$") && !line.StartsWith("d"))
            {
                int number = Convert.ToInt32(line.Split(" ")[0]);
                directory.Size = number;
                actualPath[actualPath.Count - 1].Size += directory.Size;
            }
            return actualPath;
        }

        public long ReturnSumCdLessOrEqual100_000(List<Directory> alreadyCalculated)
        {
            long sum = 0;
            foreach(Directory cd in alreadyCalculated)
            {
                if(cd.Size <= 100_000)
                {
                    sum += cd.Size;
                }
            }
            return sum;
        }

    }
    public class Day07
    {
        [Fact]
        public void Day07_Part1()
        {
            SolutionDay07 solution = new();
            //string[] input = File.ReadAllLines("C:\\Dev\\Advent-Of-Code-2022\\AdventOfCode2022_Day07\\input-example.txt");
            string[] input = File.ReadAllLines("C:\\Dev\\Advent-Of-Code-2022\\AdventOfCode2022_Day07\\input-day07.txt");

            long result = solution.Part01(input);

            Assert.Equal(95437, result);
        }
    }
}