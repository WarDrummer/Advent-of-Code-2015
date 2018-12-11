namespace AdventOfCode2015.Solutions.Days
{
    public class Day16B : Day16A
    {
        protected override bool IsMatch(string compoundName, int compoundCount)
        {
            switch (compoundName)
            {
                case "cats":
                case "trees":
                    return compoundCount > TickerTape.GetMatchCount(compoundName);
                case "pomeranians":
                case "goldfish":
                    return compoundCount < TickerTape.GetMatchCount(compoundName);
                default:
                    return TickerTape.GetMatchCount(compoundName) == compoundCount;
            }
        }
    }
}