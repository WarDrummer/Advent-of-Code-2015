namespace AdventOfCode2015.Solutions.Day23
{
    internal abstract class Instruction
    {
        public static Instruction Create(string assembly)
        {
            var parts = assembly.Split(' ');
            switch (parts[0])
            {
                case "hlf":
                    return new HalfInstruction(parts[1][0]);
                case "tpl":
                    return new TripleInstruction(parts[1][0]);
                case "inc":
                    return new IncrementInstruction(parts[1][0]);
                case "jmp":
                {
                    var value = int.Parse(parts[1].Substring(1));
                    return new JumpInstruction(parts[1][0] == '+' ? value : -value);
                }
                case "jie":
                {
                    var register = parts[1].Substring(0, parts[1].Length - 1)[0];
                    var value = int.Parse(parts[2].Substring(1));
                    return new JumpIfEvenInstruction(register, parts[2][0] == '+' ? value : -value);
                }
                case "jio":
                {
                    var register = parts[1].Substring(0, parts[1].Length - 1)[0];
                    var value = int.Parse(parts[2].Substring(1));
                    return new JumpIfOneInstruction(register, parts[2][0] == '+' ? value : -value);
                }
            }
            return null;
        }

        public abstract void Execute(Computer computer);
    }
}