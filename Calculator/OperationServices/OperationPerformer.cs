using Calculator.IOperationServices;
using Operation;

namespace Calculator.OperationServices
{
    public class OperationPerformer : IOperationPerformerService
    {
        private IOperation _operation;

        public double PerformOperation(params double[] numbers)
        {
            return _operation.Operate(numbers);
        }

        public void SetOperation(IOperation operation)
        {
            _operation = operation;
        }

        public void SetOperation(IOperation operation)
        {
            _operation = operation;
        }
    }
}
