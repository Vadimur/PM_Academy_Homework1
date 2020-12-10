using System;
using System.Data;
using System.Linq;

namespace Task3_1_Calculator
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "3.1 Calculator";

        private static Calculator _calculator;
        private static InputParser _parser;
        static int Main(string[] args)
        {
            _calculator = new Calculator();
            _parser = new InputParser();
            if (args.Length > 0)
            {
                return CommandLineMode(args);
            }

            try
            {
                return DialogMode();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled exception occured");
                throw;
            }
            
        }

        private static int CommandLineMode(string[] args)
        {
            var userInput = string.Concat(args);
            var splittedInput = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            userInput = string.Concat(splittedInput);
            string formattedUserInput = FormatInput(userInput);

                if (formattedUserInput.StartsWith('!'))
                {
                    try
                    {
                        int result = PerformUnaryOperation(formattedUserInput, Operation.Not);
                        Console.WriteLine(result);
                    }
                    catch (Exception exception)
                    {
                        if (exception is ArgumentException || exception is OverflowException)
                            return -1;
                        throw;
                    }
                }
                else if (formattedUserInput.EndsWith('!'))
                {
                    try
                    {
                        int result = PerformUnaryOperation(formattedUserInput, Operation.Factorial);
                        Console.WriteLine(result);
                    }
                    catch (Exception exception)
                    {
                        if (exception is ArgumentException || exception is OverflowException)
                            return -1;
                        throw;
                    }
                }
                else
                {
                    try
                    {
                        var firstOperand = _parser.GetOperandInformation(formattedUserInput, 0);
                        var operationSign = _parser.ParseOperation(formattedUserInput, firstOperand.EndsAt + 1);
                        var secondOperand = _parser.GetOperandInformation(formattedUserInput, operationSign.EndsAt + 1);
                        
                        if (secondOperand.EndsAt != formattedUserInput.Length - 1)
                            return -1;
                        
                        if (Operation.Binary.HasFlag(operationSign.Operation))
                        {
                            if (operationSign.Operation == Operation.Divide && secondOperand.Number == 0)
                                return -1;
                            double result = PerformBinaryOperation(operationSign.Operation, firstOperand.Number,
                                secondOperand.Number);

                            Console.WriteLine(result);
                        }
                        else if (Operation.BinaryBit.HasFlag(operationSign.Operation))
                        {
                            try
                            {
                                int result = PerformBinaryBitOperation(operationSign.Operation, firstOperand, secondOperand);
                                Console.WriteLine(result); 
                            }
                            catch (Exception exception)
                            {
                                if (exception is ArgumentException || exception is OverflowException)
                                    return -1;
                                throw;
                            }
                        }

                    }
                    catch (Exception exception)
                    {
                        if (exception is ArgumentException || exception is OverflowException)
                            return -1;
                        throw;
                    }
                }
                return 0;
        }

        private static string FormatInput(string input)
        {
            var splittedInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var formattedUserInput = string.Concat(splittedInput);
            return formattedUserInput;
        }
        private static int DialogMode()
        {

            string programRules = "\nRules:\nEnter mathematical expression which consists of:\n" +
                               "1. Any two operands and one of the following operation signs between them (+, -, *, x, /, \\, %, pow)\n" +
                               "2. Two positive integers and one of the following operation signs between them (&, |, ^)\n" +
                               "3. Any positive integer and ! before it to perform bit NOT\n" +
                               "4. Any positive integer and ! after it to calculate factorial\n" +
                               "Type 'quit' to exit the program\n";
            string apologies = "sorry for this AWFUL code :(\n";
            
            Console.WriteLine(author);
            Console.WriteLine(programDescription);
            Console.WriteLine(apologies);
            Console.WriteLine(programRules);

            Console.WriteLine("Enter your command: ");
            string userInput = Console.ReadLine()?.Trim();
            while (string.IsNullOrEmpty(userInput) == false && userInput.ToLower() != "quit")
            {
                
                string formattedUserInput = FormatInput(userInput);

                if (formattedUserInput.StartsWith('!'))
                {
                    try
                    {
                        int result = PerformUnaryOperation(formattedUserInput, Operation.Not);
                        Console.WriteLine($"{formattedUserInput} = {result}");
                    }
                    catch (Exception exception)
                    {
                        if (exception is ArgumentException || exception is OverflowException)
                            Console.WriteLine(exception.Message);
                    }
                }
                else if (formattedUserInput.EndsWith('!'))
                {
                    try
                    {
                        int result = PerformUnaryOperation(formattedUserInput, Operation.Factorial);
                        Console.WriteLine($"{formattedUserInput} = {result}");
                    }
                    catch (Exception exception)
                    {
                        if (exception is ArgumentException || exception is OverflowException)
                            Console.WriteLine(exception.Message);
                    }
                }
                else
                {
                    try
                    {
                        var firstOperand = _parser.GetOperandInformation(formattedUserInput, 0);
                        var operationSign = _parser.ParseOperation(formattedUserInput, firstOperand.EndsAt + 1);
                        var secondOperand = _parser.GetOperandInformation(formattedUserInput, operationSign.EndsAt + 1);
                        
                        if (secondOperand.EndsAt != formattedUserInput.Length - 1)
                            throw new ArgumentException("Too many arguments");
                        
                        if (Operation.Binary.HasFlag(operationSign.Operation))
                        {
                            if (operationSign.Operation == Operation.Divide && secondOperand.Number == 0)
                                throw new ArgumentException("Cannot divide by zero");

                            double result = PerformBinaryOperation(operationSign.Operation, firstOperand.Number,
                                secondOperand.Number);
                        
                            Console.WriteLine($"{formattedUserInput} = {result}");
                        }
                        else if (Operation.BinaryBit.HasFlag(operationSign.Operation))
                        {
                            try
                            {
                                int result = PerformBinaryBitOperation(operationSign.Operation, firstOperand, secondOperand);
                                Console.WriteLine($"{formattedUserInput} = {result}"); 
                            }
                            catch (Exception exception)
                            {
                                if (exception is ArgumentException || exception is OverflowException)
                                    Console.WriteLine(exception.Message);
                            }
                        }

                    }
                    catch (Exception exception)
                    {
                        if (exception is ArgumentException || exception is OverflowException)
                            Console.WriteLine(exception.Message);
                    }
        
                }
                Console.WriteLine("Enter your command: ");
                userInput = Console.ReadLine()?.Trim();
            }
            return 0;
        }

        private static double PerformBinaryOperation(Operation operation, double operand1, double operand2)
        {
            switch (operation)
            {
                case Operation.Add:
                   return _calculator.Add(operand1, operand2);
                case Operation.Subtract:
                    return  _calculator.Subtract(operand1, operand2);
                case Operation.Multiply:
                    return _calculator.Multiply(operand1, operand2);
                case Operation.Divide:
                    return _calculator.Divide(operand1, operand2);
                case Operation.GetDivisionRemainder:
                    return _calculator.GetDivisionRemainder(operand1, operand2);
                case Operation.Pow:
                    return _calculator.Pow(operand1, operand2);
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }
        
        private static int PerformBinaryBitOperation(Operation operation, OperandInformation firstOperand, OperandInformation secondOperand)
        {
            if(firstOperand.Number - Math.Floor(firstOperand.Number) != 0 || 
               secondOperand.Number - Math.Floor(secondOperand.Number) != 0)
                throw new ArgumentException("Only integers allowed");

            int operand1 = Convert.ToInt32(firstOperand.Number);
            int operand2 = Convert.ToInt32(secondOperand.Number);
            if (operand1 < 0 || operand2 < 0)
            {
                throw new ArgumentException($"Only positive integers allowed for " +
                                            $"{operation} operation");
            }
            switch (operation)
            {
                case Operation.And:
                    return _calculator.And(operand1, operand2);
                case Operation.Or:
                    return  _calculator.Or(operand1, operand2);
                case Operation.Xor:
                    return _calculator.Xor(operand1, operand2);
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }
        
        private static int PerformUnaryOperation(string formattedUserInput, Operation operation)
        {
            int startIndex = 0;
            if (operation == Operation.Not)
                startIndex = 1;
            OperandInformation operandInfo = _parser.GetOperandInformation(formattedUserInput, startIndex);

            int result;
  
            int number = Convert.ToInt32(operandInfo.Number);
            if (number < 0)
                throw new ArgumentException($"Number must be >= 0, but you entered {number}");
            
            switch (operation)
            {
                case Operation.Not:
                    result = _calculator.Not(number);
                    break;
                case Operation.Factorial:
                    result = _calculator.Factorial(number);
                    break;
                default:
                    throw new ArgumentException("Unknown operation");
            }
            
            return result;
        }
        
    }
}