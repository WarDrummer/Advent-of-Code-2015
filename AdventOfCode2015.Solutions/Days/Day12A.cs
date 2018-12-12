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
		    var doc = Parser.Parse();
		    var inString = false;
		    var total = 0;
		    for (var i = 0; i < doc.Length; i++)
		    {
		        var c = doc[i];
		        if (c == '"')
		            inString = !inString;

		        if (inString)
		            continue;

		        var isNegative = false;
		        if (c == '-')
		        {
		            isNegative = true;
                    i++;
		        }

		        var num = 0;
                while (char.IsDigit(doc[i]))
		            num = num * 10 + doc[i++] - '0';
		        total += isNegative ? -1 * num : num;
		    }

            return total.ToString();
		}
	}
}
