using Operation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationManager.UI
{
    public static class UIHandler
    {
        public static string GetOperation(IEnumerable<IOperation> availableOperations)
        {
            Console.WriteLine($"{Environment.NewLine} {UITexts.OperationSelectRequest}");
            foreach (IOperation item in availableOperations)
            {
                Console.WriteLine($"  {item.OperationName} -> {item.OperationRepresentation}");
            }
            return ReceiveOperationInput(availableOperations);
        }

        private static string ReceiveOperationInput(IEnumerable<IOperation> operations)
        {
            string lOperation;
            do
            {
                lOperation = GetValidOption(operations);
                if (lOperation != null)
                    return lOperation;
                Console.WriteLine(UITexts.InvalidOptionsInputMessage);
            }
            while (true);
        }

        private static string GetValidOption(IEnumerable<IOperation> operations)
        {
            string lOption = Console.ReadLine();
            if (operations.Any(item => item.OperationRepresentation.Equals(lOption) || item.OperationName.Equals(lOption)))
                return lOption;
            return null;
        }

        public static double[] GetNumbersInput()
        {
            do
            {
                Console.WriteLine($"{UITexts.NumberInputRequest}");
                string[] lInput = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                double[] lNumbers = new double[lInput.Length];
                if (ValidateNumericInputs(lInput, ref lNumbers))
                    return lNumbers;
            }
            while (true);
        }

        private static bool ValidateNumericInputs(string[] input, ref double[] numbers)
        {
            if (input.Length < 1)
            {
                Console.WriteLine(UITexts.InvalidNumbersInputMessage);
                return false;
            }
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

        public static void DisplayOutput(string option, double result, params double[] numbers)
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