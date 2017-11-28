using System;
using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day23
{
    internal class Computer
    {
        private IDictionary<char, int> _registers = new Dictionary<char, int>();
        public int InstructionPointer { get; set; }

        public Computer()
        {
            Reset();
        }

        public void ExecuteProgram(Instruction[] instructions)
        {
            while (InstructionPointer < instructions.Length && InstructionPointer >= 0)
            {
                instructions[InstructionPointer].Execute(this);
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
}