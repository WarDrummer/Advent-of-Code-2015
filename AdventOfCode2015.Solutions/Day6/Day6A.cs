namespace AdventOfCode2015.Solutions.Day6
{
    internal class Day6A : IProblem
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

}
