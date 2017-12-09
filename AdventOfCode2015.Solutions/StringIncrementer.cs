using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2015.Solutions
{
	public class StringIncrementer
	{
		private readonly string _letterWheel;

		public StringIncrementer(string letterWheel)
		{
			_letterWheel = letterWheel;
		}

		public IEnumerable<string> IncrementPassword(char[] password)
		{
			string terminationString = GetTerminatingString(password);

			var letterWheelSize = _letterWheel.Length;
			var rightMostCharIndex = password.Length - 1;
			var reachedTerminatingString = false;
			while (!reachedTerminatingString)
			{
				var rightMostChar = password.Length - 1;
				foreach (var letter in GetNextLetters(password[rightMostChar]))
				{
					password[rightMostChar] = letter;
					yield return new string(password);
				}
				var current = new string(password);
				reachedTerminatingString = current == terminationString;
				if (reachedTerminatingString)
					break;

				password[rightMostChar] = _letterWheel[rightMostChar];

				for (int i = password.Length - 1; i >= 0; i--)
				{
					password[i] = GetNextLetter(password[i]);
					if (password[i] != _letterWheel[0])
					{
						yield return new string(password);
						break;
					}
				}
			}
		}

		private int GetNextLetterIndex(char letter)
		{
			return (_letterWheel.IndexOf(letter) + 1) % _letterWheel.Length;
		}

		private char GetNextLetter(char letter)
		{
			return _letterWheel[GetNextLetterIndex(letter)];
		}

		private IEnumerable<char> GetNextLetters(char letter)
		{
			var nextLetterIndex = GetNextLetterIndex(letter);
			for (var k = nextLetterIndex; k < _letterWheel.Length; k++)
				yield return _letterWheel[k];
		}

		private string GetTerminatingString(char[] password)
		{
			var lastCharAsString = _letterWheel[_letterWheel.Length - 1].ToString();
			return new StringBuilder(password.Length)
				.Insert(0, lastCharAsString, password.Length)
				.ToString();
		}
	}
}
