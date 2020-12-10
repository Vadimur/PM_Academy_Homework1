using System;

namespace Task1_2_MarginCalculation
{
    public class MarginCalculator
    {
        public Probabilities CalculateProbabilitiesFromCoefficients(Coefficients coefficients)
        {
            double marginPercent = Math.Round(CalculateMargin(coefficients), 1);
            
            double firstWinProbability = Math.Round(1 / coefficients.FirstParticipantWinCoefficient * 100 - marginPercent / 3, 1);
            double secondWinProbability = Math.Round(1 / coefficients.SecondParticipantWinCoefficient * 100 - marginPercent / 3, 1);
            double drawProbability = Math.Round(1 / coefficients.DrawCoefficient * 100 - marginPercent / 3, 1);
            
            double final = firstWinProbability + secondWinProbability + drawProbability;
            // final not always == 100; IN MY OPINION, it is because when bookmaker calculates coefficients
            // he shares margin between coefficients according to their probabilities
            // but when we make reverse action,
            // we substract margin from probabilities (with margin included) as it is was shared equally between all coefficients 
            // as said in the task 1.2 
            return new Probabilities(firstWinProbability,drawProbability,secondWinProbability,marginPercent);
        }

        private double CalculateMargin(Coefficients coefficients)
        {
            double denumerator = 1 / coefficients.FirstParticipantWinCoefficient +
                                 1 / coefficients.SecondParticipantWinCoefficient + 1 / coefficients.DrawCoefficient;
            double margin = ( 1 - 1 / denumerator) * 100;
            return margin;
        }
    }
}