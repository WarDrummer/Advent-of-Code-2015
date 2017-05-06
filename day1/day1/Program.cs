using System;
using System.IO;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("input.txt"))
            {
                var parens = sr.ReadLine();
                if (parens != null)
                {
                    Part1(parens);
                    Part2(parens);
                }
            }
        }

        private static void Part1(string parens)
        {
            var floor = 0;
            
            foreach (var paren in parens)
            {
                if (paren == '(')
                    floor++;
                else if (paren == ')')
                    floor--;
            }

            Console.WriteLine($"Part 1: {floor}");
        }

        private static void Part2(string parens)
        {
            var floor = 0;
            var count = 0;

            foreach (var paren in parens)
            {
                count++;

                if (paren == '(')
                    floor++;
                else if (paren == ')')
                    floor--;

                if (floor < 0)
                    break;
            }

            Console.WriteLine($"Part 2: {count}");        
        }
    }
}
