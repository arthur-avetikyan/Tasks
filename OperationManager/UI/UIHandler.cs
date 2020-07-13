using Operation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationManager.UI
{
    public static class UIHandler
    {
        public static IOperation RequestOperation(List<IOperation> availableOperations)
        {
            Console.WriteLine($" {UITexts.UserGreeting}");
            if (availableOperations.Count < 1)
            {
                Console.WriteLine(UITexts.FailureMessage);
                return null;
            }
            else
            {
                Console.WriteLine($" {UITexts.OperationSelectRequest}");
                foreach (IOperation item in availableOperations)
                {
                    Console.WriteLine($"  {item.OperationName} -> {item.OperationSymbol}");
                }
                return ReceiveOperationInput(availableOperations);
            }
        }

        private static IOperation ReceiveOperationInput(List<IOperation> operations)
        {
            IOperation lOperation;
            do
            {
                lOperation = GetValidOption(operations);
                if (lOperation != null)
                {
                    return lOperation;
                }
                Console.WriteLine(UITexts.InvalidOptionsInputMessage);
            }
            while (true);
        }

        private static IOperation GetValidOption(List<IOperation> operations)
        {
            string lOption = Console.ReadLine();
            return operations
                .Where(item => item.OperationSymbol.Equals(lOption) || item.OperationName.Equals(lOption))
                .FirstOrDefault();
        }

        public static void ReceiveNumbersInput(IOperation selectedOperation)
        {
            Console.WriteLine($"{UITexts.NumberInputRequest}");
            string[] lInput = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            ApplyNumbers(selectedOperation, lInput);
        }

        private static void ApplyNumbers(IOperation selectedOperation, string[] input)
        {
            double[] lNumbers = new double[input.Length];
            if (ValidateGroupNumericInputs(input, ref lNumbers))
                PerformOperation(selectedOperation, lNumbers);
            else
                ReceiveNumbersInput(selectedOperation);
        }

        private static bool ValidateGroupNumericInputs(string[] input, ref double[] numbers)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!double.TryParse(input[i], out numbers[i]))
                {
                    Console.WriteLine(UITexts.InvalidNumbersInputMessage);
                    return false;
                }
            }
            return true;
        }

        private static void PerformOperation(IOperation selectedOperation, double[] numbers)
        {
            double lResult = selectedOperation.Operate(numbers);
            DisplayOutput(selectedOperation, numbers, lResult);
        }

        public static void DisplayOutput(IOperation selectedOperation, double[] numbers, double result)
        {
            Console.Write($"{Environment.NewLine} {UITexts.ResultMessage} {numbers[0]} ");
            for (int i = 1; i < numbers.Length; i++)
            {
                Console.Write($"{selectedOperation.OperationSymbol} {numbers[i]} ");
            }
            Console.Write($"= {result}");
        }
    }
}