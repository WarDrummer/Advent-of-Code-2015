using System.Text;

namespace AdventOfCode2015.Solutions.Day10
{
    public class Day10A : IProblem
    {
        private readonly SingleLineStringParser _parser;

        public Day10A(SingleLineStringParser parser)
        {
            _parser = parser;
        }

        public Day10A() : this(new SingleLineStringParser("Day10\\day10.in"))
        {
            
        }
        public virtual string Solve()
        {
            return ApplyMutations(40);
        }

        protected string ApplyMutations(int timesToExecute)
        {
            var str = _parser.Parse();

            for (var i = 0; i < timesToExecute; i++)
                str = Mutate(str);

            return str.Length.ToString();
        }

        private string Mutate(string str)
        {
            var sb = new StringBuilder();
            var previous = str[0];
            var count = 1;
            for (var index = 1; index < str.Length; index++)
            {
                var c = str[index];
                if (c != previous)
                {
                    sb.Append(count).Append(previous);
                    previous = c;
                    count = 1;
                }
                else
                {
                    count++;
                }
            }
            sb.Append(count).Append(previous);

            return sb.ToString();
        }
    }
}
