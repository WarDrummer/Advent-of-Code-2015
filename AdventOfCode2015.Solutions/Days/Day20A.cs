﻿namespace AdventOfCode2015.Solutions.Days
{
	using ParserType = SingleLineStringParser;

	public class Day20A : IProblem
	{
		protected readonly ParserType Parser;

		public Day20A(ParserType parser) { Parser = parser; }

		public Day20A() : this(new ParserType("day20.in")) { }

		public virtual string Solve()
		{
			return "Unsolved";
		}
	}
}
