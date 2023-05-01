using System.Text;
using System.Text.RegularExpressions;
using BinaryAndDNAConversions.Mappings;
using BinaryAndDNAConversions.Validation;

namespace BinaryAndDNAConversions.BinaryConversion
{
    /// <summary>
    /// The Binary class consists of functionalities related to converting a binary pattern to a DNA pattern.
	/// The binary pattern can be hardcoded or loaded from a text file.
	/// Furthermore, a validation class specific to binary patterns named BinaryValidator,
	/// which inherits from will be used to check that the binary pattern is in the correct format.
	/// The binary pattern must only contain 0s and 1s, and the length of the binary pattern must be an even number.
	/// </summary>
	public class Binary
	{
        //Declare attribute of type BinaryValidator to be able to perform validation checks specific to binary patterns.
        private BinaryValidator? binaryValidator = null;

		/// <summary>
		/// The constructor will create an instance of type BinaryValidator and save it to the binaryValidator attribute.
		/// </summary>
		public Binary()
		{
			this.binaryValidator = new BinaryValidator();
        }

        /// <summary>
		/// The method will start by validating that the parameter representing the binary pattern is of the correct format.
		/// First, it starts by checking whether the binary pattern is null or empty,
		/// followed by checking whether the binary pattern consists of 0s and 1s,
		/// as well as that the length of the binary pattern is even.
		/// Using Regex, the binary pattern will be split into groups of two bits.
		/// A for-loop will be used to traverse each group to check whether it matches the key of the map
		/// returned by getMappings() in Data. If there is a match, then the value counterpart of the map
		/// will be appended to a string which the method will return.
        /// </summary>
        /// <param name="dnaPattern">
        /// Represents the binary pattern to be converted to DNA.
        /// The value can be hardcoded or retrieved from a text file.
        /// </param>
        /// <returns>When all validation checks pass, the DNA equivalent of the binary pattern will be returned.</returns>
        public string ConvertToDNA(string binaryPattern)
		{
            /* If the binary pattern is null, an ArgumentNullException will be thrown. 
			 * A message will be passed when throwing an exception to explain what caused the exception. */
            if (this.binaryValidator!.IsNull(binaryPattern))
				throw new ArgumentNullException(nameof(binaryPattern), "The binary pattern cannot be null!");

            /* If the binary pattern is empty or contains only a whitespace, an ArgumentException will be thrown. 
             * A message will be passed when throwing an exception to explain what caused the exception. */
            if (this.binaryValidator!.IsEmpty(binaryPattern))
				throw new ArgumentException("The binary pattern cannot be empty or contain only whitespaces!", nameof(binaryPattern));

            //Check that the binary pattern contains only 0s and 1s, throw a FormatException if otherwise.
            if (!this.binaryValidator.IsFormatCorrect(binaryPattern))
				throw new FormatException("The binary pattern must only contain 0s and 1s!");

            //Check that the length of the binary pattern is even, throw an ArgumentException if the length is odd.
            if (!this.binaryValidator.IsLengthOfBinaryPatternEven(binaryPattern))
				throw new ArgumentException("The length of the binary pattern is not even!", nameof(binaryPattern));

            /* The binary string will be grouped into bits of two. 
             * Then each group will be traversed using a for-loop to check whether they match the keys representing the binary patterns. 
             * If there is a match, then the value corresponding to the key will be appended to this variable which the method will return.\
             * The regular expression denotes that the binary pattern must be split every two characters. 
             * Therefore, this groups the binary patterns into two bits. */
            string[] groupsOfTwoBits = Regex.Split(binaryPattern, "(?<=\\G.{2})");

            //Throw InvalidOperationException if an error occurred while attempting to split the binary pattern into groups of two bits.
            if (groupsOfTwoBits == null || groupsOfTwoBits.Length == 0)
				throw new InvalidOperationException("An error occurred while attempting to split the binary pattern into groups of two bits!");

            //A StringBuilder instance is more efficient to append to said instance, rather than appending to a string using +=.
            StringBuilder stringBuilder = new StringBuilder();

            /* Go through each group and see whether they match the key counterpart of dataConversionEntry. 
             * If there is a match, append the value counterpart of dataConversionEntry to dnaPattern. */
            Dictionary<string, string> binaryAndDNAMappings = DataMapping.GetMappings();

			foreach(string groupOfTwoBits in groupsOfTwoBits)
			{
				foreach(KeyValuePair<string, string> binaryAndDNAMapping in binaryAndDNAMappings)
				{
					if (groupOfTwoBits.Equals(binaryAndDNAMapping.Key))
						stringBuilder.Append(binaryAndDNAMapping.Value);
				}
			}

			return stringBuilder.ToString();
		}
	}
}