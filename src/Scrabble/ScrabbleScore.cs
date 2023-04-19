namespace ConsoleGames.Scrabble;

/// <summary>
/// A class providing a method to calculate the Scrabble score of a given
/// string.
/// </summary>
public static class ScrabbleScore
{
    /// <summary>
    /// A dictionary of letter point values as keys with the respective
    /// letters as in a string.
    /// </summary>
    public static readonly IDictionary<int, string> LetterScores = new Dictionary<int, string>
    {
        {1, "aeiolnstur" },
        {2, "dg" },
        {3, "bcmp" },
        {4, "fhvwy" },
        {5, "k" },
        {8, "jx" },
        {10, "qz" }
    };
    /// <summary>
    /// Returns the Scrabble score of the provided string.
    /// </summary>
    /// <param name="inputString">The string the calculate the score for.</param>
    /// <returns></returns>
    public static int GetScore(string? inputString)
    {
        // Null check the variables
        if (string.IsNullOrEmpty(inputString))
        {
            return 0;
        }

        // Convert the scring into an array of letters.
        List<char> source = new();
        source.AddRange(inputString.ToLower());

        int score = 0;
        foreach (char c in source)
        {
            foreach (KeyValuePair<int, string> keyValuePair in LetterScores)
            {
                if (keyValuePair.Value.Contains(c))
                {
                    score += keyValuePair.Key;
                }
            }
        }
        return score;
    }
}