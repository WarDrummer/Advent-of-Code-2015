using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day23B : IProblem
    {
        private readonly MultiLineStringParser _parser;

        public Day23B() : this(new MultiLineStringParser("day23.in")) { }

        private Day23B(MultiLineStringParser parser)
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
            computer.SetRegister('a', 1);
            computer.ExecuteProgram(instructions.ToArray());
            return computer.GetRegister('b').ToString();
        }
    }
}
