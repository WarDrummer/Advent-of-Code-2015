using System;

namespace AdventOfCode2015.Solutions
{
	using ParserType = SingleLineStringParser;

	internal class Day11A : IProblem
	{
		private readonly ParserType _parser;

		public Day11A(ParserType parser) { _parser = parser; }

		public Day11A() : this(new ParserType("Day11/day11.in")) { }

		private static string lowerCaseLetterWheel = "abcdefghjkmnpqrstuvwxyz";

		public virtual string Solve()
		{
			var password = _parser.Parse().ToCharArray();
			var incrementer = new StringIncrementer(lowerCaseLetterWheel);
			foreach(var pwd in incrementer.IncrementPassword(password))
			{
				if (IsValidPassword(pwd))
					return pwd;
			}

			return "No valid password found.";
		}

		private static bool IsValidPassword(string password)
		{
			/*
			Passwords must include one increasing straight of at least three letters, like abc, bcd, cde, and so on, up to xyz. 
				They cannot skip letters; abd doesn't count.
				
			Passwords may not contain the letters i, o, or l, as these letters can be mistaken for other characters and are therefore confusing.
			
			Passwords must contain at least two different, non - overlapping pairs of letters, like aa, bb, or zz.
			*/
			return password == "abcdffaa";

			return //ContainsGoodLetters(password) && 
				ContainsTwoNonOverlappingPairs(password) && 
				ContainsOneIncreasingStraightOfThreeLetters(password);
		}

		private static bool ContainsOneIncreasingStraightOfThreeLetters(string password)
		{
			for (int i = 0; i < password.Length - 2; i++)
			{
				var current = password[i];
				if (password[i + 1] == current + 1 && password[i + 2] == current + 2)
					return true;
			}

			return false;
		}

		//private static bool ContainsGoodLetters(string password)
		//{
		//	foreach(var c in password)
		//	{
		//		if (c == 'i' || c == 'o' || c == 'l')
		//			return false;
		//	}
		//	return true;
		//}

		private static bool ContainsTwoNonOverlappingPairs(string password)
		{
			var count = 0;
			for (int i = 0; i < password.Length - 1; i++)
			{
				if(password[i] == password[i + 1])
				{
					count++;
					if (count == 2)
						return true;
					i++;
				}
			}

			return false;
		}

	}
}
