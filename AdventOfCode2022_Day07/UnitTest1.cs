namespace AdventOfCode2022_Day07
{
    public class SolutionDay07
    {
        public int Part01(string[] input)
        {
            int sum = 0;
            int sumDir = 0;
            int sumValueDir = 0;
            bool changeDiretory = false;

            for (int i = 1; i < input.Length; i++ )
            {
                string line = input[i];

                if (line.Contains("$ cd"))
                {
                    if (!line.Contains("$ cd .."))
                    {
                        sumDir++;
                    }
                    else
                    {
                        sumDir--;
                    }
                }

                if (!line.StartsWith('$') && !line.StartsWith('d'))
                {
                    string[] n = line.Split(' ');

                    int number = Convert.ToInt32(n[0]);

                    if (number <= 100000)
                    {
                        number = number * sumDir;
                        sumValueDir += number;
                    }
                }

                if (i < input.Length - 1)
                {
                    if (input[i + 1].Contains("$ cd"))
                    {
                        changeDiretory = true;
                    }
                }

                if (changeDiretory)
                {
                    if (sumValueDir <= 100000)
                    {
                        sum += sumValueDir;
                        sumValueDir = 0;
                    }

                    changeDiretory = false;
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

            int result = solution.Part01(input);

            Assert.Equal(95437, result);
        }
    }
}