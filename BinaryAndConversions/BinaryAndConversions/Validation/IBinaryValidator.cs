using System;

namespace BinaryAndDNAConversions.Validation
{
	public interface IBinaryValidator
	{
        public bool IsLengthOfBinaryPatternEven(string binaryPattern);
    }
}