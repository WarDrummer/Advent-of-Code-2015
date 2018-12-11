using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day8B : IProblem
    {
        private readonly MultiLineStringParser _parser;

        public Day8B(MultiLineStringParser parser)
        {
            _parser = parser;
        }

        public Day8B() : this(new MultiLineStringParser("day08.in")) { }

        public string Solve()
        {
            var literal = 0;
            var encoded = 0;
            foreach (var line in _parser.Parse().Select(s => s.Trim()))
            {
                literal += line.Length;
                encoded += 2; // new quotes
                foreach (char c in line)
                {
                    if (c == '\\')
                    {
                        encoded += 1;
                    }
                    else if (c == '"')
                    {
                        encoded += 1;
                    }

                    encoded += 1;
                }
            }
            return (encoded - literal).ToString();
        }
    }
}
