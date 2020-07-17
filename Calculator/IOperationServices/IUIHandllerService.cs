using Operation;
using System.Collections.Generic;

namespace Calculator.IOperationServices
{
    public interface IUIHandllerService
    {
        public string GetOperationInput(IEnumerable<IOperation> availableOperations);

        public double[] GetNumbersInput();

        public void DisplayOutput(string option, double result, params double[] numbers);

        public bool GetExitOption();
    }
}
