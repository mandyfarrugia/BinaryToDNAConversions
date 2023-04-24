using System;
using BinaryAndDNAConversions.Validation;

namespace BinaryAndDNAConversions.Validation
{
    /// <summary>
    /// DNAValidator is a specialised type of Validator (thus the DNAValidator class inherits from the Validator base class).
    /// It is used to perform validation checks specific to DNA patterns, namely whether a DNA pattern is of the correct format
    /// if and only if it only contains the following characters A, C, G, and T.
    /// </summary>
    public class DNAValidator : Validator
	{
		public DNAValidator() : base()
		{
            
		}
	}
}

