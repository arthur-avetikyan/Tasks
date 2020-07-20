using Operation;

namespace OperationManager.IOperationServices
{
    public interface IOperationPerformer
    {
        double PerformOperation(params double[] numbers);

        void SetOperation(IOperation operation);
    }
}