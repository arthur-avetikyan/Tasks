namespace Operation
{
    public interface IOperation
    {
        string OperationName { get; }

        string OperationSymbol { get; }

        //double Operate(double numberFirst, double numberSecond);
        //double Operate(double numberFirst, double numberSecond, double numberThird);

        double Operate(params double[] numbers);
    }
}
