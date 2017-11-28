namespace AdventOfCode2015.Solutions.Day5
{
    internal class Day5B : IProblem
    {
        private readonly MultiLineStringParser _parser;

        public Day5B() : this(new MultiLineStringParser("Day5\\day5.in")) { }

        private Day5B(MultiLineStringParser parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var count = 0;
            foreach (var input in _parser.Parse())
            {
                if (HasMatchingPair(input) && HasTriplePattern(input))
                    count++;
            }

            return count.ToString();
        }

        private static bool HasTriplePattern(string input)
        {
            for (var i = 0; i < input.Length - 2; i++)
                if (input[i] == input[i + 2])
                    return true;

            return false;
        }

        private static bool HasMatchingPair(string input)
        {
            for (var i = 0; i < input.Length - 1; i++)
            {
                var pair = $"{input[i]}{input[i + 1]}";
                if (input.Substring(i + 2).Contains(pair))
                    return true;
            }

            return false;
        }
    }
}
