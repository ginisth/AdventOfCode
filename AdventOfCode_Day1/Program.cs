using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode_Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dict = GetDaysAndPaths();

            do
            {
                Console.WriteLine("Type Day");

                if (Int32.TryParse(Console.ReadLine(), out int input))
                {
                    if (dict.TryGetValue(input, out string path))
                    {
                        string[] fileLines = File.ReadAllLines(path);
                        Uri uri = new Uri(path);
                        string className = uri.Segments.Last().Replace(".txt", string.Empty); //get the associated class name from the path,
                        string currentNamespace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                        string classFullName = currentNamespace + "." + className;
                        Type classType = Type.GetType(classFullName);
                        object newInstance = Activator.CreateInstance(classType, new object[] { fileLines });
                        object method = classType.GetMethod("MainCalculation").Invoke(newInstance, null);

                    }
                    else
                        Console.WriteLine("Value doesn't exists");
                }
                else
                    Console.WriteLine("Day should be an integer value");

            } while (CheckPoint());

            Console.Read();
        }

        static Dictionary<int, string> GetDaysAndPaths()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            string assembly = Assembly.GetExecutingAssembly().Location;
            string folderPath = assembly.Replace("bin\\Debug\\AdventOfCode_Day1.exe", "Inputs");
            FileInfo[] files = new DirectoryInfo(folderPath).GetFiles("*.txt");

            foreach (FileInfo file in files)
            {
                string day = Regex.Match(file.ToString(), @"\d+").Value;
                if (Int32.TryParse(day, out int dictKey))
                    dict.Add(dictKey, file.FullName);
            }

            return dict;
        }

        static bool CheckPoint()
        {
            Console.WriteLine("Press any key to continue or ESC to exit");
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape)
                Environment.Exit(1);

            return true;
        }

    }
}
