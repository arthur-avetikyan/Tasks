using Operation;

namespace Calculator.IOperationServices
{
    public interface IOperationPerformerService
    {
        double PerformOperation(params double[] numbers);

        void SetOperation(IOperation operation);
    }
}