using System;

namespace Task2_2_FigureAreaCalculation
{
    public class FigureAreaCalculator
    {
        public double CalculateArea(Figure figure, double[] args)
        {
            switch (figure)
            {
                case Figure.Circle:
                {
                    if(args.Length != 1)
                        throw new ArgumentException($"1 parameter needed but {args.Length} was passed");
                    return CalculateCircleArea(args[0]);
                }
                case Figure.Triangle:
                {
                    if(args.Length != 3)
                        throw new ArgumentException($"3 parameters needed but {args.Length} was passed");
                    return CalculateTriangleArea(args[0], args[1], args[2]);
                }
                case Figure.Rectangle:
                {
                    if (args.Length != 2)
                        throw new ArgumentException($"2 parameters needed but {args.Length} was passed");
                    return CalculateRectangleArea(args[0], args[1]);
                }
                case Figure.Square:
                {
                    if (args.Length != 1)
                        throw new ArgumentException($"1 parameter needed but {args.Length} was passed");
                    return CalculateSquareArea(args[0]);
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(figure), figure, null);
            }
        }

        private double CalculateCircleArea(double radius)
        {
            if(radius < 0 )
                throw new ArgumentException($"You entered invalid value for {nameof(radius)} parameter");
            
            return Math.PI * Math.Pow(radius, 2);
        }

        private double CalculateTriangleArea(double side1, double side2, double side3)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                throw new ArgumentException($"You entered non-positive value for side length parameter");
            
            if (side1 + side2 <= side3 ||
                side1 + side3 <= side2 || 
                side2 + side3 <= side1)
            {
                throw new ArgumentException($"You entered invalid value for side length parameters. Impossible triangle");
            }
            double part = (side1 + side2 + side3) / 2;
            double area = Math.Sqrt(part * (part - side1) * (part - side2) * (part - side3));
            return area;
        }

        private double CalculateRectangleArea(double length, double width)
        {
            return length * width;
        }
        
        private double CalculateSquareArea(double sideSize)
        {
            return sideSize * sideSize;
        }
    }
}