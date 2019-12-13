using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public class Day7 : AbstractDay
    {
        public Day7(string[] fileLines) : base(fileLines) { }


        public override void MainCalculation()
        {
            List<int> inputList = FileLines[0].Split(',').Select(int.Parse).ToList();
            List<int> finalSignals = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        for (int p = 0; p < 5; p++)
                        {
                            for (int l = 0; l < 5; l++)
                            {
                                int[] phaseSettings = new int[] { i, j, k, p, l };

                                if (phaseSettings.Count() == phaseSettings.Distinct().Count())
                                {
                                    Day5 day5 = new Day5(FileLines);
                                    int outputAmplifier1 = day5.Intcode(inputList, false, i, 0);
                                    int outputAmplifier2 = day5.Intcode(inputList, false, j, outputAmplifier1);
                                    int outputAmplifier3 = day5.Intcode(inputList, false, k, outputAmplifier2);
                                    int outputAmplifier4 = day5.Intcode(inputList, false, p, outputAmplifier3);
                                    int outputAmplifier5 = day5.Intcode(inputList, false, l, outputAmplifier4);
                                    finalSignals.Add(outputAmplifier5);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Highest Signal: " + finalSignals.Max());
        }
    }
}
