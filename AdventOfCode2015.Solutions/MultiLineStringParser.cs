using System.Collections.Generic;

namespace AdventOfCode2015.Solutions
{
    public class MultiLineStringParser : InputParser<IEnumerable<string>>
    {
        public MultiLineStringParser(string inputFile) : base(inputFile) { }

        public override IEnumerable<string> Parse()
        {
            return GetInput();
        }
    }
}