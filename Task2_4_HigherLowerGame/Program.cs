using System;
using System.Diagnostics;

namespace Task2_4_HigherLowerGame
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "2.4 The Higher Lower Game";

        static void Main(string[] args)
        {
            string gameRules = "\nRules:\n1. Enter range of numbers\n" +
                                  "2. Try to guess randomized number from given range.\n" +
                                  "type 'quit' to quit the game\n";

            Console.WriteLine(author);
            Console.WriteLine(programDescription);
            Console.WriteLine(gameRules);
            
            bool isLeftBorderCorrect;
            bool isRightBorderCorrect;
            int leftBorder = 0;
            int rightBorder = 0;
            string input;
            do
            {
                Console.Write("Enter left border of the range: ");
                input = Console.ReadLine();
                isLeftBorderCorrect = int.TryParse(input, out leftBorder);
            } while (isLeftBorderCorrect == false || (leftBorder >= 0 && leftBorder <= 1000000) == false);

            do
            {
                Console.Write("Enter right border of the range: ");
                isRightBorderCorrect = int.TryParse(Console.ReadLine(), out rightBorder);
                if (isRightBorderCorrect)
                    isRightBorderCorrect = rightBorder >= leftBorder;
            } while (!isRightBorderCorrect || !(rightBorder >= 0 && rightBorder <= 1000000));
            
            Game game = new Game(leftBorder, rightBorder);
            Console.WriteLine($"Game has started.Try to guess a number within a range [{leftBorder}; {rightBorder}]");
            string userInput;
            int usersNumber;
            bool UserGaveUp = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            do
            {
                Console.Write("Choose the number: ");
                userInput = Console.ReadLine();
                bool isInputValid = int.TryParse(userInput, out usersNumber);
                if (isInputValid && usersNumber >= leftBorder && usersNumber <= rightBorder)
                {
                    var result = game.MakeMove(usersNumber);
                    if (result == MoveResult.Win)
                    {
                        Console.WriteLine("You won!");
                        UserGaveUp = false;
                        break;
                    }
                    Console.WriteLine(result);

                }
                else
                {
                    Console.WriteLine("Invalid number. Try again.\n");
                }

            } while (userInput?.ToLower() != "quit");
            stopwatch.Stop();

            int score = game.GetGameResult(UserGaveUp);

            Console.WriteLine($"Your score: {score}");
            Console.WriteLine($"Attempts was made: {game.Attempts}");
            Console.WriteLine($"Time spent in the game: {stopwatch.Elapsed.Hours}:{stopwatch.Elapsed.Minutes}:{stopwatch.Elapsed.Seconds}");
        }
    }
}