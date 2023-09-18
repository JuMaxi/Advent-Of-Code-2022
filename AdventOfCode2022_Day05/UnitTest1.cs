
namespace AdventOfCode2022_Day06
{
    public class SolutionDay06
    {
        public int Part01(string input)
        {
            
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                int next = 1;

                bool equal = false;

                while (next <= 3)
                {
                    for(int ii = i + next; ii <= i + 3; ii++)
                    {
                        if (c == input[ii])
                        {
                            equal = true;
                            break;
                        }
                    }

                    c = input[i + next];
                    next++;
                }
                if (equal == false)
                {
                    return i + 4;
                }
            }

            return 0;
        }

        public int Part02(string input)
        {

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                int next = 1;

                bool equal = false;

                while (next <= 13)
                {
                    for (int ii = i + next; ii <= i + 13; ii++)
                    {
                        if (c == input[ii])
                        {
                            equal = true;
                            break;
                        }
                    }

                    c = input[i + next];
                    next++;
                }
                if (equal == false)
                {
                    return i + 14;
                }
            }

            return 0;
        }
    }

    public class Day06
    {
        [Fact]
        public void Day06_Part1()
        {
            SolutionDay06 solution = new();
            int resultA = solution.Part01("bvwbjplbgvbhsrlpgdmjqwftvncz");
            int resultB = solution.Part01("nppdvjthqldpwncqszvftbrmjlhg");
            int resultC = solution.Part01("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
            int resultD = solution.Part01("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");

            Assert.Equal(5, resultA);
            Assert.Equal(6, resultB);
            Assert.Equal(10, resultC);
            Assert.Equal(11, resultD);

            string text = File.ReadAllText("C:\\Dev\\Advent-Of-Code-2022\\AdventOfCode2022_Day05\\input_day06.txt");
            int result = solution.Part01(text);
        }

        [Fact]
        public void Day06_Part2()
        {
            SolutionDay06 solution = new();
            int resultA = solution.Part02("bvwbjplbgvbhsrlpgdmjqwftvncz");
            int resultB = solution.Part02("nppdvjthqldpwncqszvftbrmjlhg");
            int resultC = solution.Part02("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
            int resultD = solution.Part02("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
            int resultE = solution.Part02("mjqjpqmgbljsphdztnvjfqwrcgsmlb");

            Assert.Equal(23, resultA);
            Assert.Equal(23, resultB);
            Assert.Equal(29, resultC);
            Assert.Equal(26, resultD);
            Assert.Equal(19, resultE);

            string text = File.ReadAllText("C:\\Dev\\Advent-Of-Code-2022\\AdventOfCode2022_Day05\\input_day06.txt");
            int result = solution.Part02(text);

        }
    }
}