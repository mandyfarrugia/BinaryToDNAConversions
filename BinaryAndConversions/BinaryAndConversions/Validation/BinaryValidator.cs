using System;
using System.Text.RegularExpressions; //To be able to access the Regex class and its members.

namespace BinaryAndDNAConversions.Validation
{
	/// <summary>
	/// BinaryValidator is a specialised type of Validator (thus the BinaryValidator class inherits from the Validator base class).
	/// It is used to perform validation checks specific to binary patterns, such as checking whether the length of the binary pattern
	/// is even using the modulus operator, as well as whether a binary pattern is of the correct format if and only if it only contains
	/// 0s and 1s.
	/// </summary>
	public class BinaryValidator : Validator
	{
		/// <summary>
		/// The regex attribute inherited from the Validator base class will be instantiated.
		/// The argument to be passed during constructor invocation is the pattern resembling a binary pattern.
		/// The instance will then be used to check as to whether the format of the given binary pattern matches
		/// the pattern specified whilst instantiating the instance of Regex.
		/// </summary>
		public BinaryValidator() : base()
		{
			this.regex = new Regex("^[01]+$");
		}

        /// <summary>
        /// The method will check whether the remainder is 0 when dividing the length of the binary pattern by 2.
        /// If the remainder is 0, then the length is even, whereas odd if the remainder is 1.
        /// </summary>
        /// <param name="binaryPattern">
        /// Represents the binary pattern whose length will be checked as to whether it is even using the modulus operator.
        /// </param>
        /// <returns>Returns true if the length of the binary pattern is even. Otherwise, false is returned if the length of the binary pattern is odd.</returns>
        public static bool IsLengthOfBinaryPatternEven(string binaryPattern) => binaryPattern.Length % 2 == 0; 
	}
}