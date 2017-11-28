using System;
using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day7
{
    internal class InstructionParser : InputParser<IDictionary<string, Instruction>>
    {
        public InstructionParser() : base("Day7\\day7.in") { }

        public override IDictionary<string, Instruction> Parse()
        {
            var wires = new Dictionary<string, Instruction>();
            foreach (var line in GetInput())
            {
                var expression = line.Split(new [] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                wires.Add(expression[1].Trim(), Instruction.Create(expression[0].Trim()));
            }
            return wires;
        }
    }
}
