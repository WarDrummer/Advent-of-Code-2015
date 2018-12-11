namespace AdventOfCode2015.Solutions.Day12
{
	using ParserType = SingleLineStringParser;

	internal class Day12A : IProblem
	{
		protected readonly ParserType Parser;

		public Day12A(ParserType parser) { Parser = parser; }

		public Day12A() : this(new ParserType("Day12/day12.in")) { }

		public virtual string Solve()
		{
			return "No valid password found.";
		}
	}
}
