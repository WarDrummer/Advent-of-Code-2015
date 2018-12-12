namespace AdventOfCode2015.Solutions.Days
{
	using ParserType = SingleLineStringParser;

	public class Day21A : IProblem
	{
		protected readonly ParserType Parser;

		public Day21A(ParserType parser) { Parser = parser; }

		public Day21A() : this(new ParserType("day21.in")) { }

		public virtual string Solve()
		{
			return "Unsolved";
		}
	}
}
