using System.Text.RegularExpressions; //To be able to access the Regex class and its members.

namespace BinaryAndDNAConversions.Validation
{
    /// <summary>
    /// DNAValidator is a specialised type of Validator (thus the DNAValidator class inherits from the Validator base class).
    /// It is used to perform validation checks specific to DNA patterns, namely whether a DNA pattern is of the correct format
    /// if and only if it only contains the following characters A, C, G, and T.
    /// </summary>
    public class DNAValidator : Validator
	{
        /// <summary>
		/// The regex attribute inherited from the Validator base class will be instantiated.
		/// The argument to be passed during constructor invocation is the pattern resembling a DNA pattern.
		/// The instance will then be used to check as to whether the format of the given DNA pattern matches
		/// the pattern specified whilst instantiating the instance of Regex.
		/// </summary>
		public DNAValidator() : base()
		{
            this.regex = new Regex("^[ACGT]+$");   
		}
	}
}