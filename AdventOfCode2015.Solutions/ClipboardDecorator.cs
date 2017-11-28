using System;
using System.Windows.Forms;

namespace AdventOfCode2015.Solutions
{
    internal class ClipboardDecorator : IProblem
    {
        private readonly IProblem _problem;

        public ClipboardDecorator(IProblem problem)
        {
            _problem = problem;
        }

        public string Solve()
        {
            string result;
            try
            {
                result = _problem.Solve();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            Clipboard.SetText(result);
            return result;
        }
    }
}