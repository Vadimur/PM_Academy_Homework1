using System;

namespace Task1_1_ExpressionCalculation
{
    public class CalculatingModule
    {
        public const int B = 2001; // year of birth
        public const int C = 8; // month of birth
        public const int D = 30; // day of birth

        public CalculatingModule()
        {

        }

        public double CalculateExpression(double a)
        {
            double firstNumerator = Math.Pow(Math.E, a) + 4 * Math.Log10(C);
            double firstDenumerator = Math.Sqrt(B);
            double multiplier = Math.Abs(Math.Atan(D));

            double firstSummand = firstNumerator / firstDenumerator * multiplier;

            double sinValue = Math.Round(Math.Sin(a), 15);

            // DivideByZeroException should be checked here
            // It is thrown when there is an attempt to divide an integral or decimal value by zero
            // Then we need to manually check this case
            if (sinValue == 0)
            {
                throw new DivideByZeroException();
            }
            
            double secondSummand = 5 / sinValue;

            double result = firstSummand + secondSummand;
            return result;
        }
    }
}