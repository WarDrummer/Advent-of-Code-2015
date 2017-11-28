using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day7
{
    internal abstract class Instruction
    {
        public static Instruction Create(string expression)
        {
            var parts = expression.Split(' ');

            if (parts.Length == 1)
                return new AssignmentInstruction(parts[0]);
            if (parts.Length == 2)
                return new NotInstruction(parts[1]);
            if (parts.Length == 3)
            {
                switch (parts[1])
                {
                    case "AND":
                        return new AndInstruction(parts[0], parts[2]);
                    case "OR":
                        return new OrInstruction(parts[0], parts[2]);
                    case "LSHIFT":
                        return new LeftShiftInstruction(parts[0], ushort.Parse(parts[2]));
                    case "RSHIFT":
                        return new RightShiftInstruction(parts[0], ushort.Parse(parts[2]));
                }
            }
            
            return null;
        }

        internal static ushort Evaluate(string input, IDictionary<string, Instruction> wires)
        {
            ushort constant;
            if (ushort.TryParse(input, out constant))
            {
                return constant;
            }

            return wires[input].GetValue(wires);
        }

        private ushort? _value;
        public ushort GetValue(IDictionary<string, Instruction> wires)
        {
            if (!_value.HasValue)
                _value = Resolve(wires);

            return _value.Value;
        }

        protected abstract ushort Resolve(IDictionary<string, Instruction> wires);
    }
}