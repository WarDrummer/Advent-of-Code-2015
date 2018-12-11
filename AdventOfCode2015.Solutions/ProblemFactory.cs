using System.Reflection;

namespace AdventOfCode2015.Solutions
{
    public static class ProblemFactory
    {
        public static IProblem Create<T>() where T : IProblem
        {
            return (IProblem)Assembly.GetExecutingAssembly()
                .CreateInstance(typeof(T).FullName);
        }

        public static IProblem CreateFullyDecorated<T>() where T : IProblem
        {
            return ((IProblem)Assembly.GetExecutingAssembly()
                .CreateInstance(typeof(T).FullName))
                .SendToClipboard()
                .AppendTime();
        }
    }
}
