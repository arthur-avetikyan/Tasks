using Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager
{
    public static class UIHandler
    {
        public static void RequestOperation()
        {
            Console.WriteLine($" {UITexts._userGreeting}");
            Console.WriteLine($" {UITexts._operationSelectRequest}");
            Console.WriteLine($" Add -> 1{Environment.NewLine} Subtract -> 2{Environment.NewLine} Multiply -> 3{Environment.NewLine} Divide -> 4");
        }

        public static string ReceiveOperationInput(Dictionary<int, string> availablePlugins)
        {
            int lOption;
            bool lSuccess;
            do
            {
                lSuccess = GetValidOption(out lOption, availablePlugins);
                if (!lSuccess)
                    Console.WriteLine(UITexts._invalidOptionsInputMessage);
            }
            while (!lSuccess);
            return availablePlugins[lOption];
        }

        private static bool GetValidOption(out int option, Dictionary<int, string> availablePlugins)
        {
            return int.TryParse(Console.ReadLine(), out option) && availablePlugins.ContainsKey(option);
        }

        public static void ReceiveNumbersInput(List<IOperation> operations)
        {
            Console.WriteLine($"{UITexts._numberInputRequest}");
            string[] lInput = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
             ApplyNumbers(operations, lInput);
        }

        private static void ApplyNumbers(List<IOperation> operations, string[] lInput)
        {
            double[] lNumbers = new double[lInput.Length];
            if (ValidateGroupNumericInputs(lInput, ref lNumbers))
                PerformOperation(operations, lNumbers);
            else
                ReceiveNumbersInput(operations);
        }

        private static bool ValidateGroupNumericInputs(string[] lInput, ref double[] numbers)
        {
            for (int i = 0; i < lInput.Length; i++)
            {
                if (!double.TryParse(lInput[i], out numbers[i]))
                {
                    Console.WriteLine(UITexts._invalidNumbersInputMessage);
                    return false;
                }
            }
            return true;
        }

        private static void PerformOperation(List<IOperation> operations, double[] numbers)
        {
            foreach (var item in operations)
            {
                DisplayOutput(item.Operate(numbers[0], numbers[1]));
            }
        }

        public static void DisplayOutput(double result)
        {
            Console.WriteLine($"{UITexts._resultMessage}{result}");
        }
    }
}
