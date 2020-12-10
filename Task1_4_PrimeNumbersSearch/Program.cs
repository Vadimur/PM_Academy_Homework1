using System;
using System.Collections.Generic;

namespace Task1_4_PrimeNumbersSearch
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "1.3 Program finds prime numbers in given range";
        static void Main(string[] args)
        {
            Console.WriteLine(author);
            Console.WriteLine(programDescription);
            Console.Write("Start of range: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("End of range: ");
            int finish = int.Parse(Console.ReadLine());

            PrimeNumbersSearchModule primeNumbersSearchModule = new PrimeNumbersSearchModule();
            List<int> primeNumbers = primeNumbersSearchModule.FindPrimeNumbers(start, finish);
            Console.Write($"Prime numbers from range [{start}; {finish}]:");
            foreach (var primeNumber in primeNumbers)
            {
                Console.Write($" {primeNumber}");
            }
        }
    }
}