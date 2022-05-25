using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FMinus.ConsoleGames.ScrabbleScore.Tests
{
    [TestClass]
    public class ScrabbleScoreTests
    {
        [TestMethod]
        public void LetterScoresCompletion_Test()
        {
            // Arrange
            int expectedResult = 26;

            // Act
            int actualResult = 0;
            foreach (KeyValuePair<int, string> keyValuePair in Scrabble.LetterScores)
            {
                actualResult += keyValuePair.Value.Length;
            }

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LetterScoresMissing_Test()
        {
            // Arrange
            var fullAlphabet = Enumerable.Range('a', 26).Select(x => (char)x).ToList();
            var letterScoreAlphabet = new List<char>();
            var missingLetters = new List<char>();

            // Act
            foreach (KeyValuePair<int, string> keyValuePair in Scrabble.LetterScores)
            {
                foreach (char letter in keyValuePair.Value.ToArray())
                {
                    letterScoreAlphabet = letterScoreAlphabet.Append(letter).ToList();
                }
            }

            foreach (char letter in fullAlphabet)
            {
                if (!letterScoreAlphabet.Contains(letter))
                {
                    missingLetters = missingLetters.Append(letter).ToList();
                }
            }
            Console.WriteLine($"Missing letters: ");
            foreach (char letter in missingLetters)
            {
                Console.WriteLine(letter);
            }

            // Assert
            Assert.AreEqual(fullAlphabet.Count, 26);
            Assert.AreEqual(fullAlphabet.Count, letterScoreAlphabet.Count);

        }
    }
}
