using System;
using FMinus.ConsoleGames.RockPaperScissors;
using FMinus.ConsoleGames.Scrabble;

namespace FMinus.ConsoleGames.PlayGames
{
    class Program
    {
        static void PlayScrabble()
        {
            while (true)
            {
                Console.WriteLine("Enter a word:");
                var inputString = Console.ReadLine();

                var score = ScrabbleScore.GetScore(inputString);

                Console.WriteLine($"Your score: {score}");
            }
        }

        static void PlayRockPaperScissors()
        {
            while (true)
            {
                RPS.PlayGame();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1: ScrabbleScore");
            Console.WriteLine("2: RockPaperScissors");
            Console.WriteLine("Enter your choice.");
            int choice = Convert.ToInt16(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    PlayScrabble();
                    break;
                case 2:
                    PlayRockPaperScissors();
                    break;
            }
        }
    }
}