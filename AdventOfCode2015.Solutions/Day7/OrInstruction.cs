using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day7
{
    internal class OrInstruction : Instruction
    {
        private readonly string _input1;
        private readonly string _input2;

        public OrInstruction(string input1, string input2)
        {
            _input1 = input1;
            _input2 = input2;
        }

        protected override ushort Resolve(IDictionary<string, Instruction> wires)
        {
            return (ushort)(Evaluate(_input1, wires) | Evaluate(_input2, wires));
        }
    }
}