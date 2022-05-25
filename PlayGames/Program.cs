using System;
using FMinus.ConsoleGames.RockPaperScissors;
using FMinus.ConsoleGames.Scrabble;

namespace FMinus.ConsoleGames.PlayGames
{
    class Program
    {
        /// <summary>
        /// Main program method
        /// </summary>
        static void Main()
        {
            Console.WriteLine("1: ScrabbleScore");
            Console.WriteLine("2: RockPaperScissors");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt16(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GetScrabbleScore();
                    break;
                case 2:
                    PlayRockPaperScissors();
                    break;
            }
        }
        /// <summary>
        /// Implements Scrabble.ScrabbleScore
        /// </summary>
        static void GetScrabbleScore()
        {
            while (true)
            {
                Console.Write("Enter a word: ");

                var inputString = Console.ReadLine();

                var score = ScrabbleScore.GetScore(inputString);

                Console.WriteLine($"Your score: {score}");
            }
        }
        /// <summary>
        /// Implements RockPaperScissors.RPS
        /// </summary>
        static void PlayRockPaperScissors()
        {
            while (true)
            {
                RPS.PlayGame();
            }
        }
    }
}