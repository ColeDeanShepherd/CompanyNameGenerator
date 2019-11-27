using System;
using System.Threading.Tasks;

namespace CompanyNameGenerator
{
    public class Program
    {
        public const string EnglishWordListTxtFileUri = "http://www.mieliestronk.com/corncob_lowercase.txt";
        public const string PrideAndPrejudiceTxtFileUri = "http://www.gutenberg.org/files/1342/1342-0.txt";

        public const int NameCount = 1000;
        public const int MaxLength = 10;

        public static async Task Main(string[] args)
        {
            var text = await Utils.DownloadTxtFileWithHttpGet(new Uri(EnglishWordListTxtFileUri));
            var words = Utils.GetWords(text);
            var generatorInput = new PortmanteauCompanyNameGenerator.Input(words, new Random());
            var companyNames = PortmanteauCompanyNameGenerator.GenerateNames(generatorInput, NameCount, MaxLength);

            foreach (var companyName in companyNames)
            {
                Console.WriteLine(companyName);
            }
        }
    }
}
