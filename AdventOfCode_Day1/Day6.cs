using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public class Day6 : AbstractDay
    {
        public Day6(string[] fileLines) : base(fileLines) { }


        public override void MainCalculation()
        {
            List<Element> orbitList = new List<Element>();
            List<string> parentObject = new List<string>();
            List<string> childObject = new List<string>();
            List<int> orbitsCounterList = new List<int>();
            Dictionary<string, int> SANroute = new Dictionary<string, int>();
            Dictionary<string, int> YOUroute = new Dictionary<string, int>();

            foreach (string fileline in FileLines)
            {
                string[] orbit = fileline.Split(')');
                orbitList.Add(new Element { Parent = orbit[0], Child = orbit[1] });
                parentObject.Add(orbit[0]);
                childObject.Add(orbit[1]);
            }

            //COM
            string parentOfParents = parentObject.Where(x => !childObject.Contains(x)).FirstOrDefault();

            foreach (Element element in orbitList)
            {
                int count = 1;
                string parent = element.Parent;
                while (parent != parentOfParents)
                {
                    if (element.Child == "SAN")
                        SANroute.Add(parent, count);
                    if (element.Child == "YOU")
                        YOUroute.Add(parent, count);

                    count++;
                    parent = orbitList.Where(x => x.Child == parent).Select(x => x.Parent).FirstOrDefault();
                }
                orbitsCounterList.Add(count);
            }
            Console.WriteLine("Total Orbits: " + orbitsCounterList.Sum());


            string firstCommonKey = YOUroute.Keys.Intersect(SANroute.Keys).FirstOrDefault();

            if (YOUroute.TryGetValue(firstCommonKey, out int YOUorbitalTransfers) && SANroute.TryGetValue(firstCommonKey, out int SANorbitalTransfers))
                Console.WriteLine("Minimun Orbital Transfers :" + (YOUorbitalTransfers + SANorbitalTransfers - 2));
        }
    }

    public class Element
    {
        public string Parent { get; set; }
        public string Child { get; set; }
    }
}
