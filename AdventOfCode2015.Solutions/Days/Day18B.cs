using System;
using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day18B : Day18A
    {
        public override string Solve()
        {
            var rows = Parser.Parse().ToArray();
            var size = rows.Length;
            var grids = new[]
            {
                new bool[size, size],
                new bool[size, size]
            };

            var grid = grids[0];
            for (var x = 0; x < size; x++)
            for (var y = 0; y < size; y++)
                grid[x, y] = rows[x][y] == '#';

            var currentGridIndex = 0;
            var nextGridIndex = 1;

            for (var iterations = 0; iterations <= 100; iterations++)
            {
                for (var x = 0; x < size; x++)
                for (var y = 0; y < size; y++)
                {
                    if (x == 0 && y == 0 ||
                        x == 0 && y == size - 1 ||
                        x == size - 1 && y == 0 ||
                        x == size - 1 && y == size - 1)
                    {
                        grids[nextGridIndex][x, y] = true;
                        continue;
                    }

                    var minX = Math.Max(0, x - 1);
                    var maxX = Math.Min(size - 1, x + 1);

                    var minY = Math.Max(0, y - 1);
                    var maxY = Math.Min(size - 1, y + 1);

                    var onCount = 0;
                    for (var xx = minX; xx <= maxX; xx++)
                    for (var yy = minY; yy <= maxY; yy++)
                    {
                        if (xx == x && yy == y) continue;
                        if (grids[currentGridIndex][xx, yy])
                            onCount++;
                    }

                    if (grids[currentGridIndex][x, y])
                        grids[nextGridIndex][x, y] = onCount > 1 && onCount < 4;
                    else
                        grids[nextGridIndex][x, y] = onCount == 3;
                }

                var temp = currentGridIndex;
                currentGridIndex = nextGridIndex;
                nextGridIndex = temp;
            }

            var count = 0;
            for (var x = 0; x < size; x++)
            for (var y = 0; y < size; y++)
                if (grids[nextGridIndex][x, y]) count++;

            return count.ToString();
        }
    }
}
