using System;
namespace BinaryAndDNAConversions.Mappings
{
	public class DataMapping
	{
		public static Dictionary<string, string> GetMappings()
		{
			Dictionary<string, string> binaryAndDNAMappings = new Dictionary<string, string>()
			{
				{"00", "A"},
				{"01", "C"},
				{"10", "G"},
				{"11", "T"}
			};

			return binaryAndDNAMappings;
		}
	}
}Í