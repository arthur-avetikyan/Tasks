using Operation;
using OperationManager.UI;
using System;

namespace OperationManager
{
    public class OperationPerformer
    {
        private IOperationResolver _operationResolver;

        public OperationPerformer(IOperationResolver operationResolver)
        {
            _operationResolver = operationResolver;
        }

        public void PerformOperation(string option, double[] numbers)
        {
            IOperation lOperation = _operationResolver.Resolve(option);
            double lResult = lOperation.Operate(numbers);
            DisplayOutput(lOperation, numbers, lResult);
        }

        private void DisplayOutput(IOperation operation, double[] numbers, double result)
        {
            Console.Write($"{Environment.NewLine} {UITexts.ResultMessage} {numbers[0]} ");
            for (int i = 1; i < numbers.Length; i++)
            {
                Console.Write($"{operation.OperationRepresentation} {numbers[i]} ");
            }
            Console.Write($"= {result}");
        }

    }
}
