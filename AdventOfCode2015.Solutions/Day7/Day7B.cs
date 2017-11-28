namespace AdventOfCode2015.Solutions.Day7
{
    internal class Day7B : IProblem
    {
        private readonly InstructionParser _parser;

        public Day7B() : this(new InstructionParser()) { }

        private Day7B(InstructionParser parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var wires = _parser.Parse();
            var bValue = wires["a"].GetValue(wires).ToString();

            //reset and override b
            wires = _parser.Parse();
            wires["b"] = new AssignmentInstruction(bValue);
            return wires["a"].GetValue(wires).ToString();
        }
    }
}