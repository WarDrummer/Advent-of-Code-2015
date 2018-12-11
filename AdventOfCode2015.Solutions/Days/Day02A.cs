using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day2A : IProblem
    {
        private readonly IInputParser<IEnumerable<Package>> _inputParser;

        private Day2A(IInputParser<IEnumerable<Package>> inputParser)
        {
            _inputParser = inputParser;
        }

        public Day2A() : this(new PackageInputParser()) { }

        public string Solve()
        {
            var total = 0;
            foreach (var package in _inputParser.Parse())
                total += package.GetRequiredWrappingPaperUnits();
            return total.ToString();
        }
    }

    public class Package
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int GetSurfaceArea()
        {
            return 2 * Length * Width + 2 * Width * Height + 2 * Height * Length;
        }

        public int GetExtraArea()
        {
            var dimensions = new[] { Length, Width, Height };
            Array.Sort(dimensions);
            return dimensions[0] * dimensions[1];
        }

        public int GetRequiredWrappingPaperUnits()
        {
            return GetSurfaceArea() + GetExtraArea();
        }

        public int GetRibbonLength()
        {
            var dimensions = new[] { Length, Width, Height };
            Array.Sort(dimensions);
            var shortestLength = dimensions[0] * 2 + dimensions[1] * 2;
            var bow = Length * Width * Height;
            return shortestLength + bow;
        }
    }

    internal class PackageInputParser : InputParser<IEnumerable<Package>>
    {
        public PackageInputParser() : base("day02.in") { }

        public override IEnumerable<Package> Parse()
        {
            foreach (var line in GetInput())
            {
                var dimensions = line.Split(
                        new[] { 'x' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                yield return new Package
                {
                    Length = dimensions[0],
                    Width = dimensions[1],
                    Height = dimensions[2]
                };
            }
        }
    }
}
