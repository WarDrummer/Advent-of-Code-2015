using System;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day18A : IProblem
    {
        private readonly IInputParser<string> _parser;

        public Day18A() : this(new SingleLineStringParser("day18.in")) { }

        private Day18A(IInputParser<string> parser)
        {
            _parser = parser;
        }

        // 983 too low
        public string Solve()
        {
            var lightGrid = new LightGrid();
            lightGrid.Load(_parser.Parse());
            for(var i = 0; i < 100; i++)
                lightGrid.Next();

            return lightGrid.GetNumberOfOnLights().ToString();
        }
    }

    internal class LightGrid
    {
        private int _currentGridIndex;
        private readonly bool[][,] _grids =
        {
            new bool[100, 100],
            new bool[100, 100]
        };

        public void Load(string gridConfiguration)
        {
            _currentGridIndex = 0;

            var row = 0;
            var col = 0;
            foreach (var c in gridConfiguration)
            {
                _grids[_currentGridIndex][row, col] = c == '#';
                if (++row == 100)
                {
                    row = 0;
                    col++;
                }
            }
        }

        public void Next()
        {
            var nextIndex = (_currentGridIndex + 1) % 2;
            var grid = _grids[_currentGridIndex];
            var nextGrid = _grids[nextIndex];

            for (var row = 0; row < 100; row++)
            {
                for (var col = 0; col < 100; col++)
                {
                    var isOn = grid[row, col];
                    var count = 0;
                    var negCol = col > 1;
                    var posCol = col < 99;

                    if (row > 1)
                    {
                        count += grid[row - 1, col] ? 1 : 0;
                        count += negCol && grid[row - 1, col - 1] ? 1 : 0;
                        count += posCol && grid[row - 1, col + 1] ? 1 : 0;
                    }

                    if (row < 99)
                    {
                        count += grid[row + 1, col] ? 1 : 0;
                        count += negCol && grid[row + 1, col - 1] ? 1 : 0;
                        count += posCol && grid[row + 1, col + 1] ? 1 : 0;
                    }

                    count += negCol && grid[row, col - 1] ? 1 : 0;
                    count += posCol && grid[row, col + 1] ? 1 : 0;

                    var val = grid[row, col] ? "#" : ".";
                    Console.WriteLine($"{val} ({row},{col}) : {count}");
                    if (isOn)
                        nextGrid[row, col] = (count == 2 || count == 3);
                    else
                        nextGrid[row, col] = count == 3;
                }
            }

            _currentGridIndex = nextIndex;
        }

        public int GetNumberOfOnLights()
        {
            var count = 0;
            foreach (var light in _grids[_currentGridIndex])
            {
                if (light)
                    count++;
            }
            return count;
        }
    }
}
