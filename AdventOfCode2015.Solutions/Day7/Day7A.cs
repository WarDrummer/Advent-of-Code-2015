namespace AdventOfCode2015.Solutions.Day7
{
    internal class Day7A : IProblem
    {
        private readonly InstructionParser _parser;

        public Day7A() : this(new InstructionParser()) { }

        private Day7A(InstructionParser parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var wires = _parser.Parse();
            return wires["a"].GetValue(wires).ToString();
        }
    }
}
