using System;
using System.Collections.Generic;

namespace AdventOfCode2015.Solutions.Day9
{
    internal class RouteCostParser : InputParser<IEnumerable<Route>>
    {
        public RouteCostParser() : base("Day9\\day9.in") { }

        public override IEnumerable<Route> Parse()
        {
            foreach (var line in GetInput())
            {
                var parts = line.Split(
                    new[] {" to "}, StringSplitOptions.RemoveEmptyEntries);
                var moreParts = parts[1].Split(
                    new[] { " = " }, StringSplitOptions.RemoveEmptyEntries);

                var from = parts[0];
                var to = moreParts[0];
                var cost = int.Parse(moreParts[1]);

                yield return new Route
                {
                    From = from, 
                    To = to,
                    Cost = cost
                };
            }
        }
    }
}