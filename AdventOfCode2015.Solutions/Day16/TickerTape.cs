using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day16
{
    internal class TickerTape
    {
        private readonly IDictionary<string, int> _compoundCounts = new Dictionary<string, int>
        {
            { "children", 3 },
            { "cats", 7 },
            { "samoyeds", 2 },
            { "pomeranians", 3 },
            { "akitas", 0 },
            { "vizslas", 0 },
            { "goldfish", 5 },
            { "trees", 3 },
            { "cars", 2 },
            { "perfumes", 1 },
        };

        public int GetMatchCount(string compoundName)
        {
            return _compoundCounts[compoundName];
        }
    }
}