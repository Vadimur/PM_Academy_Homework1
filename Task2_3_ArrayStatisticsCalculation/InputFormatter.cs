using System;

namespace Task2_3_ArrayStatisticsCalculation
{
    public class InputFormatter
    {
        public int[] FormatInputCommandLineMode(string[] input)
        {
            int[] numbersArray = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if(int.TryParse(input[i], out numbersArray[i]) == false)
                    throw new ArgumentException($"Invalid argument: {input[i]}");
            }
            return numbersArray;
        }
        
        public int[] FormatInputDialogMode(string rawInput)
        {
            string[] inputElements = rawInput.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            return FormatInputCommandLineMode(inputElements);
        }
    }
}