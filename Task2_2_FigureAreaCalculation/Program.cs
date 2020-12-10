using System;

namespace Task2_2_FigureAreaCalculation
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "2.2 Program calculates the area of a figure with given parameters";

        static int Main(string[] args)
        {
            return args?.Length > 0 ? EnterCommandLineMode(args) : EnterDialogMode();
        }

        private static int EnterCommandLineMode(string[] args)
        {
            FigureAreaCalculator areaCalculator = new FigureAreaCalculator();
            InputValidator inputValidator = new InputValidator();
            
            bool isFigure = Enum.TryParse<Figure>(args[0], true, out Figure figure);
            if (isFigure == false || figure == Figure.Undefined) return -1;
            
            
            string[] rawParameters = new string[args.Length - 1];
            Array.Copy(args, 1, rawParameters, 0, args.Length - 1);
                
            double[] inputParameters;
            double figureArea;
                
            try
            {
                inputParameters = inputValidator.ValidateInput(rawParameters);
            }
            catch (ArgumentException exception)
            {
                return -1;
            }

            try
            {
                figureArea = areaCalculator.CalculateArea(figure, inputParameters);
            }
            catch (ArgumentException exception)
            {
                return -1;
            }
            Console.WriteLine(figureArea);
            return 0;
        }

        private static int EnterDialogMode()
        {
            string programRules = "\nRules: to calculate the area of a figure type it's name and parameters.\n" +
                               "For example\n" +
                               "if you type 'circle 10' program will calculate area of the circle with radius = 10";
            string availableCommands = "\nAvailable commands:\n" +
                                       "circle *radius*\n" +
                                       "triangle *1 side length* *2 side length* *3 side length*\n" +
                                       "rectangle *length* *width*\n" +
                                       "square *any side length*\n" +
                                       "Replace *parameter name* with your values\n"+
                                       "Type 'quit' to quit the program";
            Console.WriteLine(author);
            Console.WriteLine(programDescription);
            Console.WriteLine(programRules);
            Console.WriteLine(availableCommands);

            FigureAreaCalculator areaCalculator = new FigureAreaCalculator();
            InputValidator inputValidator = new InputValidator();
            
            Console.Write("\nYour command: ");
            string userInput = Console.ReadLine();
            while (string.IsNullOrEmpty(userInput) == false && userInput.ToLower() != "quit")
            {
                string[] args = userInput.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                bool isFigure = Enum.TryParse<Figure>(args[0], true, out Figure figure);
                if (isFigure && figure != Figure.Undefined)
                {
                    string[] rawParameters = new string[args.Length - 1];
                    Array.Copy(args, 1, rawParameters, 0, args.Length - 1);
                
                    double[] inputParameters = null;
                    double figureArea;
                
                    try
                    {
                        inputParameters = inputValidator.ValidateInput(rawParameters);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }

                    
                    if (inputParameters != null)
                    {
                        try
                        {
                            figureArea = areaCalculator.CalculateArea(figure, inputParameters);
                            Console.WriteLine($"S={figureArea}");
                        }
                        catch (ArgumentException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                            
                    }
                        
                }
                else
                {
                    Console.WriteLine("You entered invalid figure. Try again");
                }
                Console.Write("\nYour command: ");
                userInput = Console.ReadLine();
            }
            
            
            return 0;
        }
    }
}