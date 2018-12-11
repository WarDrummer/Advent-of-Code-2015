using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day9B : Day9A
    {
        public override string Solve()
        {
            var routes = Parser.Parse().ToArray();
            var locations = GetLocations(routes);

            var adjacencyMatrix = BuildAdjacencyMatrix(routes, locations);

            var locationToIndex = new Dictionary<string, int>();
            for (var i = 0; i < locations.Count; i++)
                locationToIndex.Add(locations[i], i);

            var longestPathCost = int.MinValue;
            foreach (var possibleRoute in locations.GetPermutations())
            {
                var currentPathCost = 0;
                for (var l = 0; l < possibleRoute.Count - 1; l++)
                {
                    var fromIndex = locationToIndex[possibleRoute[l]];
                    var toIndex = locationToIndex[possibleRoute[l + 1]];

                    var cost = adjacencyMatrix[fromIndex, toIndex];

                    currentPathCost += cost;
                    if (cost == -1)
                    {
                        currentPathCost = int.MinValue;
                        break;
                    }
                }

                if (currentPathCost > longestPathCost)
                {
                    longestPathCost = currentPathCost;
                }
            }

            return longestPathCost.ToString();
        }
    }
}