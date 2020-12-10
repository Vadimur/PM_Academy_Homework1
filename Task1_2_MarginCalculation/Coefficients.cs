namespace Task1_2_MarginCalculation
{
    public class Coefficients
    {
        
        public readonly double FirstParticipantWinCoefficient;
        public readonly double DrawCoefficient;
        public readonly double SecondParticipantWinCoefficient;

        public Coefficients(double firstParticipantWinCoefficient, double drawCoefficient, double secondParticipantWinCoefficient)
        {
            FirstParticipantWinCoefficient = firstParticipantWinCoefficient;
            DrawCoefficient = drawCoefficient;
            SecondParticipantWinCoefficient = secondParticipantWinCoefficient;
        }
    }
}