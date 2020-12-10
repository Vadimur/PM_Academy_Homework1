using System;

namespace Task3_1_Calculator
{
    public class Calculator
    {
        public double Add(double a, double b) => checked(a + b);
        public double Subtract(double a, double b) => checked(a - b);
        public double Multiply(double a, double b) => checked(a * b);
        public double Divide(double a, double b) => checked(a / b);
        public int GetDivisionRemainder(double a, double b) => (int)(a % b);
        public double Pow(double a, double b) => Math.Pow(a, b);
        public int And(int a, int b) => checked(a & b);
        public int Or(int a, int b) => checked(a | b);
        public int Not(int a) => checked(~a);
        public int Xor(int a, int b) => checked(a ^ b);
        public int Factorial(int a)
        {
            if (a == 0)
            {
                return 1;
            }
            checked
            {
                return a * Factorial(a - 1);
            }
        }

    }
}