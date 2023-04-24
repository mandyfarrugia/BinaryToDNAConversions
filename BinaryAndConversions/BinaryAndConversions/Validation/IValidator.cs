namespace BinaryAndDNAConversions.Validation
{
	/// <summary>
	/// IValidator is an interface describing actions that should be carried out by any type of Validator.
	/// Therefore, IValidator simply contains a list of methods related to validation checks common to any type of input,
	/// be it a binary pattern, DNA pattern, path to a file, and so on and so forth.
	/// </summary>
	public interface IValidator
	{
        /// <summary>
        /// Checks whether the input supplied as a parameter is empty.
        /// </summary>
        /// <param name="input">Represents the input to be checked as to whether it is empty or contains only whitespace.</param>
        /// <returns>Returns true if input is empty if and only if the length of the string is exactly zero, or the string contains only whitespaces.</returns>
        public bool IsEmpty(string input);

        /// <summary>
        /// Checks whether the input supplied as a parameter is null.
        /// </summary>
        /// <param name="input">Represents the input to be checked for null. If the result is true (thus the input is null),
		/// exceptions can be thrown, namely ArgumentNullException if an argument passed to method invocation is null.</param>
        /// <returns>Returns true if input is null, false if otherwise.</returns>
        public bool IsNull(string input);
	}
}