using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyNameGenerator
{
    public class TwoWordNameGenerator
    {
        public enum OptionalWordPosition
        {
            Start,
            End,
            StartOrEnd
        }

        public class Input
        {
            public string? OptionalWordToInclude = null;
            public OptionalWordPosition OptionalWordPosition = OptionalWordPosition.StartOrEnd;
            public List<string> BaselineWords = new List<string>
            {
                "apple", "banana", "coal", "dog", "elephant", "fang", "ground",
                "high", "igloo", "jostle", "kind", "lame", "money", "name",
                "operation", "patient", "question", "rowboat", "soothing",
                "trumpet", "ukelele", "violin", "watermelon", "xylophone", "yesterday", "zebra"
            };
            public List<string> Words;
            public Random Random;

            public Input(IEnumerable<string> words, Random random)
            {
                this.Words = BaselineWords
                    .Concat(words)
                    .Where(w => w.Length >= 2)
                    .Select(w => w.ToLowerInvariant())
                    .Distinct()
                    .ToList();

                this.Random = random;

                Dbc.Invariant(this.Words.Any());
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
            var word1 = input.OptionalWordToInclude ?? input.Words[input.Random.Next(0, input.Words.Count)];
            var word2 = input.Words[input.Random.Next(0, input.Words.Count)];

            switch (input.OptionalWordPosition)
            {
                case OptionalWordPosition.Start:
                    return word1 + word2;
                case OptionalWordPosition.End:
                    return word2 + word1;
                case OptionalWordPosition.StartOrEnd:
                    return (input.Random.NextDouble() < 0.5)
                        ? (word1 + word2)
                        : (word2 + word1);
                default:
                    throw new NotImplementedException($"Unknown {nameof(OptionalWordPosition)}: {input.OptionalWordPosition}");
            }
        }
    }
}
