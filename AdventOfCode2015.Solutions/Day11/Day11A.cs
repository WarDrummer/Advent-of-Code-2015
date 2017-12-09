using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day11
{
	using ParserType = SingleLineStringParser;

	internal class Day11A : IProblem
	{
		protected readonly ParserType Parser;

		public Day11A(ParserType parser) { Parser = parser; }

		public Day11A() : this(new ParserType("Day11/day11.in")) { }

		protected static string LowerCaseLetterWheel = "abcdefghjkmnpqrstuvwxyz";

		public virtual string Solve()
		{
			var password = Parser.Parse().ToCharArray();
			var incrementer = new StringIncrementer(LowerCaseLetterWheel);
			foreach(var pwd in incrementer.IncrementPassword(password))
			{
                if (IsValidPassword(pwd)) 
                    return new string(pwd);
            }

			return "No valid password found.";
		}

		protected static bool IsValidPassword(IReadOnlyList<char> password)
		{
		    var containsIncreasingStraight = false;
            for (var i = 0; i < password.Count - 2; i++)
		    {
		        var current = password[i];
		        if (password[i + 1] == current + 1 && password[i + 2] == current + 2)
		        {
		            containsIncreasingStraight = true;
		            break;
		        }
		    }

		    if (!containsIncreasingStraight)
                return false;

		    var counted = new HashSet<char>();
		    var containsTwoNonOverlappingPairs = false;
            var count = 0;
		    for (var i = 0; i < password.Count - 1; i++)
		    {
		        var current = password[i];
                if (!counted.Contains(current) && current == password[i + 1])
                {
                    counted.Add(current);
                    count++;
		            if (count == 2)
		            {
		                containsTwoNonOverlappingPairs = true;
		                break;
		            }
		            i++;
		        }
		    }

            return containsTwoNonOverlappingPairs;
		}
	}
}
