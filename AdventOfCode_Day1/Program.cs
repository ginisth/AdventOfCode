using System;
using System.IO;


namespace AdventOfCode_Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumFuel = 0;
            int sumFuelOverFuel = 0;
            var fileLines = File.ReadAllLines("C:\\Day1.txt");
            foreach (var line in fileLines)
            {
                var mass = Convert.ToInt32(line);
                var fuel = CalculateEachModule(mass);
                var fuelOverFuel = CalculateEachModuleOverFuel(mass);
                sumFuel += fuel;
                sumFuelOverFuel += fuelOverFuel;
            }

            Console.WriteLine($"Sum: {sumFuel}");
            Console.WriteLine($"Sum Fuel over Fuel:{sumFuelOverFuel}");

            Console.Read();
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
