using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day7
{
    internal class LeftShiftInstruction : Instruction
    {
        private readonly string _wireId;
        private readonly int _shift;

        public LeftShiftInstruction(string wireId, int shift)
        {
            _wireId = wireId;
            _shift = shift;
        }

        protected override ushort Resolve(IDictionary<string, Instruction> wires)
        {
            return (ushort)(wires[_wireId].GetValue(wires) << _shift);
        }
    }
}