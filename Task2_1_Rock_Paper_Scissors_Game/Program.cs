using System;
using System.Collections.Generic;

namespace Task2_1_Rock_Paper_Scissors_Game
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "2.1 Rock-Paper-Scissors Game";
        
        static void Main(string[] args)
        {
            string gameRules = "\nRules:\nRock beats Scissors; \nScissors beat Paper; \nPaper beats Rock";
            string availableCommands = "To start the game type one of the figures: Rock | Paper | Scissors \n" +
                                       "Or type 'quit' to quit the game";
            Console.WriteLine(author);
            Console.WriteLine(programDescription);
            Console.WriteLine(gameRules);
            Console.WriteLine(availableCommands);
            
            GameEngine gameEngine = new GameEngine();
            List<Game> games = new List<Game>();
            Console.Write("\nYour command: ");
            string userInput = Console.ReadLine();
            while (userInput?.ToLower() != "quit")
            {
                if (Enum.TryParse(userInput, true, out Figure usersFigure))
                {
                    Figure computersFigure = gameEngine.GenerateComputersFigure();
                    Console.WriteLine($"Computer's figure: {computersFigure}");
                    Winner winner = gameEngine.DecideWinner(usersFigure, computersFigure);
                    Console.WriteLine(winner != Winner.Draw ? $"And the winner is... {winner}" : "Draw");
                    games.Add(new Game(usersFigure, computersFigure, winner));
                }
                else
                {
                    Console.WriteLine($"You entered wrong command.\nAvailable commands: {availableCommands}");
                }
                Console.Write("\nYour command: ");
                userInput = Console.ReadLine(); 
            }

            for (int i = 0; i < games.Count; i++)
            {
                Winner winner = games[i].Winner;
                string result = winner != Winner.Draw ? $"{winner} won" : "Draw";
                Console.WriteLine($"Game #{i+1}; Result: {result}");
            }
        }
    }
}