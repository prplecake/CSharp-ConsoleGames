using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGames.RockPaperScissors.Tests;

[TestClass]
public class RockPaperScissorsTests
{
    [TestMethod]
    public void OpponentChoiceTests()
    {
        // Arrange
        List<string> okResults = new() { "rock", "paper", "scissors" };

        // Act
        List<bool> results = new();
        for (int i = 0; i < 3; i++)
        {
            results.Add(okResults.Contains(RockPaperScissors.OpponentChoice(i)));
        }

        // Assert
        Assert.IsTrue(results[0]);
        Assert.IsTrue(results[1]);
        Assert.IsTrue(results[2]);
    }
    [TestMethod]
    public void ScoreGameTests()
    {
        // Arrange
        string p = "paper";
        string r = "rock";
        string s = "scissors";

        // Assert
        Assert.AreEqual("tie", RockPaperScissors.ScoreGame(r, r));
        Assert.AreEqual("win", RockPaperScissors.ScoreGame(s, r));
        Assert.AreEqual("lose", RockPaperScissors.ScoreGame(p, r));

        Assert.AreEqual("tie", RockPaperScissors.ScoreGame(p, p));
        Assert.AreEqual("lose", RockPaperScissors.ScoreGame(p, r));
        Assert.AreEqual("win", RockPaperScissors.ScoreGame(p, s));

        Assert.AreEqual("tie", RockPaperScissors.ScoreGame(s, s));
        Assert.AreEqual("lose", RockPaperScissors.ScoreGame(s, p));
        Assert.AreEqual("win", RockPaperScissors.ScoreGame(s, r));
    }
}
