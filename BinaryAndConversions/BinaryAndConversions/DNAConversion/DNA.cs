using System;
using BinaryAndDNAConversions.Validation;

namespace BinaryAndDNAConversions.DNAConversion
{
	public class DNA
	{
		private DNAValidator? dnaValidator = null;

		public DNA()
		{
			this.dnaValidator = new DNAValidator();
		}
	}
}