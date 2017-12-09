using System.Reflection;
using AdventOfCode2015.Solutions.Day1;
using AdventOfCode2015.Solutions.Day10;
using AdventOfCode2015.Solutions.Day11;
using AdventOfCode2015.Solutions.Day16;
using AdventOfCode2015.Solutions.Day18;
using AdventOfCode2015.Solutions.Day2;
using AdventOfCode2015.Solutions.Day23;
using AdventOfCode2015.Solutions.Day24;
using AdventOfCode2015.Solutions.Day3;
using AdventOfCode2015.Solutions.Day4;
using AdventOfCode2015.Solutions.Day5;
using AdventOfCode2015.Solutions.Day6;
using AdventOfCode2015.Solutions.Day7;
using AdventOfCode2015.Solutions.Day8;
using AdventOfCode2015.Solutions.Day9;

namespace AdventOfCode2015.Solutions
{
    public class ProblemId
    {
        public static readonly string Day1A = typeof(Day1A).FullName;
        public static readonly string Day1B = typeof(Day1B).FullName;
        public static readonly string Day2A = typeof(Day2A).FullName;
        public static readonly string Day2B = typeof(Day2B).FullName;
        public static readonly string Day3A = typeof(Day3A).FullName;
        public static readonly string Day3B = typeof(Day3B).FullName;
        public static readonly string Day4A = typeof(Day4A).FullName;
        public static readonly string Day4B = typeof(Day4B).FullName;
        public static readonly string Day5A = typeof(Day5A).FullName;
        public static readonly string Day5B = typeof(Day5B).FullName;
        public static readonly string Day6A = typeof(Day6A).FullName;
        public static readonly string Day6B = typeof(Day6B).FullName;
        public static readonly string Day7A = typeof(Day7A).FullName;
        public static readonly string Day7B = typeof(Day7B).FullName;
        public static readonly string Day8A = typeof(Day8A).FullName;
        public static readonly string Day8B = typeof(Day8B).FullName;
        public static readonly string Day9A = typeof(Day9A).FullName;
        public static readonly string Day9B = typeof(Day9B).FullName;
        public static readonly string Day10A = typeof(Day10A).FullName;
        public static readonly string Day10B = typeof(Day10B).FullName;
        public static readonly string Day11A = typeof(Day11A).FullName;
        public static readonly string Day11B = typeof(Day11B).FullName;
        //public static readonly string Day12A = typeof(Day12A).FullName;
        //public static readonly string Day12B = typeof(Day12B).FullName;
        //public static readonly string Day13A = typeof(Day13A).FullName;
        //public static readonly string Day13B = typeof(Day13B).FullName;
        //public static readonly string Day14A = typeof(Day14A).FullName;
        //public static readonly string Day14B = typeof(Day14B).FullName;
        //public static readonly string Day15A = typeof(Day15A).FullName;
        //public static readonly string Day15B = typeof(Day15B).FullName;
        public static readonly string Day16A = typeof(Day16A).FullName;
        public static readonly string Day16B = typeof(Day16B).FullName;
        //public static readonly string Day17A = typeof(Day17A).FullName;
        //public static readonly string Day17B = typeof(Day17B).FullName;
        public static readonly string Day18A = typeof(Day18A).FullName;
        //public static readonly string Day18B = typeof(Day18B).FullName;
        //public static readonly string Day19A = typeof(Day19A).FullName;
        //public static readonly string Day19B = typeof(Day19B).FullName;
        //public static readonly string Day20A = typeof(Day20A).FullName;
        //public static readonly string Day20B = typeof(Day20B).FullName;
        //public static readonly string Day21A = typeof(Day21A).FullName;
        //public static readonly string Day21B = typeof(Day21B).FullName;
        //public static readonly string Day22A = typeof(Day22A).FullName;
        //public static readonly string Day22B = typeof(Day22B).FullName;
        public static readonly string Day23A = typeof(Day23A).FullName;
        public static readonly string Day23B = typeof(Day23B).FullName;
        public static readonly string Day24A = typeof(Day24A).FullName;
        //public static readonly string Day24B = typeof(Day24B).FullName;
        //public static readonly string Day25A = typeof(Day25A).FullName;
        //public static readonly string Day25B = typeof(Day25B).FullName;
    }

    public static class ProblemFactory
    {
        public static IProblem Create(string problemId)
        {
            return (IProblem)Assembly.GetExecutingAssembly()
                .CreateInstance(problemId);
        }
    }
}
