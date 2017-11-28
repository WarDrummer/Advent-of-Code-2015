namespace AdventOfCode2015.Solutions.Day1
{
    internal class Day1B : IProblem
    {
        private readonly IInputParser<string> _parser;

        public Day1B() : this(new SingleLineStringParser("Day1\\day1.in")) { }

        private Day1B(IInputParser<string> parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var input = _parser.Parse().Trim();
            var floor = 0;
            for (var index = 0; index < input.Length; index++)
            {
                var move = input[index];
                floor += move == '(' ? 1 : -1;
                if (floor < 0)
                    return (index + 1).ToString();
            }
            return floor.ToString();
        }
    }
}
