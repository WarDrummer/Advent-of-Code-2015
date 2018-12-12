using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day14B : Day14A
    {
        public override string Solve()
        {
            var reindeer = GetReindeer();

            for (var i = 1; i <= 2503; i++)
            {
                reindeer.ForEach(r => r.SetDistance(i));
                var maxDistance = reindeer.Max(r => r.Distance);
                reindeer.Where(r => r.Distance == maxDistance).ToList().ForEach(r => r.Points++);
            }

            return reindeer.Max(r => r.Points).ToString();
        }
    }
}
