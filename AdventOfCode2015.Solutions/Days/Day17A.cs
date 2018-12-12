using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
	using ParserType = MultiLineStringParser;

	public class Day17A : IProblem
	{
		protected readonly ParserType Parser;

		public Day17A(ParserType parser) { Parser = parser; }

		public Day17A() : this(new ParserType("day17.in")) { }

		public virtual string Solve()
		{
		    var containerSizes = Parser.Parse().Select(int.Parse).ToList();
			return CountWays(containerSizes).ToString();
		}

	    public int CountWays(List<int> containerSizes)
	    {
	        if (containerSizes.Count < 1)
	            return 0;

	        var count = 0;
	        for (var i = 0; i < containerSizes.Count; i++)
	        {
	            var newList = new List<int>(containerSizes.Capacity - 1);
	            newList.AddRange(containerSizes.Where((t, j) => i != j));

	            if (newList.Sum() == 25) count++;
	            count += CountWays(newList);
	        }

	        return count;
	    }
	}
}
