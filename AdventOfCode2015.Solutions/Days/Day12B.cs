using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Solutions.Days
{
    public class Day12B : Day12A
    {
        public override string Solve()
        {
            var doc = Parser.Parse();

            // find occurrences of "red" values (must be preceded by ':' to rule out array values) 
            var redIndices = GetAllIndexes(doc, ":\"red\"");

            // work back up to the start of the object containing a red value
            var redObjectStartIndices = GetRedObjectStartIndices(redIndices, doc);

            var stack = new Stack<int>();

            var inString = false;
            var total = 0;
            var inRedObject = false;
            for (var i = 0; i < doc.Length; i++)
            {
                var c = doc[i];
                
                if (c == '"')
                    inString = !inString;

                if (inString)
                    continue;

                if (c == '{' && (redObjectStartIndices.Contains(i) || inRedObject))
                {
                    inRedObject = true;
                    stack.Push(i);
                }
                if (c == '}' && inRedObject)
                {
                    stack.Pop();
                    inRedObject = stack.Count > 0;
                }

                if (inRedObject)
                    continue;

                var isNegative = false;
                if (c == '-')
                {
                    isNegative = true;
                    i++;
                }

                var num = 0;
                while (char.IsDigit(doc[i]))
                    num = num * 10 + doc[i++] - '0';
                total += isNegative ? -1 * num : num;
            }

            return total.ToString();
        }

        private static HashSet<int> GetRedObjectStartIndices(IEnumerable<int> redIndices, string doc)
        {
            var redObjectStartIndices = new HashSet<int>();
            foreach (var ri in redIndices)
            {
                var closeCount = 0;
                var idx = ri;
                while (doc[idx] != '{' || closeCount > 0)
                {
                    if (doc[idx] == '}')
                        closeCount++;
                    else if (doc[idx] == '{')
                        closeCount--;

                    idx--;
                }

                redObjectStartIndices.Add(idx);
            }

            return redObjectStartIndices;
        }

        public static IEnumerable<int> GetAllIndexes(string source, string matchString)
        {
            matchString = Regex.Escape(matchString);
            foreach (Match match in Regex.Matches(source, matchString))
                yield return match.Index;
        }
    }
}
