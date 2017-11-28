using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day3
{
    internal class Day3B : IProblem
    {
        private readonly IInputParser<string> _parser;

        public Day3B() : this(new SingleLineStringParser("Day3\\day3.in")) { }

        private Day3B(IInputParser<string> parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var visited = new HashSet<string>(new [] {"0,0"});
            var input = _parser.Parse().Trim();
            var x = new [] { 0, 0 };
            var y = new [] { 0, 0 };
            var housesVisited = 1;
            var isSanta = true;
            foreach (var c in input)
            {
                var coordinateIndex = isSanta ? 0 : 1;
                switch (c)
                {
                    case 'v':
                        y[coordinateIndex]--;
                        break;
                    case '^':
                        y[coordinateIndex]++;
                        break;
                    case '<':
                        x[coordinateIndex]--;
                        break;
                    case '>':
                        x[coordinateIndex]++;
                        break;
                }
                var position = $"{x[coordinateIndex]},{y[coordinateIndex]}";
                if (!visited.Contains(position))
                {
                    visited.Add(position);
                    housesVisited++;
                }
                isSanta = !isSanta;
            }
            return housesVisited.ToString();
        }
    }
}