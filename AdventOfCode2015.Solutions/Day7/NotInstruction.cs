using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day7
{
    internal class NotInstruction : Instruction
    {
        private readonly string _wireId;

        public NotInstruction(string wireId)
        {
            _wireId = wireId;
        }

        protected override ushort Resolve(IDictionary<string, Instruction> wires)
        {
            return (ushort)(~wires[_wireId].GetValue(wires));
        }
    }
}