using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day8A : IProblem
    {
        private readonly MultiLineStringParser _parser;

        public Day8A(MultiLineStringParser parser)
        {
            _parser = parser;
        }

        public Day8A() : this(new MultiLineStringParser("day08.in")) { }

        public string Solve()
        {
            var literal = 0;
            var memory = 0;
            foreach (var line in _parser.Parse().Select(s => s.Trim()))
            {
                literal += line.Length;

                for (var i = 1; i < line.Length - 1; i++)
                {
                    if (line[i] == '\\')
                    {
                        if (line[i + 1] == '\\' || line[i + 1] == '"')
                        {
                            i += 1;
                        }
                        else if (line[i + 1] == 'x')
                        {
                            i += 3;
                        }
                        else
                        {
                            Debug.Assert(false, "Unescaped slash wasn't expected");
                        }
                    }

                    memory += 1;
                }
            }
            return (literal - memory).ToString();
        }
    }
}
