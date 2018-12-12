namespace AdventOfCode2015.Solutions.Days
{
	using ParserType = SingleLineStringParser;

	public class Day15A : IProblem
	{
		protected readonly ParserType Parser;

		public Day15A(ParserType parser) { Parser = parser; }

		public Day15A() : this(new ParserType("day15.in")) { }

		public virtual string Solve()
		{
			return "Unsolved";
		}
	}
}
