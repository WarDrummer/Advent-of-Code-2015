using System;
using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day23A : IProblem
    {
        private readonly MultiLineStringParser _parser;

        public Day23A() : this(new MultiLineStringParser("day23.in")) { }

        private Day23A(MultiLineStringParser parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var instructions = new List<Instruction2>();
            foreach(var line in _parser.Parse())
            {
                instructions.Add(Instruction2.Create(line));
            }
            
            var computer = new Computer();
            computer.ExecuteProgram(instructions.ToArray());
            return computer.GetRegister('b').ToString();
        }
    }

    internal class Computer
    {
        private IDictionary<char, int> _registers = new Dictionary<char, int>();
        public int InstructionPointer { get; set; }

        public Computer()
        {
            Reset();
        }

        public void ExecuteProgram(Instruction2[] instruction2s)
        {
            while (InstructionPointer < instruction2s.Length && InstructionPointer >= 0)
            {
                instruction2s[InstructionPointer].Execute(this);
            }
        }

        public void Reset()
        {
            _registers = new Dictionary<char, int>();
            InstructionPointer = 0;
        }

        public void SetRegister(char register, int value)
        {
            _registers[register] = Math.Max(0, value);
        }

        public int GetRegister(char register)
        {
            return _registers.Keys.Contains(register) ? _registers[register] : 0;
        }
    }

    internal class HalfInstruction2 : Instruction2
    {
        private readonly char _register;

        public HalfInstruction2(char register)
        {
            _register = register;
        }

        public override void Execute(Computer computer)
        {
            var value = computer.GetRegister(_register);
            computer.SetRegister(_register, value / 2);
            computer.InstructionPointer++;
        }

        public override string ToString()
        {
            return $"hlf {_register}";
        }
    }

    internal class IncrementInstruction2 : Instruction2
    {
        private readonly char _register;

        public IncrementInstruction2(char register)
        {
            _register = register;
        }

        public override void Execute(Computer computer)
        {
            var value = computer.GetRegister(_register);
            computer.SetRegister(_register, value + 1);
            computer.InstructionPointer++;
        }

        public override string ToString()
        {
            return $"inc {_register}";
        }
    }

    internal abstract class Instruction2
    {
        public static Instruction2 Create(string assembly)
        {
            var parts = assembly.Split(' ');
            switch (parts[0])
            {
                case "hlf":
                    return new HalfInstruction2(parts[1][0]);
                case "tpl":
                    return new TripleInstruction2(parts[1][0]);
                case "inc":
                    return new IncrementInstruction2(parts[1][0]);
                case "jmp":
                {
                    var value = int.Parse(parts[1].Substring(1));
                    return new JumpInstruction2(parts[1][0] == '+' ? value : -value);
                }
                case "jie":
                {
                    var register = parts[1].Substring(0, parts[1].Length - 1)[0];
                    var value = int.Parse(parts[2].Substring(1));
                    return new JumpIfEvenInstruction2(register, parts[2][0] == '+' ? value : -value);
                }
                case "jio":
                {
                    var register = parts[1].Substring(0, parts[1].Length - 1)[0];
                    var value = int.Parse(parts[2].Substring(1));
                    return new JumpIfOneInstruction2(register, parts[2][0] == '+' ? value : -value);
                }
            }
            return null;
        }

        public abstract void Execute(Computer computer);
    }

    internal class JumpIfEvenInstruction2 : Instruction2
    {
        private readonly char _register;
        private readonly int _offset;

        public JumpIfEvenInstruction2(char register, int offset)
        {
            _register = register;
            _offset = offset;
        }

        public override void Execute(Computer computer)
        {
            var value = computer.GetRegister(_register);
            if (value % 2 == 0)
                computer.InstructionPointer += _offset;
            else
                computer.InstructionPointer++;
        }

        public override string ToString()
        {
            return $"jie {_register}, {_offset}";
        }
    }

    internal class JumpIfOneInstruction2 : Instruction2
    {
        private readonly char _register;
        private readonly int _offset;

        public JumpIfOneInstruction2(char register, int offset)
        {
            _register = register;
            _offset = offset;
        }

        public override void Execute(Computer computer)
        {
            var value = computer.GetRegister(_register);
            if (value == 1)
                computer.InstructionPointer += _offset;
            else
                computer.InstructionPointer++;
        }

        public override string ToString()
        {
            return $"jio {_register}, {_offset}";
        }
    }

    internal class JumpInstruction2 : Instruction2
    {
        private readonly int _offset;

        public JumpInstruction2(int offset)
        {
            _offset = offset;
        }

        public override void Execute(Computer computer)
        {
            computer.InstructionPointer += _offset;
        }
        public override string ToString()
        {
            return $"jmp {_offset}";
        }
    }

    internal class TripleInstruction2 : Instruction2
    {
        private readonly char _register;

        public TripleInstruction2(char register)
        {
            _register = register;
        }

        public override void Execute(Computer computer)
        {
            var value = computer.GetRegister(_register);
            computer.SetRegister(_register, value * 3);
            computer.InstructionPointer++;
        }

        public override string ToString()
        {
            return $"tpl {_register}";
        }
    }
}
