using System;

namespace Task2_1_Rock_Paper_Scissors_Game
{
    public class GameEngine
    {
        public Figure GenerateComputersFigure()
        {
            Random random = new Random();
            var values = Enum.GetValues(typeof(Figure));
            Figure randomFigure = (Figure)values.GetValue(random.Next(1, values.Length));
            return randomFigure;
        }

        public Winner DecideWinner(Figure usersFigure, Figure computersFigure)
        {
            if (usersFigure == computersFigure)
            {
                return Winner.Draw;
            }

            switch (usersFigure)
            {
                case Figure.Rock when computersFigure == Figure.Scissors:
                case Figure.Scissors when computersFigure == Figure.Paper:
                case Figure.Paper when computersFigure == Figure.Rock:
                    return Winner.User;
                default:
                    return Winner.Computer;
            }

        }
    }
}