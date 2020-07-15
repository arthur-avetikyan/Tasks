using Operation;

namespace OperationManager
{
    public class OperationPerformer
    {
        private IOperation _operation;

        public OperationPerformer(IOperation operation)
        {
            _operation = operation;
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
