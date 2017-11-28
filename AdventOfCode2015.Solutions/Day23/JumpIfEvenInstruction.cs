namespace AdventOfCode2015.Solutions.Day23
{
    internal class JumpIfEvenInstruction : Instruction
    {
        private readonly char _register;
        private readonly int _offset;

        public JumpIfEvenInstruction(char register, int offset)
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
}