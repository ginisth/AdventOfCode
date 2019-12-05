using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            List<int> textToList = FileLines[0].Split(',').Select(int.Parse).ToList();


            int gravityassist = GetGravityAssist(textToList);
            Console.WriteLine($"Gravity Assist:{gravityassist}");

            CompleteGravityAssist(textToList);
        }

        public int GetGravityAssist(List<int> inputList)
        {
            List<int> initializeInputList = inputList.ToList();
            int sum = 0;

            for (int i = 0; i < initializeInputList.Count - 1; i += 4)
            {
                if (initializeInputList[i] == 99)
                    break;

                int firstNumPosition = i + 1;
                int secondNumPosotion = i + 2;
                int thirdNumPosition = i + 3;
                int firstNum = initializeInputList[firstNumPosition];
                int secondNum = initializeInputList[secondNumPosotion];
                int thirdNum = initializeInputList[thirdNumPosition];

                if (initializeInputList[i] == 1)
                    sum = initializeInputList[firstNum] + initializeInputList[secondNum];
                else if (initializeInputList[i] == 2)
                    sum = initializeInputList[firstNum] * initializeInputList[secondNum];

                initializeInputList[thirdNum] = sum;
            }
            return initializeInputList[0];
        }

        public void CompleteGravityAssist(List<int> inputList)
        {
            int tempGravityAssist = 0;

            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    List<int> initializeInputList = inputList.ToList();

                    initializeInputList[1] = noun;
                    initializeInputList[2] = verb;
                    tempGravityAssist = GetGravityAssist(initializeInputList);
                    if (tempGravityAssist == 19690720)
                    {
                        Console.WriteLine($"Complete Gravity Assist:{100 * noun + verb}");
                        break;
                    }
                }
            }
        }
    }
}
