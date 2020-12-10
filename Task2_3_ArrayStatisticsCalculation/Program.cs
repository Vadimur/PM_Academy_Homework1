using System;

namespace Task2_3_ArrayStatisticsCalculation
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "2.3 Program calculates the statistics for given array";

        static int Main(string[] args)
        {
            return args?.Length > 0 ? CommandLineMode(args) : DialogMode();
        }

        private static int CommandLineMode(string[] args)
        {
            InputFormatter inputFormatter = new InputFormatter();
            StatiscticsCalculator statiscticsCalculator = new StatiscticsCalculator();
            int[] numbers;
            try
            {
                numbers = inputFormatter.FormatInputCommandLineMode(args);
            }
            catch (ArgumentException exception)
            {
                return -1;
            }

            var min = statiscticsCalculator.GetMinimum(numbers);
            var max = statiscticsCalculator.GetMaximum(numbers);
            var sum = statiscticsCalculator.GetSum(numbers);
            var average = statiscticsCalculator.GetAverage(numbers);
            var standardDeviation = statiscticsCalculator.GetStandardDeviation(numbers);
            var sortedArray = statiscticsCalculator.Sort(numbers);
            var sortedArrayForView = GetArrayForView(sortedArray);

            Console.Write($"{min} {max} {sum} {average} {standardDeviation} {sortedArrayForView}");

            return 0;
        }
        private static int DialogMode()
        {
            var programRules = "\nRules: to calculate statistics of the array:\n" +
                               "1. Enter number of elements in array\n" +
                               "2. Enter each element in one line and press Enter.\n";
            Console.WriteLine(author);
            Console.WriteLine(programDescription);
            Console.WriteLine(programRules);
            
            InputFormatter inputFormatter = new InputFormatter();
            StatiscticsCalculator statiscticsCalculator = new StatiscticsCalculator();
            bool continueAskingInput = true;
            do
            {
                Console.WriteLine("\nEnter number of elements in array");
                string numberOfElementsInput = Console.ReadLine();
                var isInt = int.TryParse(numberOfElementsInput, out int numberOfElements);
                if (isInt == false || numberOfElements < 1)
                    continue;
                Console.WriteLine("Enter elements of the array");
                string rawInput = Console.ReadLine();
                int[] numbersArray = null;
                try
                {
                    numbersArray = inputFormatter.FormatInputDialogMode(rawInput);
                    if (numbersArray.Length != numberOfElements)
                    {
                        Console.WriteLine("Number of elements not equal to real amount of numbers in given array");
                        continue;
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                if (numbersArray != null)
                {
                    var min = statiscticsCalculator.GetMinimum(numbersArray);
                    var max = statiscticsCalculator.GetMaximum(numbersArray);
                    var sum = statiscticsCalculator.GetSum(numbersArray);
                    var average = statiscticsCalculator.GetAverage(numbersArray);
                    var standardDeviation = statiscticsCalculator.GetStandardDeviation(numbersArray);

                    var sortedArray = statiscticsCalculator.Sort(numbersArray);
                    var sortedArrayForView = GetArrayForView(sortedArray);

                    Console.WriteLine("\nStatistic results:");
                    Console.WriteLine($"Minimum element: {min}");
                    Console.WriteLine($"Maximum element: {max}");
                    Console.WriteLine($"Sum of array elements: {sum}");
                    Console.WriteLine($"Average: {average}");
                    Console.WriteLine($"Standard deviation: {standardDeviation}");
                    Console.WriteLine($"Sorted array: {sortedArrayForView}");
                    continueAskingInput = false;
                }
            } while (continueAskingInput);

            return 0;
        }

        private static string GetArrayForView(int[] array)
        {
            string arrayForView = "";
            foreach (var number in array)
            {
                arrayForView += number + " ";
            }

            return arrayForView;
        }
    }
}