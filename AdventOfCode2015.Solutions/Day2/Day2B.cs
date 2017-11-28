using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day2
{
    internal class Day2B : IProblem
    {
        private readonly IInputParser<IEnumerable<Package>> _inputParser;

        private Day2B(IInputParser<IEnumerable<Package>> inputParser)
        {
            _inputParser = inputParser;
        }

        public Day2B() : this(new PackageInputParser()) { }

        public string Solve()
        {
            var total = 0;
            foreach (var package in _inputParser.Parse())
                total += package.GetRibbonLength();
            return total.ToString();
        }
    }
}
