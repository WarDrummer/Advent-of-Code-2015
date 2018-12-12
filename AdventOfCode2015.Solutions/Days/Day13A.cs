using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
    using ParserType = MultiLineStringParser;

    public class Day13A : IProblem
	{
		protected readonly ParserType Parser;

		public Day13A(ParserType parser) { Parser = parser; }

		public Day13A() : this(new ParserType("day13.in")) { }

		public virtual string Solve()
		{
		    var names = new List<string>();
		    var lookup = new Dictionary<string, int>();
		    GetNamesAndLookupTable(lookup, names);
		    return GetHighScore(names, lookup).ToString();
		}

	    protected static int GetHighScore(List<string> names, Dictionary<string, int> lookup)
	    {
	        var highScore = int.MinValue;
	        foreach (var permutation in names.GetPermutations())
	        {
	            var score = 0;
	            var people = permutation.ToArray();
	            string p1, p2, key;

	            for (var i = 0; i < people.Length - 1; i++)
	            {
	                p1 = people[i];
	                p2 = people[i + 1];

	                key = $"{p1}#{p2}";
	                if (lookup.ContainsKey(key))
	                    score += lookup[key];

	                key = $"{p2}#{p1}";

	                if (lookup.ContainsKey(key))
	                    score += lookup[key];
	            }

	            p1 = people[0];
	            p2 = people[people.Length - 1];

	            key = $"{p1}#{p2}";
	            if (lookup.ContainsKey(key))
	                score += lookup[key];

	            key = $"{p2}#{p1}";

	            if (lookup.ContainsKey(key))
	                score += lookup[key];


	            if (score > highScore)
	                highScore = score;
	        }

	        return highScore;
	    }

	    protected void GetNamesAndLookupTable(Dictionary<string, int> lookup, List<string> names)
	    {
	        var lines = Parser.Parse();
	        foreach (var line in lines)
	        {
	            var parts = line.Split(' ');
	            var firstName = parts[0];
	            var secondName = parts[10].Substring(0, parts[10].Length - 1);
	            var value = int.Parse(parts[3]) * (parts[2] == "lose" ? -1 : 1);

	            if (!names.Contains(firstName))
	                names.Add(firstName);

	            if (!names.Contains(secondName))
	                names.Add(secondName);

                lookup[$"{firstName}#{secondName}"] = value;
	        }
	    }
	}
}
