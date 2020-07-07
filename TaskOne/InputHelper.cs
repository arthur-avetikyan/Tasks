using System;

namespace TaskOne
{
    public enum InputMethod
    {
        Group = 1,
        Individual = 2
    }


    public static class InputHelper
    {

        #region Input Method Selector

        public static InputMethod SelectInputMethod()
        {
            bool lSuccess = false;
            InputMethod lInputMethod = InputMethod.Group;
            while (!lSuccess)
            {
                lSuccess = ValidateInputMethod(ref lInputMethod);
            }
            return lInputMethod;
        }

        private static bool ValidateInputMethod(ref InputMethod inputMethod)
        {
            int lMethod = ReceiveInputMethod();

            if (Enum.IsDefined(typeof(InputMethod), lMethod))
            {
                inputMethod = (InputMethod)lMethod;
                return true;
            }
            return false;
        }

        private static int ReceiveInputMethod()
        {
            Console.WriteLine($"Choose input method: {Environment.NewLine} Group -> 1 {Environment.NewLine} Individual -> 2");
            return int.Parse(Console.ReadLine());
        }

        public static void ReceiveNumberInputs(MyList<string> inputedList, InputMethod inputMethod)
        {
            switch (inputMethod)
            {
                case InputMethod.Group:
                    ReceiveNumbersByGroup(inputedList);
                    break;
                case InputMethod.Individual:
                    ReceiveNumbersIdividually(inputedList);
                    break;
            }
        }

        #endregion

        #region Group Input

        public static void ReceiveNumbersByGroup(MyList<string> inputedList)
        {
            Console.WriteLine($"Please input numbers separated with comma (',') in order to save them in the text file.");
            string[] lInput = Console.ReadLine().Split(',');

            AddNumbersByGroup(inputedList, lInput);
        }

        private static void AddNumbersByGroup(MyList<string> inputedList, string[] lInput)
        {
            if (ValidateGroupNumericInputs(lInput))
            {
                inputedList.AddRange(lInput);
            }
            else
            {
                ReceiveNumbersByGroup(inputedList);
            }
        }

        private static bool ValidateGroupNumericInputs(string[] lInput)
        {
            for (int i = 0; i < lInput.Length; i++)
            {
                if (!int.TryParse(lInput[i], out _))
                {
                    Console.WriteLine($"Inputed symbols contain non-numeric charaters.");
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Individual Input

        public static void ReceiveNumbersIdividually(MyList<string> inputedList)
        {
            int lCounter = DetermineItemsCount();

            Console.WriteLine($"Please input {lCounter} numbers in order to save them in the text file.");
            AddNumbersIdividually(inputedList, lCounter);
        }

        private static void AddNumbersIdividually(MyList<string> inputedList, int lCounter)
        {
            while (lCounter > 0)
            {
                string lInput = Console.ReadLine();
                if (int.TryParse(lInput, out _))
                {
                    inputedList.Add(lInput);
                }
                lCounter--;
            }
        }

        private static int DetermineItemsCount()
        {
            bool lIsValid;
            int lCounter;
            do
            {
                Console.WriteLine("Please input total count of numbers that you want to save.");
                lIsValid = int.TryParse(Console.ReadLine(), out lCounter);
            }
            while (!lIsValid);
            return lCounter;
        }

        #endregion

        #region Folder and File Input Helpers

        public static string ReceiveFileName()
        {
            Console.WriteLine($"{Environment.NewLine}Please select file: ");
            return Console.ReadLine();
        }

        public static string ReceiveDirectoryName()
        {
            Console.WriteLine($"{Environment.NewLine}Please select folder: ");
            return Console.ReadLine();
        }

        #endregion
    }
}

