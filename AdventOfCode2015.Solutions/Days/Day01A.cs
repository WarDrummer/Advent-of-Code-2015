using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day1A : IProblem
    {
        private readonly IInputParser<string> _parser;

        public Day1A() : this(new SingleLineStringParser("day01.in")) { }

        private Day1A(IInputParser<string> parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var input = _parser.Parse().Trim();
            var floor = input.Sum(move => move == '(' ? 1 : -1);
            return floor.ToString();
        }
    }
}
