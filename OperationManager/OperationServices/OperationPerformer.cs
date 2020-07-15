using Operation;
using OperationManager.IOperationServices;

namespace OperationManager.OperationServices
{
    public class OperationPerformer : IOperationPerformer
    {
        private IOperation _operation;

        public OperationPerformer()
        {

        }

        public double PerformOperation(params double[] numbers)
        {
            return _operation.Operate(numbers);
        }

        public void SetOperation(IOperation operation)
        {
            _operation = operation;
        }
    }
}
