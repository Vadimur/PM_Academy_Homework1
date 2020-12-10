using System;

namespace Task1_3_SumOfSeriesCalculation
{
    public class SeriesCalculator
    {
        public const double EPSILON = (double)1/2001; // day of birth
        public double CalculateSeries()
        {
            int i = 0;
            double seriesElement = CountSeriesElement(1); // maybe first element is already < EPSILON
            double sum = 0;
            while (seriesElement >= EPSILON)
            {
                i++;
                seriesElement = CountSeriesElement(i);
                sum += seriesElement;
            }

            sum -= seriesElement; // last seriesElement is < EPSILON, so we don't need to count it
            i--; // number of series elements added
            return sum; // sum = sum of all elements of the row which are >= EPSILON
        }

        private double CountSeriesElement(int i)
        {
            return (double) 1 / (i * (i + 1));
        }
    }
}