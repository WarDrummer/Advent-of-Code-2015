using System;
using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day24A : IProblem
    {
        private readonly MultiLineStringParser _parser;

        public Day24A() : this(new MultiLineStringParser("day24.in")) { }

        private Day24A(MultiLineStringParser parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var packageWeights = _parser.Parse().Select(s => int.Parse(s.Trim())).ToList();
            var totalWeight = packageWeights.Sum(w => w);
            var groupWeight = totalWeight / 3;

            var count = 0;
            foreach (var combo in SubsetSum.GetCombinations(packageWeights.ToArray(), groupWeight, ""))
            {
                count++;
            }
            Console.WriteLine(count);
            return "";
        }
    }
}
