using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace CompanyNameGenerator
{
    public class Program
    {
        public static readonly string[] TxtFileUris = new []
        {
            //"https://raw.githubusercontent.com/dwyl/english-words/master/words_alpha.txt",
            //"http://www.mieliestronk.com/corncob_lowercase.txt",
            "http://www.gutenberg.org/files/1342/1342-0.txt", // Pride and Prejudice
            "http://www.gutenberg.org/files/1661/1661-0.txt", // The Adventures of Sherlock Holmes
            "https://raw.githubusercontent.com/first20hours/google-10000-english/master/google-10000-english.txt"
        };

        public const int NameCount = 1000;
        public const int MinLength = 5;
        public const int MaxLength = 10;

        public static async Task Main(string[] args)
        {
            var texts = await Task.WhenAll(
                TxtFileUris
                    .Select(uri => Utils.DownloadTxtFileWithHttpGet(new Uri(uri)))
            );
            var words = texts
                .SelectMany(t => Utils.GetWords(t))
                .ToList();
            var generatorInput = new PortmanteauCompanyNameGenerator.Input(words, new Random());

            while (true)
            {
                var companyNames = PortmanteauCompanyNameGenerator.GenerateNames(generatorInput, nameCount: 1, MinLength, MaxLength);
                foreach (var companyName in companyNames)
                {
                    Console.WriteLine(companyName);
                    Speak(companyName);
                }

                await Task.Delay(2000);
            }
        }

        private static void Speak(string textToSpeech, bool wait = false)
        {
            // Command to execute PS  
            Execute($@"Add-Type -AssemblyName System.speech;  
            $speak = New-Object System.Speech.Synthesis.SpeechSynthesizer;                           
            $speak.Speak(""{textToSpeech}"");"); // Embedd text  

            void Execute(string command)
            {
                // create a temp file with .ps1 extension  
                var cFile = System.IO.Path.GetTempPath() + Guid.NewGuid() + ".ps1";
                File.WriteAllText(cFile, command);

                // Setup the PS  
                var start =
                    new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "C:\\windows\\system32\\windowspowershell\\v1.0\\powershell.exe",  // CHUPA MICROSOFT 02-10-2019 23:45                    
                        LoadUserProfile = false,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        Arguments = $"-executionpolicy bypass -File {cFile}",
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                    };

                //Init the Process  
                var p = System.Diagnostics.Process.Start(start);
                // The wait may not work! :(  
                if (wait) p.WaitForExit();
            }
        }
    }
}
