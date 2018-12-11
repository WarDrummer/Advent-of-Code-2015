using System;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day6B : IProblem
    {
        private readonly LightUpdateParser _parser;

        public Day6B() : this(new LightUpdateParser()) { }

        private Day6B(LightUpdateParser parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var lightBoard = new int[1000, 1000];
            foreach(var input in _parser.Parse())
            {
                for (var row = input.RowStart; row <= input.RowEnd; row++)
                {
                    for (var col = input.ColumnStart; col <= input.ColumnEnd; col++)
                    {
                        if (input.UpdateType == UpdateType.On)
                            lightBoard[row, col] += 1;
                        else if (input.UpdateType == UpdateType.Off)
                            lightBoard[row, col] = Math.Max(0, lightBoard[row, col] - 1);
                        else if (input.UpdateType == UpdateType.Toggle)
                            lightBoard[row, col] += 2;
                    }
                }
            }

            var count = 0;
            for (var row = 0; row < 1000; row++)
            for (var col = 0; col < 1000; col++)
                count += lightBoard[row, col];

            return count.ToString();
        }
    }
}
