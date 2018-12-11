namespace AdventOfCode2015.Solutions.Days
{
	using ParserType = SingleLineStringParser;

	public class Day12A : IProblem
	{
		protected readonly ParserType Parser;

		public Day12A(ParserType parser) { Parser = parser; }

		public Day12A() : this(new ParserType("day12.in")) { }

		public virtual string Solve()
		{
			return "No valid password found.";
		}
	}
}
