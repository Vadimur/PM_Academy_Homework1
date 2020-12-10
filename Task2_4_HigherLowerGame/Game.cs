using System;

namespace Task2_4_HigherLowerGame
{
    public class Game
    {
        private readonly int _secretNumber;
        public readonly int LeftBorder;
        public readonly int RightBorder;
        public int Attempts { get; private set; }

        public Game(int leftBorder, int rightBorder)
        {
            this.LeftBorder = leftBorder;
            this.RightBorder = rightBorder;
            this._secretNumber = new Random().Next(this.LeftBorder, this.RightBorder + 1);
        }

        public MoveResult MakeMove(int guessNumber)
        {
            Attempts++;
            if (guessNumber < _secretNumber)
                return MoveResult.Higher;
            else if (guessNumber > _secretNumber)
                return MoveResult.Lower;
            else
                return MoveResult.Win;

        }

        public int GetGameResult(bool didUserGaveUp)
        {
            if (didUserGaveUp)
            {
                return 0;
            }
            int amountOfNumbersInRange = RightBorder - LeftBorder + 1;
            int powOf2 = (int)Math.Round(Math.Log2(amountOfNumbersInRange), 0);

            if (powOf2 == 0)
                return 100;
            int points = 100 * (powOf2 - (Attempts - 1)) / powOf2;
            if (points < 1)
                points = 1;
            return points;
        }
        
    }
}