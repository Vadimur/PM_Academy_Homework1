using System;

namespace Task1_3_SumOfSeriesCalculation
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "1.3 Program calculates the sum of a given series.";
        private static string seriesForCalculation = "sigma( 1/(i*(i+1)) )";

        static void Main(string[] args)
        {
            Console.WriteLine(author);
            Console.WriteLine(programDescription);
            Console.WriteLine(seriesForCalculation);
            Console.WriteLine($"epsilon = {SeriesCalculator.EPSILON}");
            SeriesCalculator calculator = new SeriesCalculator();
            double result = calculator.CalculateSeries();
            Console.WriteLine($"Sum of series elements >= epsilon = {result}");
        }
    }
}