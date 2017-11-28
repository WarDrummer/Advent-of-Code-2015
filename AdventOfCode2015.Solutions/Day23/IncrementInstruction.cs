namespace AdventOfCode2015.Solutions.Day23
{
    internal class IncrementInstruction : Instruction
    {
        private readonly char _register;

        public IncrementInstruction(char register)
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
}