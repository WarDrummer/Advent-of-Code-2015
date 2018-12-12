using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Solutions.Days
{
	using ParserType = MultiLineStringParser;

	public class Day14A : IProblem
	{
		protected readonly ParserType Parser;

		public Day14A(ParserType parser) { Parser = parser; }

		public Day14A() : this(new ParserType("day14.in")) { }

		public virtual string Solve()
		{
		    return GetReindeer().Max(r => r.GetDistance(2503)).ToString();
		}

	    protected List<Reindeer> GetReindeer()
	    {
	        var reindeer = new List<Reindeer>();

	        var lines = Parser.Parse();
	        foreach (var line in lines)
	        {
	            var parts = line.Split(' ');
	            reindeer.Add(new Reindeer(parts[0], int.Parse(parts[3]), int.Parse(parts[6]), int.Parse(parts[13])));
	        }

	        return reindeer;
	    }
	}

    public class Reindeer
    {
        public string Name { get; }
        public int Duration { get; }
        public int Speed { get; }
        public int Rest { get; }
        public int Distance { get; private set; }
        public int Points { get; set; }

        public Reindeer(string name, int speed, int duration, int rest)
        {
            Name = name;
            Duration = duration;
            Speed = speed;
            Rest = rest;
        }

        public int GetDistance(int seconds)
        {
            var full = seconds / (Duration + Rest) * (Duration * Speed);
            var partial = Math.Min(Duration, seconds % (Duration + Rest)) * Speed;
            return full + partial;
        }

        public void SetDistance(int second)
        {
            Distance = GetDistance(second);
        }
    }
}
