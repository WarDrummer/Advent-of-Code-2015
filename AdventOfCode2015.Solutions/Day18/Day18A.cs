namespace AdventOfCode2015.Solutions.Day18
{
    internal class Day18A : IProblem
    {
        private readonly IInputParser<string> _parser;

        public Day18A() : this(new SingleLineStringParser("Day18\\day18.in")) { }

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
}
