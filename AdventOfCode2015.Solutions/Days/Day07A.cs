using System;
using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day7A : IProblem
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

    internal class AndInstruction : Instruction
    {
        private readonly string _input1;
        private readonly string _input2;

        public AndInstruction(string input1, string input2)
        {
            _input1 = input1;
            _input2 = input2;
        }

        protected override ushort Resolve(IDictionary<string, Instruction> wires)
        {
            return (ushort)(Evaluate(_input1, wires) & Evaluate(_input2, wires));
        }
    }

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

    internal class InstructionParser : InputParser<IDictionary<string, Instruction>>
    {
        public InstructionParser() : base("day07.in") { }

        public override IDictionary<string, Instruction> Parse()
        {
            var wires = new Dictionary<string, Instruction>();
            foreach (var line in GetInput())
            {
                var expression = line.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                wires.Add(expression[1].Trim(), Instruction.Create(expression[0].Trim()));
            }
            return wires;
        }
    }
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

    internal class RightShiftInstruction : Instruction
    {
        private readonly string _wireId;
        private readonly int _shift;

        public RightShiftInstruction(string wireId, int shift)
        {
            _wireId = wireId;
            _shift = shift;
        }

        protected override ushort Resolve(IDictionary<string, Instruction> wires)
        {
            return (ushort)(wires[_wireId].GetValue(wires) >> _shift);
        }
    }
}
