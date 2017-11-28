using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2015.Solutions
{
    public abstract class InputParser<T> : IInputParser<T>
    {
        private readonly string _inputFile;

        protected InputParser(string inputFile)
        {
            _inputFile = inputFile;
        }

        protected IEnumerable<string> GetInput()
        {
            using (var sr = new StreamReader(_inputFile))
            {
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLine();
                }
            }
        }

        public abstract T Parse();
    }
}