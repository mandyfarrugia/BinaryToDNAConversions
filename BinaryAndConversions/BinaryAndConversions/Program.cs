using BinaryAndDNAConversions.Validation;

namespace BinaryAndDNAConversions;

class Program
{
    static void Main(string[] args)
    {
        DNAValidator dNAValidator = new DNAValidator();
        Console.WriteLine(dNAValidator.IsFormatCorrect("BAAAA"));
        Console.WriteLine(dNAValidator.IsFormatCorrect("ACGT"));
        Console.ReadLine();
    }
}