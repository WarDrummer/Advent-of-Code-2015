using System.Collections.Generic;

namespace AdventOfCode2015.Solutions
{
	public class StringIncrementer
	{
		private readonly string _letterWheel;

        public StringIncrementer(string letterWheel)
		{
			_letterWheel = letterWheel;
		}

	    public IEnumerable<char[]> IncrementPassword(char[] password)
	    {
	        var lastIndex = password.Length - 1;

            while (true)
	        {
	            var nextLetterIndex = (_letterWheel.IndexOf(password[lastIndex]) + 1) % _letterWheel.Length;
	            for (var k = nextLetterIndex; k < _letterWheel.Length; k++)
	            {
	                password[lastIndex] = _letterWheel[k];
	                yield return password;
                }

	            password[lastIndex] = _letterWheel[0];

	            for (var i = lastIndex - 1; i >= 0; i--)
	            {
	                nextLetterIndex = (_letterWheel.IndexOf(password[i]) + 1) % _letterWheel.Length;
                    password[i] = _letterWheel[nextLetterIndex];
	                if (password[i] != _letterWheel[0])
	                {
	                    yield return password;
	                    break;
	                }
	            }
	        }	    
	    }
	}
}
