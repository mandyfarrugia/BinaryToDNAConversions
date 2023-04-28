using System;
using System.Text;
using System.Text.RegularExpressions;
using BinaryAndDNAConversions.Mappings;
using BinaryAndDNAConversions.Validation;
using static System.Net.Mime.MediaTypeNames;

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
			if (this.binaryValidator!.IsNull(binaryPattern))
				throw new ArgumentNullException(nameof(binaryPattern), "The binary pattern cannot be null!");

			if (this.binaryValidator!.IsEmpty(binaryPattern))
				throw new ArgumentException("The binary pattern cannot be empty or contain only whitespaces!", nameof(binaryPattern));

			if (!this.binaryValidator.IsFormatCorrect(binaryPattern))
				throw new FormatException("The binary pattern must only contain 0s and 1s!");

			if (!this.binaryValidator.IsLengthOfBinaryPatternEven(binaryPattern))
				throw new ArgumentException("The length of the binary pattern is not even!", nameof(binaryPattern));

			string[] groupsOfTwoBits = Regex.Split(binaryPattern, "(?<=\\G.{2})");

			if (groupsOfTwoBits == null || groupsOfTwoBits.Length == 0)
				throw new InvalidOperationException("An error occurred while attempting to split the binary pattern into groups of two bits!");

			StringBuilder stringBuilder = new StringBuilder();

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