namespace Operation
{
    public interface IOperation
    {
        string OperationName { get; }

        string OperationRepresentation { get; }

        double Operate(params double[] numbers);
    }
}
