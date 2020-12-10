using System;

namespace Task1_1_ExpressionCalculation
{
    class Program
    {
        static string author = "Made by Mulish Vadym";
        static string programDescription = "1.1 Program calculates expression with user's parameter";
        static string calculationExpression = "y = (e^a + 4*lg(c)) / sqrt(b) * abs(arctg(d)) + 5 / sin(a)";

        static void Main(string[] args)
        {
            Console.WriteLine(author);
            Console.WriteLine(programDescription);
            Console.WriteLine(calculationExpression);
            Console.WriteLine($"b = {CalculatingModule.B}; c = {CalculatingModule.C}; d = {CalculatingModule.D};");
            Console.WriteLine("Enter parameter 'a' for the expression");
             double parameter = double.Parse(Console.ReadLine());
             
             CalculatingModule calculatingModule = new CalculatingModule();
            try
            {
                double calculationResult = calculatingModule.CalculateExpression(parameter);
                Console.WriteLine($"Result: {calculationResult}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"You entered invalid parameter.\n{ex.Message}");
            }

        }
    }
}