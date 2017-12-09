using System;
namespace AdventOfCode2015.Solutions
{
	using ParserType = SingleLineStringParser;

	internal class Day11B : IProblem
	{
		private readonly ParserType _parser;

		public Day11B(ParserType parser)
		{
			_parser = parser;
		}

		public Day11B() : this(new ParserType("Day11\\day11.in"))
		{

		}

		public virtual string Solve()
		{
			return "";
		}
	}
}
