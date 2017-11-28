using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day7
{
    internal class AssignmentInstruction : Instruction
    {
        private readonly string _input;

        public AssignmentInstruction(string input)
        {
            _input = input;
        }

        protected override ushort Resolve(IDictionary<string, Instruction> wires)
        {
            return Evaluate(_input, wires);
        }
    }
}