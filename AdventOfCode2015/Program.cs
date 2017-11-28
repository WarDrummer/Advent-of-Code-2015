using System;
using AdventOfCode2015.Solutions;

namespace AdventOfCode2015
{
    
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine(
                ProblemFactory.Create(ProblemId.Day24A)
                .SendToClipboard()
                .AppendTime()
                .Solve());

            Console.ReadKey();
        }
    }
}
