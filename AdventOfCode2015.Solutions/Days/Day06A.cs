using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day6A : IProblem
    {
        private readonly LightUpdateParser _parser;

        public Day6A() : this(new LightUpdateParser()) { }

        private Day6A(LightUpdateParser parser)
        {
            _parser = parser;
        }

        public string Solve()
        {
            var lightBoard = new bool[1000, 1000];
            foreach(var input in _parser.Parse())
            {
                for (var row = input.RowStart; row <= input.RowEnd; row++)
                {
                    for (var col = input.ColumnStart; col <= input.ColumnEnd; col++)
                    {
                        if (input.UpdateType == UpdateType.On)
                            lightBoard[row, col] = true;
                        else if (input.UpdateType == UpdateType.Off)
                            lightBoard[row, col] = false;
                        else if (input.UpdateType == UpdateType.Toggle)
                            lightBoard[row, col] = !lightBoard[row, col];
                    }
                }
            }

            var count = 0;
            for (var row = 0; row < 1000; row++)
            for (var col = 0; col < 1000; col++)
                if (lightBoard[row, col])
                    count++;

            return count.ToString();
        }
    }

    internal class LightUpdate
    {
        public int RowStart { get; set; }
        public int RowEnd { get; set; }
        public int ColumnStart { get; set; }
        public int ColumnEnd { get; set; }
        public UpdateType UpdateType { get; set; }
    }

    internal class LightUpdateParser : InputParser<IEnumerable<LightUpdate>>
    {
        public LightUpdateParser() : base("day06.in") { }

        public override IEnumerable<LightUpdate> Parse()
        {
            var startCoordinateIndex = new Dictionary<UpdateType, int>
            {
                {UpdateType.On, 8},
                {UpdateType.Off, 9},
                {UpdateType.Toggle, 7}
            };

            foreach (var line in GetInput())
            {
                var parts = line.Split(
                    new[] { " through " }, StringSplitOptions.RemoveEmptyEntries);

                UpdateType updateType;
                if (parts[0].StartsWith("turn on"))
                    updateType = UpdateType.On;
                else if (parts[0].StartsWith("turn off"))
                    updateType = UpdateType.Off;
                else
                    updateType = UpdateType.Toggle;

                var startCoordinates = parts[0]
                    .Substring(startCoordinateIndex[updateType])
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var endCoordinates = parts[1]
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var update = new LightUpdate
                {
                    RowStart = startCoordinates[0],
                    ColumnStart = startCoordinates[1],
                    RowEnd = endCoordinates[0],
                    ColumnEnd = endCoordinates[1],
                    UpdateType = updateType
                };

                yield return update;
            }
        }
    }

    internal enum UpdateType
    {
        On,
        Off,
        Toggle
    }

}
