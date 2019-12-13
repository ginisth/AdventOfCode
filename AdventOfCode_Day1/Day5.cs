using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public class Day5 : AbstractDay
    {
        public Day5(string[] fileLines) : base(fileLines) { }


        public override void MainCalculation()
        {
            List<int> input = FileLines[0].Split(',').Select(int.Parse).ToList();
            int part1 = Intcode(input, true);
            int part2 = Intcode(input, false);

            Console.WriteLine("Part1: " + part1);
            Console.WriteLine("Part2: " + part2);
        }

        public int Intcode(List<int> input, bool part1, int? Day7_PhaseSetting = null, int? Day7_Input = null)
        {
            List<int> numbers = input.ToList();
            int count = 0;
            bool Day7_firstInstruction = true;

            {
                while (numbers[count] != 99)
                {
                    int number = numbers[count];
                    int opCode = number % 10;
                    int parameter1Mode = (number / 100) % 10;
                    int parameter2Mode = (number / 1000) % 10;
                    switch (opCode)
                    {
                        case 1:
                        case 2:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            int param1 = parameter1Mode == 1 ? numbers[count + 1] : numbers[numbers[count + 1]];
                            int param2 = parameter2Mode == 1 ? numbers[count + 2] : numbers[numbers[count + 2]];
                            int address = numbers[count + 3];
                            int result = Opcode(opCode, param1, param2, count);

                            if (opCode != 5 && opCode != 6)
                            {
                                numbers[address] = result;
                                count += 4;
                            }
                            else
                                count = result;
                            break;
                        case 3:
                            //input
                            int case3param = numbers[count + 1];
                            if (Day7_PhaseSetting != null)
                            {
                                numbers[case3param] = AmplifierController(Day7_firstInstruction, (int)Day7_PhaseSetting, (int)Day7_Input);
                                Day7_firstInstruction = false;
                            }
                            else
                                numbers[case3param] = part1 ? 1 : 5;
                            count += 2;
                            break;
                        case 4:
                            if (numbers[count + 2] == 99)
                            {
                                int case4Addr = numbers[count + 1];
                                return numbers[case4Addr];
                            }
                            count += 2;
                            break;
                        default:
                            break;
                    }
                }

                return numbers[0];
            }
        }


        //count is valuable only for op 5 and 6
        private static int Opcode(int opCode, int param1, int param2, int count)
        {
            switch (opCode)
            {
                case 1:
                    return param1 + param2;
                case 2:
                    return param1 * param2;
                case 5:
                    return param1 != 0 ? param2 : count + 3;
                case 6:
                    return param1 == 0 ? param2 : count + 3;
                case 7:
                    return (param1 < param2) ? 1 : 0;
                case 8:
                    return (param1 == param2) ? 1 : 0;
                default:
                    throw new Exception();
            }
        }

        private static int AmplifierController(bool firstInstuction, int phaseSetting, int input)
        {
            return firstInstuction ? phaseSetting : input;
        }
    }
}
