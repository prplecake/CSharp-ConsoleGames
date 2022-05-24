using System;
using System.Collections.Generic;

namespace FMinus.ConsoleGames.ScrabbleScore
{
    public static class Scrabble
    {
        public readonly static IDictionary<int, string> LetterScores = new Dictionary<int, string>
        {
            {1, "aeiolnstur" },
            {2, "dg" },
            {3, "bcmp" },
            {4, "fhvwy" },
            {5, "k" },
            {8, "jx" },
            {10, "qz" }
        };
        public static int GetScore(string inputString)
        {
            // Null check the variables
            if (string.IsNullOrEmpty(inputString))
            {
                return 0;
            }

            // Convert the scring into an array of letters.
            List<char> source = new List<char>();
            source.AddRange(inputString.ToLower());

            int score = 0;
            foreach (char c in source)
            {
                foreach (KeyValuePair<int, string> keyValuePair in LetterScores)
                {
                    if (keyValuePair.Value.Contains(c))
                    {
                        Console.WriteLine($"{keyValuePair.Key}::{c}");
                        score += keyValuePair.Key;
                    }

                }
            }
            return score;
        }
    }
}
