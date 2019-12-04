using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day1
{
    public abstract class AbstractDay
    {
        protected string[] FileLines { get; set; }

        protected AbstractDay(string[] fileLines)
        {
            FileLines = fileLines;
        }

        public abstract void MainCalculation();
    }
}
