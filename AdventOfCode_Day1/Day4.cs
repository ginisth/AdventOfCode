using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public class Day4 : AbstractDay
    {
        public Day4(string[] fileLines) : base(fileLines) { }


        public override void MainCalculation()
        {
            string[] text = FileLines[0].Split('-');
            int from = Convert.ToInt32(text[0]);
            int to = Convert.ToInt32(text[1]);
            List<List<int>> listOfDiffPass = new List<List<int>>();
            int countDiffPassPart1 = 0;
            var countDiffPassPart2 = 0;

            for (int number = from; number <= to; number++)
            {
                List<int> digits = DigitsOfNumber(number).Reverse().ToList();


                if (digits[0] <= digits[1] && digits[1] <= digits[2] && digits[2] <= digits[3] && digits[3] <= digits[4] && digits[4] <= digits[5])
                {
                    if (digits.GroupBy(x => x).Any(z => z.Count() > 1))
                    {
                        countDiffPassPart1++;
                        listOfDiffPass.Add(digits);
                    }
                }
            }


            foreach (var diffPass in listOfDiffPass)
            {
                for (int i = 0; i < diffPass.Count(); i++)
                {
                    if (diffPass.Count(c => c.Equals(diffPass[i])) == 2)
                    {
                        countDiffPassPart2++;
                        break;
                    }
                }
            }

            Console.WriteLine("Different Passwords of Part1: " + countDiffPassPart1);
            Console.WriteLine("Different Passwords of Part2: " + countDiffPassPart2);
        }


        static IEnumerable<int> DigitsOfNumber(int number)
        {
            while (number > 0)
            {
                int digit = number % 10;
                number /= 10;
                yield return digit;
            }
        }
    }
}
