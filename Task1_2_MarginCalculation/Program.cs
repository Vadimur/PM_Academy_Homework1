using System;

namespace Task1_2_MarginCalculation
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "1.2 Program calculates the probability of event outcomes and the bookmaker's margin based on the coefficients.";

        static void Main(string[] args)
        {
            Console.WriteLine(author);
            Console.WriteLine(programDescription);
            
            Console.WriteLine("Please, enter name of the first participant");
            string firstParticipant = Console.ReadLine();
            Console.WriteLine("Please, enter name of the second participant");
            string secondParticipant = Console.ReadLine();
            
            Console.WriteLine("Please, enter the coefficients");
            Console.Write($"{firstParticipant} win: ");
            double firstParticipantWinCoefficient = double.Parse(Console.ReadLine());
            Console.Write("Draw: ");
            double drawCoefficient = double.Parse(Console.ReadLine());
            Console.Write($"{secondParticipant} win: ");
            double secondParticipantWinCoefficient = double.Parse(Console.ReadLine());

            Coefficients coefficients = new Coefficients(firstParticipantWinCoefficient, drawCoefficient, secondParticipantWinCoefficient);
            MarginCalculator calculator = new MarginCalculator();
            Probabilities probabilities = calculator.CalculateProbabilitiesFromCoefficients(coefficients);

            Console.WriteLine("\nProbabilities of the events without margin");
            Console.WriteLine($"{firstParticipant} win: {probabilities.FirstParticipantWinProbability}");
            Console.WriteLine($"Draw: {probabilities.DrawProbability}");
            Console.WriteLine($"{secondParticipant} win: {probabilities.SecondParticipantWinProbability}");
            Console.WriteLine($"Bookmaker's margin: {probabilities.Margin}");
   
        }
    }
}