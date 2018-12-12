using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day13B : Day13A
    {
        public override string Solve()
        {
            var names = new List<string>();
            var lookup = new Dictionary<string, int>();
            GetNamesAndLookupTable(lookup, names);
            names.Add("WarDrums");
            return GetHighScore(names, lookup).ToString();
        }
    }
}
