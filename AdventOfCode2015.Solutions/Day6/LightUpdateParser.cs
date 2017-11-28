using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Solutions.Day6
{
    internal class LightUpdateParser : InputParser<IEnumerable<LightUpdate>>
    {
        public LightUpdateParser() : base("Day6\\day6.in") { }

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
                    new [] {" through "}, StringSplitOptions.RemoveEmptyEntries);

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
}