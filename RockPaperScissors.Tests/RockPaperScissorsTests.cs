using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FMinus.ConsoleGames.RockPaperScissors.Tests;

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
            results.Add(okResults.Contains(RPS.OpponentChoice(i)));
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
        Assert.AreEqual("tie", RPS.ScoreGame(r, r));
        Assert.AreEqual("win", RPS.ScoreGame(s, r));
        Assert.AreEqual("lose", RPS.ScoreGame(p, r));

        Assert.AreEqual("tie", RPS.ScoreGame(p, p));
        Assert.AreEqual("lose", RPS.ScoreGame(p, r));
        Assert.AreEqual("win", RPS.ScoreGame(p, s));

        Assert.AreEqual("tie", RPS.ScoreGame(s, s));
        Assert.AreEqual("lose", RPS.ScoreGame(s, p));
        Assert.AreEqual("win", RPS.ScoreGame(s, r));
    }
}
