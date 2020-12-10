namespace Task3_1_Calculator
{
    public class OperandInformation
    {
        public double Number { get; }
        public int EndsAt { get; }

        public OperandInformation(double number, int endsAt)
        {
            Number = number;
            EndsAt = endsAt;
        }
    }
}