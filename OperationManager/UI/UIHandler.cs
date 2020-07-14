using Operation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationManager.UI
{
    public static class UIHandler
    {
        public static IOperation RequestOperation()
        {
            List<IOperation> lAvailableOperations = new PluginManager().GetOperations();
            Console.WriteLine($" {UITexts.UserGreeting}");
            Console.WriteLine($" {UITexts.OperationSelectRequest}");
            if (lAvailableOperations.Count < 1)
            {
                Console.WriteLine(UITexts.FailureMessage);
                return null;
            }
            foreach (IOperation item in lAvailableOperations)
            {
                Console.WriteLine($"  {item.OperationName} -> {item.OperationRepresentation}");
            }
            return ReceiveOperationInput(lAvailableOperations);
        }

        private static IOperation ReceiveOperationInput(List<IOperation> operations)
        {
            IOperation lOperation;
            do
            {
                lOperation = GetValidOption(operations);
                if (lOperation != null)
                    return lOperation;
                Console.WriteLine(UITexts.InvalidOptionsInputMessage);
            }
            while (true);
        }

        private static IOperation GetValidOption(List<IOperation> operations)
        {
            string lOption = Console.ReadLine();
            return operations
                .Where(item => item.OperationRepresentation.Equals(lOption) || item.OperationName.Equals(lOption))
                .FirstOrDefault();
        }

        public static double[] ReceiveNumbersInput()
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
    }
}