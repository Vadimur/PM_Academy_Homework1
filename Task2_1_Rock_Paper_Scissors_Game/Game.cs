namespace Task2_1_Rock_Paper_Scissors_Game
{
    public class Game
    {
        public readonly Figure UsersFigure;
        public readonly Figure ComputersFigure;
        public readonly Winner Winner;

        public Game(Figure usersFigure, Figure computersFigure, Winner winner)
        {
            UsersFigure = usersFigure;
            ComputersFigure = computersFigure;
            Winner = winner;
        }
    }
}