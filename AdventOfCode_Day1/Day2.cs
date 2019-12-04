using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day1
{
    public class Day2 : AbstractDay
    {
        public Day2(string[] fileLines) : base(fileLines) { }

        public override void MainCalculation()
        {
            string[] text = FileLines[0].Split(',');
            List<int> newList = new List<int>();
            foreach (var item in text)
            {
                newList.Add(Convert.ToInt32(item));
            }
            int sum = 0;

            for (int i = 0; i < newList.Count - 1; i += 4)
            {
                int firstNumPosition;
                int secondNumPosotion;
                int thirdNumPosition;
                int firstNum;
                int secondNum;
                int thirdNum;


                if (newList[i] == 1)
                {
                    firstNumPosition = i + 1;
                    secondNumPosotion = i + 2;
                    thirdNumPosition = i + 3;
                    firstNum = newList[firstNumPosition];
                    secondNum = newList[secondNumPosotion];
                    thirdNum = newList[thirdNumPosition];

                    sum = newList[firstNum] + newList[secondNum];
                    newList[thirdNum] = sum;
                }
                else if (newList[i] == 2)
                {
                    firstNumPosition = i + 1;
                    secondNumPosotion = i + 2;
                    thirdNumPosition = i + 3;
                    firstNum = newList[firstNumPosition];
                    secondNum = newList[secondNumPosotion];
                    thirdNum = newList[thirdNumPosition];

                    sum = newList[firstNum] * newList[secondNum];
                    newList[thirdNum] = sum;
                }
                else if (newList[i] == 99)
                {
                    Console.WriteLine($"Day2--{newList[0]}");
                    break;
                }
            }
        }
    }
}
