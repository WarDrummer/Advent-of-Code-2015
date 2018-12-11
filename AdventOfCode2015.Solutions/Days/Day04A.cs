using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day4A : IProblem
    {
        private readonly IInputParser<string> _parser;

        public Day4A() : this(new SingleLineStringParser("day04.in")) { }

        private Day4A(IInputParser<string> parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var input = _parser.Parse().Trim();
            var number = 0;
            for (;;)
            {
                if (Md5Stringifier.GetHexCharacters($"{input}{number}").Take(5).All(c => c == '0'))
                    return number.ToString();
                number++;
            }
        }
    }
}
