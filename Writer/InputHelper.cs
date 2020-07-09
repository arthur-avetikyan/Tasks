using System;
using System.IO;
using System.Linq;

namespace Writer
{
    public enum InputOption
    {
        Group = 1,
        Individual = 2
    }

    public enum DeleteOption
    {
        Yes = 1,
        No = 2
    }

    public static class InputHelper
    {
        #region Option Selector

        public static void ReqestInputOption()
        {
            Console.WriteLine(UITexts._userGreeting);
            Console.WriteLine($"{UITexts._inputOptionRequestMessage}{Environment.NewLine} {InputOption.Group} -> 1 {Environment.NewLine} {InputOption.Individual} -> 2");
        }
        public static void RequestDeleteOption()
        {
            Console.WriteLine($"{Environment.NewLine}{UITexts._deleteOptionRequestMessage}{Environment.NewLine} {DeleteOption.Yes} -> 1 {Environment.NewLine} {DeleteOption.No} -> 2");
        }

        public static T SelectOption<T>() where T : struct, Enum
        {
            T lOption;
            bool lSuccess;
            do
            {
                lSuccess = GetValidOption(out lOption);
                if (!lSuccess)
                    Console.WriteLine(UITexts._invalidOptionsInputMessage);
            }
            while (!lSuccess);
            return lOption;
        }

        private static bool GetValidOption<T>(out T option) where T : struct, Enum
        {
            return Enum.TryParse(Console.ReadLine(), true, out option) && Enum.IsDefined(typeof(T), option);
        }

        public static void ReceiveNumberInputs(MyList<string> inputedList, InputOption inputMethod)
        {
            switch (inputMethod)
            {
                case InputOption.Group:
                    ReceiveNumbersByGroup(inputedList);
                    break;
                case InputOption.Individual:
                    ReceiveNumbersIdividually(inputedList);
                    break;
            }
        }

        #endregion

        #region Group Input

        public static void ReceiveNumbersByGroup(MyList<string> inputedList)
        {
            Console.WriteLine(UITexts._groupNumberInputRequestMessage);
            string[] lInput = Console.ReadLine().Split(',');

            AddNumbersByGroup(inputedList, lInput);
        }

        private static void AddNumbersByGroup(MyList<string> inputedList, string[] lInput)
        {
            if (ValidateGroupNumericInputs(lInput))
                inputedList.AddRange(lInput);
            else
                ReceiveNumbersByGroup(inputedList);
        }

        private static bool ValidateGroupNumericInputs(string[] lInput)
        {
            for (int i = 0; i < lInput.Length; i++)
            {
                if (!double.TryParse(lInput[i], out _))
                {
                    Console.WriteLine(UITexts._invalidNumbersInputMessage);
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

        private static void AddNumbersIdividually(MyList<string> inputedList, int counter)
        {
            while (counter > 0)
            {
                string lInput = Console.ReadLine();
                if (double.TryParse(lInput, out _))
                {
                    inputedList.Add(lInput);
                    counter--;
                }
                else
                    Console.WriteLine(UITexts._invalidNumbersInputMessage);
            }
        }

        private static int DetermineItemsCount()
        {
            bool lIsValid;
            int lCounter;
            do
            {
                Console.WriteLine(UITexts._itemCountRequestMessage);
                lIsValid = int.TryParse(Console.ReadLine(), out lCounter) && lCounter > 0;
            }
            while (!lIsValid);
            return lCounter;
        }

        #endregion

        #region Folder and File Input 

        public static string ReceiveDirectoryName()
        {
            string lDirectoryNameInput;
            do
            {
                Console.WriteLine($"{Environment.NewLine}{UITexts._folderNameRequestMessage}");
                lDirectoryNameInput = Console.ReadLine();
            }
            while (IsNotValidName(lDirectoryNameInput));
            return lDirectoryNameInput;
        }

        public static string ReceiveFileName()
        {
            string lFileNameInput;
            do
            {
                Console.WriteLine($"{Environment.NewLine}{UITexts._fileNameRequestMessage}");
                lFileNameInput = Console.ReadLine();
            }
            while (IsNotValidName(lFileNameInput));
            return lFileNameInput;
        }

        private static bool IsNotValidName(string nameInput)
        {
            if (IsEmpty(nameInput))
                return true;
            if (HasInvalidSymbols(nameInput, Path.GetInvalidPathChars()))
                return true;
            if (HasInvalidSymbols(nameInput, Path.GetInvalidFileNameChars()))
                return true;
            return false;
        }

        private static bool IsEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input) || input.StartsWith(" ");
        }

        private static bool HasInvalidSymbols(string input, char[] symbols)
        {
            foreach (var item in input)
            {
                if (symbols.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}