using System;
using System.Collections.Generic;
using System.Linq;

namespace FMinus.ConsoleGames.RockPaperScissors
{
    public class RPS
    {
        private static readonly Random getrandom = new();
        private static int Randoms()
        {
            lock (getrandom)
            {
                return getrandom.Next(0, 3);
            }
        }
        private static string OpponentChoice(int seed)
            => new Dictionary<int, string>
            {
                { 0, "rock" },
                { 1, "paper" },
                { 2, "scissors" }
            }[seed];
        /// <summary>
        /// Gets the user's choice or exits if the choice was invalid.
        /// </summary>
        /// <returns>
        /// A string value of one of: "rock", "paper", or "scissors".
        /// </returns>
        private static string UserChoice()
        {
            string[] _options = new[] { "rock", "paper", "scissors" };
            Console.Write("Make a decision (rock, paper, scissors): ");
            string? userChoice = Console.ReadLine();
            if (!_options.Contains(userChoice))
            {
                Console.WriteLine("Input not found. You lose.");
                Environment.Exit(1);
            }
            return userChoice!;
        }
        private static string ScoreGame(string opponentChoice, string userChoice)
            => _scoreMatrix[userChoice][opponentChoice];
        public static void PlayGame()
        {
            int userScore = 0;
            int opponentScore = 0;
            while ((userScore < 3) && (opponentScore < 3))
            {
                string _opponentChoice = OpponentChoice(Randoms());
                string _userChoice = UserChoice()!;

                string result = ScoreGame(_opponentChoice, _userChoice);
                switch (result)
                {
                    case "win":
                        Console.WriteLine("You win!");
                        userScore += 1;
                        break;
                    case "tie":
                        Console.WriteLine("We tied...");
                        break;
                    case "lose":
                        Console.WriteLine("You lose!");
                        opponentScore += 1;
                        break;

                }
            }
            if (userScore > opponentScore)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("I won!");
            }
        }
        /// <summary>
        /// A dictionary containing the results of a RPS match
        /// </summary>
        private static readonly IDictionary<string, Dictionary<string, string>> _scoreMatrix
            = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "rock",
                new Dictionary<string, string>
                {
                    { "rock", "tie" },
                    { "paper", "lose" },
                    { "scissors", "win" }
                }
            },
            {
                "paper",
                new Dictionary<string, string>
                {
                    { "rock", "win" },
                    { "paper", "tie" },
                    { "scissors", "lose" }
                }
            },
            {
                "scissors",
                new Dictionary<string, string>
                {
                    { "rock", "lose" },
                    { "paper", "win" },
                    { "scissors", "tie" }
                }
            }
        };
    }
}
