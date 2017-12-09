namespace AdventOfCode2015.Solutions.Day11
{
	using ParserType = SingleLineStringParser;

	internal class Day11B : Day11A
    {
		public override string Solve()
		{
		    var password = Parser.Parse().ToCharArray();
		    var incrementer = new StringIncrementer(LowerCaseLetterWheel);
		    var count = 0;
		    foreach (var pwd in incrementer.IncrementPassword(password))
		    {
		        if (IsValidPassword(pwd) && ++count == 2)
		            return new string(pwd);
		    }

		    return "No valid password found.";
        }
	}
}
