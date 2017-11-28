using System.Linq;

namespace AdventOfCode2015.Solutions.Day16
{
    internal class Day16A : IProblem
    {
        private readonly MultiLineStringParser _parser;
        protected TickerTape TickerTape = new TickerTape();

        public Day16A() : this(new MultiLineStringParser("Day16\\day16.in")) { }

        private Day16A(MultiLineStringParser parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var bestMatchId = -1;
            var currentAuntId = 1;
            var bestMatchCount = -1;
            
            foreach(var aunt in _parser.Parse())
            {
                // Sue 13: akitas: 10, pomeranians: 0, vizslas: 2
                var matchValues = aunt
                    .Substring(aunt.IndexOf(':') + 1)
                    .Split(',')
                    .Select(s => s.Trim());

                var matchCount = 0;
                foreach (var matchValue in matchValues)
                {
                    var reading = matchValue.Split(':').Select(s => s.Trim()).ToArray();
                    var compoundName = reading[0];
                    var compoundCount = int.Parse(reading[1]);
                    var isMatch = IsMatch(compoundName, compoundCount);

                    if (!isMatch)
                    {
                        matchCount = -1;
                        break;
                    }

                    matchCount++;
                }

                if (matchCount > bestMatchCount)
                {
                    bestMatchId = currentAuntId;
                }
                currentAuntId++;
            }

            return bestMatchId.ToString();
        }

        protected virtual bool IsMatch(string compoundName, int compoundCount)
        {
            return TickerTape.GetMatchCount(compoundName) == compoundCount;
        }
    }
}
