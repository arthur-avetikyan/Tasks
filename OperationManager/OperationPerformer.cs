using Operation;
using OperationManager.UI;
using System;

namespace OperationManager
{
    public class OperationPerformer
    {
        private IOperation _operation;
        double[] _numbers;

        public OperationPerformer(IOperation operation, double[] numbers)
        {
            _operation = operation;
            _numbers = numbers;
        }

        public void PerformOperation()
        {
            double lResult = _operation.Operate(_numbers);
            DisplayOutput(lResult);
        }

        private void DisplayOutput(double result)
        {
            Console.Write($"{Environment.NewLine} {UITexts.ResultMessage} {_numbers[0]} ");
            for (int i = 1; i < _numbers.Length; i++)
            {
                Console.Write($"{_operation.OperationRepresentation} {_numbers[i]} ");
            }
            Console.Write($"= {result}");
        }

    }
}
