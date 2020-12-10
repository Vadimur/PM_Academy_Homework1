namespace Task1_2_MarginCalculation
{
    public class Probabilities
    {
        public readonly double FirstParticipantWinProbability;
        public readonly double DrawProbability;
        public readonly double SecondParticipantWinProbability;
        public readonly double Margin;

        public Probabilities(double firstParticipantWinProbability, double drawProbability, 
                             double secondParticipantWinProbability, double margin)
        {
            FirstParticipantWinProbability = firstParticipantWinProbability;
            DrawProbability = drawProbability;
            SecondParticipantWinProbability = secondParticipantWinProbability;
            Margin = margin;
        }
    }
}