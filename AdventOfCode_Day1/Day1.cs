using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day1
{
    public class Day1
    {
        public string[] FileLines { get; set; }
        int sumFuel = 0;
        int sumFuelOverFuel = 0;

        public Day1(string[] fileLines)
        {
            FileLines = fileLines;
        }

        public void MainCalculation()
        {
            foreach (var line in FileLines)
            {
                var mass = Convert.ToInt32(line);
                var fuel = CalculateEachModule(mass);
                var fuelOverFuel = CalculateEachModuleOverFuel(mass);
                sumFuel += fuel;
                sumFuelOverFuel += fuelOverFuel;
            }

            Console.WriteLine($"Sum: {sumFuel}");
            Console.WriteLine($"Sum Fuel over Fuel:{sumFuelOverFuel}");
        }

        static int CalculateEachModule(double x)
        {
            int roundedNum = (int)Math.Floor(x / 3);
            int fuel = roundedNum - 2;
            return fuel;
        }

        static int CalculateEachModuleOverFuel(double fuel)
        {
            int sumOverFuel = 0;

            do
            {
                int roundedNum = (int)Math.Floor(fuel / 3);
                fuel = roundedNum - 2;

                if (fuel > 0)
                    sumOverFuel += (int)fuel;
                else
                    return sumOverFuel;
            }
            while (true);
        }
    }
}
