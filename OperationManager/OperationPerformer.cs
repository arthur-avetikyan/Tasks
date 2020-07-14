using OperationManager.UI;
using System;

namespace OperationManager
{
    public class OperationPerformer
    {
        private IOperationResolver _iOperationResolver;

        public OperationPerformer(IOperationResolver iOperationResolver)
        {
            _iOperationResolver = iOperationResolver;
        }

        public void PerformOperation(string option, params double[] numbers)
        {
            double lResult = _iOperationResolver.Resolve(option).Operate(numbers);
            DisplayOutput(option, lResult, numbers);
        }

        private void DisplayOutput(string option, double result, params double[] numbers)
        {
            Console.Write($"{Environment.NewLine} {UITexts.ResultMessage} {numbers[0]} ");
            for (int i = 1; i < numbers.Length; i++)
            {
                Console.Write($"{option} {numbers[i]} ");
            }
            Console.Write($"= {result}");
        }
    }
}
