namespace AdventOfCode2015.Solutions.Day23
{
    internal class JumpInstruction : Instruction
    {
        private readonly int _offset;

        public JumpInstruction(int offset)
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
}