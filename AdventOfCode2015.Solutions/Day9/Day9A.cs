using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Solutions.Day9
{
    internal class Day9A : IProblem
    {
        protected readonly RouteCostParser Parser;

        public Day9A(RouteCostParser parser)
        {
            Parser = parser;
        }

        public Day9A() : this(new RouteCostParser()) { }

        public virtual string Solve()
        {
            var routes = Parser.Parse().ToArray();
            var locations = GetLocations(routes);

            var adjacencyMatrix = BuildAdjacencyMatrix(routes, locations);

            var locationToIndex = new Dictionary<string, int>();
            for(var i = 0; i < locations.Count; i++)
                locationToIndex.Add(locations[i], i);

            var shortestPathCost = int.MaxValue;
            foreach (var possibleRoute in locations.GetPermutations())
            {
                var currentPathCost = 0;
                for (var l = 0; l < possibleRoute.Count - 1; l++)
                {
                    var fromIndex = locationToIndex[possibleRoute[l]];
                    var toIndex = locationToIndex[possibleRoute[l + 1]];

                    var cost = adjacencyMatrix[fromIndex, toIndex];

                    currentPathCost += cost;
                    if (cost == -1 || shortestPathCost < currentPathCost)
                    {
                        currentPathCost = int.MaxValue;
                        break;
                    }
                }

                if (currentPathCost < shortestPathCost)
                {
                    shortestPathCost = currentPathCost;
                }
            }
            
            return shortestPathCost.ToString();
        }

        protected static int[,] BuildAdjacencyMatrix(
            IEnumerable<Route> routes, IList<string> locations)
        {
            var numLocations = locations.Count;
            var adjacencyMatrix = new int[numLocations, numLocations];

            for (var x = 0; x < numLocations; x++)
            for (var y = 0; y < numLocations; y++)
                adjacencyMatrix[x, y] = -1;

            foreach (var route in routes)
            {
                var toIndex = locations.IndexOf(route.To);
                var fromIndex = locations.IndexOf(route.From);
                adjacencyMatrix[fromIndex, toIndex] = route.Cost;
                adjacencyMatrix[toIndex, fromIndex] = route.Cost;
            }
            return adjacencyMatrix;
        }

        protected static IList<string> GetLocations(IEnumerable<Route> routes)
        {
            var locations = new List<string>();
            foreach (var route in routes)
            {
                locations.Add(route.From);
                locations.Add(route.To);
            }
            return locations.Distinct().ToList();
        }
    }
}
