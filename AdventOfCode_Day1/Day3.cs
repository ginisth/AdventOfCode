using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public class Day3 : AbstractDay
    {
        public Day3(string[] fileLines) : base(fileLines) { }

        public override void MainCalculation()
        {
            string[] wire1 = FileLines[0].Split(',');
            string[] wire2 = FileLines[1].Split(',');

            Dictionary<int, Pointer> routeMapOfWire1 = GetPointersForEachWire(wire1);
            Dictionary<int, Pointer> routeMapOfWire2 = GetPointersForEachWire(wire2);

            List<int> crosses = new List<int>();
            List<int> stepsOnCrossing = new List<int>();

            foreach (KeyValuePair<int, Pointer> route in routeMapOfWire1)
            {
                if (routeMapOfWire2.TryGetValue(route.Key, out var value))
                {
                    int distance = CalculateManhattanDistance(value.X, 0, value.Y, 0);
                    crosses.Add(distance);
                    stepsOnCrossing.Add(route.Value.PointerStep + value.PointerStep);
                }
            }

            int lowestCross = crosses.Min();
            int lowestStep = stepsOnCrossing.Min();

            Console.WriteLine("Lowest Cross: " + lowestCross);
            Console.WriteLine("Lowest Steps on Cross: " + lowestStep);
        }


        static Dictionary<int, Pointer> GetPointersForEachWire(string[] wire)
        {
            Dictionary<int, Pointer> routeMap = new Dictionary<int, Pointer>();
            bool firstIteration = true;

            foreach (string item in wire)
            {
                Pointer pointer;
                string direction = item.Substring(0, 1);
                int steps = Int32.Parse(Regex.Match(item, @"\d+").Value);
                if (firstIteration)
                {
                    pointer = new Pointer();
                    firstIteration = false;
                }
                else
                    pointer = routeMap.Values.Last();

                Dictionary<int, Pointer> routes = new Route(direction, steps).GetPoint(pointer);

                foreach (KeyValuePair<int, Pointer> route in routes)
                {
                    routeMap = AppendPointers(routeMap, route.Value);
                }
            }

            return routeMap;
        }


        static int CalculateManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }


        static Dictionary<int, Pointer> AppendPointers(Dictionary<int, Pointer> dict, Pointer pointer)
        {
            int key = pointer.GetHashCode();

            if (dict.TryGetValue(key, out _))
                dict.Remove(key);

            dict.Add(key, pointer);

            return dict;
        }



        public class Route
        {
            public string Direction { get; set; }
            public int Steps { get; set; }

            public Route(string direction, int steps)
            {
                Direction = direction;
                Steps = steps;
            }

            public Dictionary<int, Pointer> GetPoint(Pointer pointer)
            {
                Dictionary<int, Pointer> listOfPointers = new Dictionary<int, Pointer>();

                switch (Direction)
                {
                    case "R":
                        for (int step = 1; step < Steps + 1; step++)
                        {
                            Pointer tempPointer = new Pointer
                            {
                                X = pointer.X + step,
                                Y = pointer.Y,
                                PointerStep = pointer.PointerStep + step
                            };

                            listOfPointers = AppendPointers(listOfPointers, tempPointer);
                        }
                        break;
                    case "U":
                        for (int step = 1; step < Steps + 1; step++)
                        {
                            Pointer tempPointer = new Pointer
                            {
                                X = pointer.X,
                                Y = pointer.Y + step,
                                PointerStep = pointer.PointerStep + step
                            };

                            listOfPointers = AppendPointers(listOfPointers, tempPointer);
                        }
                        break;
                    case "D":
                        for (int step = 1; step < Steps + 1; step++)
                        {
                            Pointer tempPointer = new Pointer
                            {
                                X = pointer.X,
                                Y = pointer.Y - step,
                                PointerStep = pointer.PointerStep + step
                            };

                            listOfPointers = AppendPointers(listOfPointers, tempPointer);
                        }
                        break;
                    case "L":
                        for (int step = 1; step < Steps + 1; step++)
                        {
                            Pointer tempPointer = new Pointer
                            {
                                X = pointer.X - step,
                                Y = pointer.Y,
                                PointerStep = pointer.PointerStep + step
                            };

                            listOfPointers = AppendPointers(listOfPointers, tempPointer);
                        }
                        break;
                    default:
                        break;
                }

                return listOfPointers;
            }
        }


        public class Pointer
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int PointerStep { get; set; }

            public Pointer()
            {
                this.X = 0;
                this.Y = 0;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return X * 72647 + Y;
                }
            }
        }
    }
}
