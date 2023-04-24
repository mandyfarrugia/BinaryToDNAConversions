using System;
using System.Text.RegularExpressions; //To be able to access the Regex class and its members.

namespace BinaryAndDNAConversion.Validation
{
	/// <summary>
	/// Validator is the base class from which classes which contain methods related to validation specific to binary patterns
	/// and DNA patterns will eventually inherit. The generic base class contains methods which check for null and empty strings.
	/// The definition of an empty string is as follows, either the string can be empty where the length of the string is exactly zero,
	/// or the string contains only whitespace. In the case of single-line methods, expression-bodied methods will be used.
	/// </summary>
	public class Validator
	{
		/// <summary>
		/// The attribute regex has been marked as protected since it will be used in classes deriving from Validator.
		/// This will be used to check whether a binary/DNA pattern is of the correct format by comparing the input to a pattern expression.
		/// </summary>
		protected Regex? regex = null;

		/// <summary>
		/// The constructor of the base class initialises the attribute of type Regex to null.
		/// This is because at this point, there is no need to check for the format of a pattern.
		/// This will be handled in the specialised classes which inherit this base class.
		/// </summary>
		public Validator()
		{
			/* At this point, there is no need to worry about pattern matching. Therefore, regex attribute can be set to null. 
			 * Pattern matching will take place in specialised classes. */
			this.regex = null;
		}

		/// <summary>
		/// Checks whether the input supplied as a parameter is null.
		/// </summary>
		/// <param name="input">Represents the input to be checked for null. If the result is true (thus the input is null),
		/// exceptions can be thrown, namely ArgumentNullException if an argument passed to method invocation is null.</param>
		/// <returns>Returns true if input is null, false if otherwise.</returns>
		public bool IsNull(string input) => input == null;

		/// <summary>
		/// Checks whether the input supplied as a parameter is empty.
		/// </summary>
		/// <param name="input">Represents the input to be checked as to whether it is empty or contains only whitespace.</param>
		/// <returns>Returns true if input is empty if and only if the length of the string is exactly zero, or the string contains only whitespaces.</returns>
		public bool IsEmpty(string input) => string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input);

		/// <summary>
		/// Checks whether the input matches the pattern expression set in the instance of Regex.
		/// Since the method will be used by both classes validating DNA and binary patterns respectively,
		/// then the method will be in the base class for both specialised Validator types to inherit.
		/// The only difference would be the pattern set to the regex attribute accordingly.
		/// </summary>
		/// <param name="input">Represents the input to be checked for correctness.</param>
		/// <returns></returns>
		public bool IsFormatCorrect(string input) => this.regex!.IsMatch(input);
	}
}