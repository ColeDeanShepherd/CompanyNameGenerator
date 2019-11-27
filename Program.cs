using System;
using System.Collections.Generic;

namespace CompanyNameGenerator
{
    public class Phoneme
    {
        // Sourced from https://www.dyslexia-reading-well.com/44-phonemes-in-english.html
        public static readonly List<Phoneme> EnglishPhonemes = new List<Phoneme>
        {
            new Phoneme { IpaSymbol = "b", Graphemes = new List<string> { "b", "bb" } },
            new Phoneme { IpaSymbol = "d", Graphemes = new List<string> { "d", "dd", "ed" } },
            new Phoneme { IpaSymbol = "f", Graphemes = new List<string> { "f", "ff", "ph", "gh", "lf", "ft" } },
            new Phoneme { IpaSymbol = "g", Graphemes = new List<string> { "g", "gg", "gh", "gu", "gue" } },
            new Phoneme { IpaSymbol = "h", Graphemes = new List<string> { "h", "wh" } },
            new Phoneme { IpaSymbol = "dʒ", Graphemes = new List<string> { "j", "ge", "g", "dge", "di", "gg" } },
            new Phoneme { IpaSymbol = "k", Graphemes = new List<string> { "k", "c", "ch", "cc", "lk", "qu ", "q", "ck", "x" } },
            new Phoneme { IpaSymbol = "l", Graphemes = new List<string> { "l", "ll" } },
            new Phoneme { IpaSymbol = "m", Graphemes = new List<string> { "m", "mm", "mb", "mn", "lm" } },
            new Phoneme { IpaSymbol = "n", Graphemes = new List<string> { "n", "nn", "kn", "gn", "pn" } },
            new Phoneme { IpaSymbol = "p", Graphemes = new List<string> { "p", "pp" } },
            new Phoneme { IpaSymbol = "r", Graphemes = new List<string> { "r", "rr", "wr", "rh" } },
            new Phoneme { IpaSymbol = "s", Graphemes = new List<string> { "s", "ss", "c", "sc", "ps", "st", "ce", "se" } },
            new Phoneme { IpaSymbol = "t", Graphemes = new List<string> { "t", "tt", "th", "ed" } },
            new Phoneme { IpaSymbol = "v", Graphemes = new List<string> { "v", "f", "ph", "ve" } },
            new Phoneme { IpaSymbol = "w", Graphemes = new List<string> { "w", "wh", "u", "o" } },
            new Phoneme { IpaSymbol = "z", Graphemes = new List<string> { "z", "zz", "s", "ss", "x", "ze", "se" } },
            new Phoneme { IpaSymbol = "ʒ", Graphemes = new List<string> { "s", "si", "z" } },
            new Phoneme { IpaSymbol = "tʃ", Graphemes = new List<string> { "ch", "tch", "tu", "ti", "te" } },
            new Phoneme { IpaSymbol = "ʃ", Graphemes = new List<string> { "sh", "ce", "s", "ci", "si", "ch", "sci", "ti" } },
            new Phoneme { IpaSymbol = "θ", Graphemes = new List<string> { "th " } },
            new Phoneme { IpaSymbol = "ð", Graphemes = new List<string> { "th" } },
            new Phoneme { IpaSymbol = "ŋ", Graphemes = new List<string> { "ng", "n", "ngue" } },
            new Phoneme { IpaSymbol = "j", Graphemes = new List<string> { "y", "i", "j" } },
            new Phoneme { IpaSymbol = "æ", Graphemes = new List<string> { "a", "ai", "au" } },
            new Phoneme { IpaSymbol = "eɪ", Graphemes = new List<string> { "a", "ai", "eigh", "aigh", "ay", "er", "et", "ei", "au", "a_e", "ea", "ey" } },
            new Phoneme { IpaSymbol = "e", Graphemes = new List<string> { "e", "ea", "u", "ie", "ai", "a", "eo", "ei", "ae" } },
            new Phoneme { IpaSymbol = "i:", Graphemes = new List<string> { "e", "ee", "ea", "y", "ey", "oe", "ie", "i", "ei", "eo", "ay" } },
            new Phoneme { IpaSymbol = "ɪ", Graphemes = new List<string> { "i", "e", "o", "u", "ui", "y", "ie" } },
            new Phoneme { IpaSymbol = "aɪ", Graphemes = new List<string> { "i", "y", "igh", "ie", "uy", "ye", "ai", "is", "eigh", "i_e" } },
            new Phoneme { IpaSymbol = "ɒ", Graphemes = new List<string> { "a", "ho", "au", "aw", "ough" } },
            new Phoneme { IpaSymbol = "oʊ", Graphemes = new List<string> { "o", "oa", "o_e", "oe", "ow", "ough", "eau", "oo", "ew" } },
            new Phoneme { IpaSymbol = "ʊ", Graphemes = new List<string> { "o", "oo", "u", "ou" } },
            new Phoneme { IpaSymbol = "ʌ", Graphemes = new List<string> { "u", "o", "oo", "ou" } },
            new Phoneme { IpaSymbol = "u:", Graphemes = new List<string> { "o", "oo", "ew", "ue", "u_e", "oe", "ough", "ui", "oew", "ou" } },
            new Phoneme { IpaSymbol = "ɔɪ", Graphemes = new List<string> { "oi", "oy", "uoy" } },
            new Phoneme { IpaSymbol = "aʊ", Graphemes = new List<string> { "ow", "ou", "ough" } },
            new Phoneme { IpaSymbol = "ə", Graphemes = new List<string> { "a", "er", "i", "ar", "our", "ur" } },
            new Phoneme { IpaSymbol = "eəʳ", Graphemes = new List<string> { "air", "are", "ear", "ere", "eir", "ayer" } },
            new Phoneme { IpaSymbol = "ɑ:", Graphemes = new List<string> { "a" } },
            new Phoneme { IpaSymbol = "ɜ:ʳ", Graphemes = new List<string> { "ir", "er", "ur", "ear", "or", "our", "yr" } },
            new Phoneme { IpaSymbol = "ɔ:", Graphemes = new List<string> { "aw", "a", "or", "oor", "ore", "oar", "our", "augh", "ar", "ough", "au" } },
            new Phoneme { IpaSymbol = "ɪəʳ", Graphemes = new List<string> { "ear", "eer", "ere", "ier" } },
            new Phoneme { IpaSymbol = "ʊəʳ", Graphemes = new List<string> { "ure", "our" } },
        };

        public string IpaSymbol = "";
        public List<string> Graphemes = new List<string>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
