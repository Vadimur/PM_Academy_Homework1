using System;
using System.Collections.Generic;

namespace Task2_2_FigureAreaCalculation
{
    public class InputValidator
    {
        public double[] ValidateInput(string[] args)
        {
            double[] arguments = new double[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                bool isParsable = double.TryParse(args[i], result: out double parameter);
                if (isParsable == false)
                {
                    throw new ArgumentException($"You entered parameter of the wrong type");
                }

                arguments[i] = parameter;
            }

            return arguments;
        }
    }
}