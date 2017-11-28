namespace AdventOfCode2015.Solutions.Day23
{
    internal class TripleInstruction : Instruction
    {
        private readonly char _register;

        public TripleInstruction(char register)
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