using System.Linq;

namespace AdventOfCode2015.Solutions.Day5
{
    internal class Day5A : IProblem
    {
        private readonly MultiLineStringParser _parser;

        public Day5A() : this(new MultiLineStringParser("Day5\\day5.in")) { }

        private Day5A(MultiLineStringParser parser)
        {
            _parser = parser;
        }

        private static readonly char[] Vowels = {'a', 'e', 'i', 'o', 'u'};

        public string Solve()
        {
            var count = 0;
            foreach (var input in _parser.Parse())
            {
                var vowelCount = 0;
                var hasTwoInARow = false;
                var hasForbidden = false;

                for (var i = 0; i < input.Length - 1; i++)
                {
                    var c1 = input[i];
                    var c2 = input[i + 1];

                    vowelCount += Vowels.Contains(c1) ? 1 : 0;

                    if (c1 == c2)
                    {
                        hasTwoInARow = true;
                        continue;
                    }

                    if (c1 == 'a' && c2 == 'b' ||
                        c1 == 'c' && c2 == 'd' ||
                        c1 == 'p' && c2 == 'q' ||
                        c1 == 'x' && c2 == 'y')
                    {
                        hasForbidden = true;
                        break;
                    }
                }

                if (!hasForbidden && hasTwoInARow)
                {
                    vowelCount += Vowels.Contains(input[input.Length - 1]) ? 1 : 0;
                    if (vowelCount > 2)
                        count++;
                }
            }

            return count.ToString();
        }
    }
}
