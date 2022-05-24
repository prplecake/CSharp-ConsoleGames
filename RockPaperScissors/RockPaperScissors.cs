using System;
using System.Collections.Generic;
using System.Linq;

namespace FMinus.ConsoleGames.RockPaperScissors
{
    public class RPS
    { 
        private static readonly Random getrandom = new Random();
        public static int Randoms()
        {
            lock (getrandom)
            {
                return getrandom.Next(0, 3);
            }
        }
        public static string OpponentChoice(int seed)
        {
            var what = new Dictionary<int, string>
            {
                { 0, "rock" },
                { 1, "paper" },
                { 2, "scissors" }
            };
            return what[seed];

        }
        public static string UserChoice()
        {
            var _options = new[] { "rock", "paper", "scissors" };
            Console.WriteLine("Make a decision (rock, paper, scissors):");
            var userChoice = Console.ReadLine();
            if (!_options.Contains(userChoice))
            {
                Console.WriteLine("Input not found. You lose.");
                System.Environment.Exit(1);
            }
            return userChoice;
        }
        public static string ScoreGame(string opponentChoice, string userChoice)
        {
            IDictionary<string, Dictionary<string, string>> _matrix = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "rock",
                    new Dictionary<string, string> {
                        { "rock", "tie" },
                        { "paper", "lose" },
                        { "scissors", "win" }
                    }
                },
                {
                    "paper",
                    new Dictionary<string, string> {
                        { "rock", "win" },
                        { "paper", "tie" },
                        { "scissors", "lose" }
                    }
                },
                {
                    "scissors",
                    new Dictionary<string, string> {
                        { "rock", "lose" },
                        { "paper", "win" },
                        { "scissors", "tie" }
                    }
                }
            };
            var result = _matrix[userChoice][opponentChoice];
            return result;
        }
        public static void PlayGame()
        {
            var userScore = 0;
            var opponentScore = 0;
            while ((userScore < 3) && (opponentScore < 3))
            {
                var _opponentChoice = OpponentChoice(Randoms());
                var _userChoice = UserChoice();

                var result = ScoreGame(_opponentChoice, _userChoice);
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
    }
}
