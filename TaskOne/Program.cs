using System;

namespace TaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> lInputedList = new MyList<string>();
            FileController lFileController = new FileController();
            InputMethod lInputMethod;
            string lCurrentDirectory;
            string lCurrentFile;

            Console.WriteLine("Hello User");

            lInputMethod = InputHelper.SelectInputMethod();
            InputHelper.ReceiveNumberInputs(lInputedList, lInputMethod);
            lInputedList.SortByAscending();

            lCurrentDirectory = lFileController.ChooseFolder(InputHelper.ReceiveDirectoryName());
            lCurrentFile = lFileController.ChooseFile(InputHelper.ReceiveFileName(), lCurrentDirectory);
            lFileController.WriteDataToTextFile(lCurrentFile, lInputedList);

            Console.WriteLine($"{Environment.NewLine} Success! Your file is saved in {lCurrentFile}");
            Console.ReadLine();
        }
    }
}