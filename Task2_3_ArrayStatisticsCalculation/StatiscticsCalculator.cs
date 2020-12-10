using System;

namespace Task2_3_ArrayStatisticsCalculation
{
    public class StatiscticsCalculator
    {
        public int GetMinimum(int[] array)
        {
            int min = int.MaxValue;
            foreach (var element in array)
            {
                if (element < min)
                {
                    min = element;
                }
            }
            return min;
        }

        public int GetMaximum(int[] array)
        {
            int max = int.MinValue;
            foreach (var element in array)
            {
                if (element > max)
                {
                    max = element;
                }
            }
            return max;
        }

        public int GetSum(int[] array)
        {
            int sum = 0;
            foreach (var element in array)
            {
                sum += element;
            }

            return sum;
        }

        public double GetAverage(int[] array)
        {
            return (double) GetSum(array) / array.Length;
        }

        public double GetStandardDeviation(int[] array)
        {
            double average = GetAverage(array);
            double dispersionNumerator = 0;
            foreach (var element in array)
            {
                dispersionNumerator += Math.Pow(element - average, 2);
            }

            double dispersion = dispersionNumerator / array.Length;
            double standardDevitation = Math.Sqrt(dispersion);
            return standardDevitation;
        }

        public int[] Sort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
            return array;
        }

        private void Merge(int[] array, int leftBorder, int middle, int rightBorder)
        {
            int subArr1Size = middle - leftBorder + 1; // [leftBorder; middle]
            int subArr2Size = rightBorder - middle; // (middle; rightBorder]
            int[] subArr1 = new int[subArr1Size];
            int[] subArr2 = new int[subArr2Size];

            int i, j;
            for (i = 0; i < subArr1Size; i++)
            {
                subArr1[i] = array[leftBorder + i];
            }
            
            for (j = 0; j < subArr2Size; j++)
            {
                subArr2[j] = array[middle + 1 + j];
            }

            int k = leftBorder;
            i = 0;
            j = 0;
            
            while (i < subArr1Size && j < subArr2Size) 
            {
                if (subArr1[i] < subArr2[j])
                {
                    array[k] = subArr1[i];
                    i++;
                }
                else
                {
                    array[k] = subArr2[j];
                    j++;
                }
                k++;
            }

            while (i < subArr1Size) // add to the array elements from subarray, because subarray sizes not always equal
            {
                array[k] = subArr1[i];
                i++;
                k++;
            }
            
            while (j < subArr2Size) // add to the array elements from subarray, because subarray sizes not always equal
            {
                array[k] = subArr2[j];
                j++;
                k++;
            }
            
        }
        private void MergeSort(int[] array, int leftBorder, int rightBorder)
        {
            if (leftBorder < rightBorder)
            {
                int middle = (leftBorder + rightBorder) / 2;
                MergeSort(array, leftBorder, middle);
                MergeSort(array, middle + 1, rightBorder);
                Merge(array, leftBorder, middle, rightBorder);
            }
        }
    }
}