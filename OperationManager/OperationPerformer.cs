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

        public void PerformOperation(string option, double[] numbers)
        {
            double lResult = _iOperationResolver.Resolve(option).Operate(numbers);
            DisplayOutput(lResult);
        }

        private void DisplayOutput(double result) => Console.Write($"{Environment.NewLine} {UITexts.ResultMessage} {result} ");

    }
}
