using System;
using System.Collections.Generic;
using System.IO;


namespace AdventOfCode_Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<int, string>();
            string[] fileLines;
            string className;
            object newInstance;
            Console.WriteLine("Type Day");
            dict.Add(1, "C:\\Day1.txt");
            if (Int32.TryParse(Console.ReadLine(), out int input))
            {
                if (dict.TryGetValue(input, out string path))
                {
                    fileLines = File.ReadAllLines(path);
                    className = path.Replace("C:\\", "AdventOfCode_Day1.").Replace(".txt", string.Empty);
                    Type type = Type.GetType(className);
                    newInstance = Activator.CreateInstance(type, new object[] { fileLines});
                    var method = type.GetMethod("MainCalculation");
                    method.Invoke(newInstance, null);
                }
            }
            else
            {
                Console.WriteLine("Wrong input");
                Console.Read();
                Environment.Exit(1);
            }




           // var fileLines = File.ReadAllLines("C:\\Day1.txt");
           

           

            Console.Read();
        }

       
    }
}
