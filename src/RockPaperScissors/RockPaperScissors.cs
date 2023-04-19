namespace ConsoleGames.RockPaperScissors
{
    /// <summary>
    /// A class implementing the game Rock, Paper, Scissors.
    /// </summary>
    public static class RockPaperScissors
    {
        private static readonly Random GetRandom = new();
        /// <summary>
        /// Implements a psuedo-random number generator.
        /// </summary>
        /// <returns></returns>
        private static int Randoms()
        {
            lock (GetRandom)
            {
                return GetRandom.Next(0, 3);
            }
        }
        /// <summary>
        /// Gets the computer's "random" choice.
        /// </summary>
        /// <param name="seed">A random integer from 0-2</param>
        /// <returns></returns>
        public static string OpponentChoice(int seed)
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
            var options = new[] { "rock", "paper", "scissors" };
            Console.Write("Make a decision (rock, paper, scissors): ");
            string? userChoice = Console.ReadLine();
            if (!options.Contains(userChoice))
            {
                Console.WriteLine("Input not found. You lose.");
                Environment.Exit(1);
            }
            return userChoice!;
        }
        /// <summary>
        /// Returns the score of the RPS match.
        /// </summary>
        /// <param name="opponentChoice">Opponent's choice</param>
        /// <param name="userChoice">User's choice</param>
        /// <returns></returns>
        public static string ScoreGame(string opponentChoice, string userChoice)
            => ScoreMatrix[userChoice][opponentChoice];
        /// <summary>
        /// Main game loop
        /// </summary>
        public static void PlayGame()
        {
            int userScore = 0;
            int opponentScore = 0;
            while ((userScore < 3) && (opponentScore < 3))
            {
                string opponentChoice = OpponentChoice(Randoms());
                string userChoice = UserChoice();

                string result = ScoreGame(opponentChoice, userChoice);
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

            Console.WriteLine(userScore > opponentScore ? "You won!" : "I won!");
        }
        /// <summary>
        /// A dictionary containing the results of a RPS match
        /// </summary>
        private static readonly IDictionary<string, Dictionary<string, string>> ScoreMatrix
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
