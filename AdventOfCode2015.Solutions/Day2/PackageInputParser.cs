using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Solutions.Day2
{
    internal class PackageInputParser : InputParser<IEnumerable<Package>>
    {
        public PackageInputParser() : base("Day2\\day2.in")
        {
        }

        public override IEnumerable<Package> Parse()
        {
            foreach(var line in GetInput())
            {
                var dimensions = line.Split(
                        new [] { 'x' }, StringSplitOptions.RemoveEmptyEntries)
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