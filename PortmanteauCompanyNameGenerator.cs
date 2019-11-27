using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyNameGenerator
{
    public class PortmanteauCompanyNameGenerator
    {
        public class Input
        {
            public List<string> BaselineWords = new List<string>
            {
                "apple", "banana", "coal", "dog", "elephant", "fang", "ground",
                "high", "igloo", "jostle", "kind", "lame", "money", "name",
                "operation", "patient", "question", "rowboat", "soothing",
                "trumpet", "ukelele", "violin", "watermelon", "xylophone", "yesterday", "zebra"
            };
            public List<string> Words;
            public Dictionary<char, List<string>> WordsByFirstCharacter;
            public Random Random;

            public Input(IEnumerable<string> words, Random random)
            {
                this.Words = BaselineWords
                    .Concat(words)
                    .Where(w => w.Length >= 2)
                    .Select(w => w.ToLowerInvariant())
                    .Distinct()
                    .ToList();

                this.WordsByFirstCharacter = this.Words
                    .GroupBy(w => w[0])
                    .ToDictionary(g => g.Key, g => g.ToList());

                this.Random = random;

                Dbc.Invariant(this.Words.Any());
                Dbc.Invariant(this.WordsByFirstCharacter.Any());
            }
        }

        public static List<string> GenerateNames(Input input, int nameCount, int minLength, int maxLength)
        {
            // NOTE: this could result in infinite loops
            var names = new List<string>();

            while (names.Count < nameCount)
            {
                var possibleName = GenerateName(input);
                if ((possibleName.Length >= minLength) && (possibleName.Length <= maxLength))
                {
                    names.Add(possibleName);
                }
            }

            return names;
        }

        private static string GenerateName(Input input)
        {
            var firstWordIndex = input.Random.Next(0, input.Words.Count);
            var firstWord = input.Words[firstWordIndex];

            var secondWordStartIndex = 1 + input.Random.Next(0, firstWord.Length - 1);
            var secondWordFirstCharacter = firstWord[secondWordStartIndex];

            var possibleSecondWords = input.WordsByFirstCharacter[secondWordFirstCharacter];
            var secondWordIndex = input.Random.Next(0, possibleSecondWords.Count);
            var secondWord = possibleSecondWords[secondWordIndex];

            var name = firstWord.Substring(0, secondWordStartIndex) + secondWord;
            return name;
        }
    }
}
