using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day3
{
    internal class Day3A : IProblem
    {
        private readonly IInputParser<string> _parser;

        public Day3A() : this(new SingleLineStringParser("Day3\\day3.in")) { }

        private Day3A(IInputParser<string> parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var visited = new HashSet<string>();
            var input = _parser.Parse().Trim();
            var x = 0;
            var y = 0;
            var housesVisited = 1;
            foreach (var c in input)
            {
                switch (c)
                {
                    case 'v':
                        y--;
                        break;
                    case '^':
                        y++;
                        break;
                    case '<':
                        x--;
                        break;
                    case '>':
                        x++;
                        break;
                }

                var position = $"{x},{y}";
                if (!visited.Contains(position))
                {
                    visited.Add(position);
                    housesVisited++;
                }
            }
            return housesVisited.ToString();
        }
    }
}
