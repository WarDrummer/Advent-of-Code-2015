using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day2
{
    internal class Day2A : IProblem
    {
        private readonly IInputParser<IEnumerable<Package>> _inputParser;

        private Day2A(IInputParser<IEnumerable<Package>> inputParser)
        {
            _inputParser = inputParser;
        }

        public Day2A() : this(new PackageInputParser()) { }

        public string Solve()
        {
            var total = 0;
            foreach (var package in _inputParser.Parse())
                total += package.GetRequiredWrappingPaperUnits();
            return total.ToString();
        }
    }
}
