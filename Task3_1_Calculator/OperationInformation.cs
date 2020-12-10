namespace Task3_1_Calculator
{
    public class OperationInformation
    {
        public Operation Operation { get; }
        public int EndsAt { get; }

        public OperationInformation(Operation operation, int endsAt)
        {
            Operation = operation;
            EndsAt = endsAt;
        }
    }
}