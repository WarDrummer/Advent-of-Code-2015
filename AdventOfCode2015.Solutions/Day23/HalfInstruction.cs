namespace AdventOfCode2015.Solutions.Day23
{
    internal class HalfInstruction : Instruction
    {
        private readonly char _register;

        public HalfInstruction(char register)
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
}