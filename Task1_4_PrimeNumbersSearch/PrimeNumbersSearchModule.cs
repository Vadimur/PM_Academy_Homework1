using System;
using System.Collections.Generic;

namespace Task1_4_PrimeNumbersSearch
{
    public class PrimeNumbersSearchModule
    {
        public List<int> FindPrimeNumbers(int start, int finish)
        {
            List<int> primeNumbers = new List<int>();
            for (int i = start; i <= finish; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if(isPrime)
                    primeNumbers.Add(i);
            }

            return primeNumbers;
        }
    }
}