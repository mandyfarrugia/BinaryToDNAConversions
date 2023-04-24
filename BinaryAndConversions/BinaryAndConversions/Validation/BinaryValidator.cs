using System;
using System.Text.RegularExpressions;

namespace BinaryAndDNAConversion.Validation
{
	/// <summary>
	/// 
	/// </summary>
	public class BinaryValidator : Validator
	{
		public BinaryValidator()
		{
			this.regex = new Regex("^[01]+$");
		}

		public bool IsLengthOfBinaryPatternEven(string binaryPattern) => binaryPattern.Length % 2 == 0; 
	}
}

