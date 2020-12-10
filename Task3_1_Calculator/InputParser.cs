using System;

namespace Task3_1_Calculator
{
    public class InputParser
    {
        public OperandInformation GetOperandInformation(string input, int startIndexOfSearch)
        {
            string textNumber = input.Substring(startIndexOfSearch, input.Length - startIndexOfSearch);
            
            int endIndexOfNumber = FindNumber(textNumber);
 
            textNumber = input.Substring(startIndexOfSearch, endIndexOfNumber );
            
            bool isNumber = double.TryParse(textNumber, out double number);
            return isNumber
                ? new OperandInformation(number, startIndexOfSearch + textNumber.Length - 1)
                : throw new ArgumentException("Couldn't parse operand");
        }

        private int FindNumber(string input)
        {
            int index;
            int start = input.StartsWith('-') ? 1 : 0;
            for (index = start; index < input.Length; index++)
            {
                if (char.IsDigit(input[index]) == false && input[index] != ',')
                {
                    return index;
                }
            }
            return index;
        }
        public OperationInformation ParseOperation(string userInput, int startIndexOfPossibleOperationSign)
        {
            if (userInput.Length >= startIndexOfPossibleOperationSign + "pow".Length - 1)
            {
                var textOperation = userInput.Substring(startIndexOfPossibleOperationSign, "pow".Length - 1);

                if (textOperation.ToLower().StartsWith("pow"))
                    return new OperationInformation(Operation.Pow, startIndexOfPossibleOperationSign + "pow".Length - 1);
            }
            if (userInput.Length <= startIndexOfPossibleOperationSign)
                throw new ArgumentException("Operation not found");
            
            char operationChar = userInput[startIndexOfPossibleOperationSign ];
            
            Operation operation;
            switch (operationChar)
            {
                case '+':
                    operation = Operation.Add;
                    break;
                case '-':
                    operation = Operation.Subtract;
                    break;
                case '*':
                case 'x':
                    operation = Operation.Multiply;
                    break;
                case '/':
                case '\\':
                    operation = Operation.Divide;
                    break;
                case '%':
                    operation = Operation.GetDivisionRemainder;
                    break;
                case '&':
                    operation = Operation.And;
                    break;
                case '|': 
                    operation = Operation.Or;
                    break;
                case '^':
                    operation = Operation.Xor;
                    break;
                default:
                    throw new ArgumentException("Invalid operation", nameof(operation));
            }
            return new OperationInformation(operation, startIndexOfPossibleOperationSign);
        }
    }
}