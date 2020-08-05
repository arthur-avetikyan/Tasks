using System;

namespace Writer
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> lInputedList = new MyList<string>();
            FileController lFileController = new FileController();
            InputOption lInputOption;
            DeleteOption lDeleteOption;
            string lCurrentDirectory;
            string lCurrentFile;

            InputHelper.ReqestInputOption();
            lInputOption = InputHelper.SelectOption<InputOption>();
            InputHelper.ReceiveNumberInputs(lInputedList, lInputOption);
            lInputedList.SortByAscending();


            lCurrentDirectory = lFileController.ChooseFolder(InputHelper.ReceiveDirectoryName());
            lCurrentFile = lFileController.ChooseFile(InputHelper.ReceiveFileName(), lCurrentDirectory);
            lFileController.WriteDataToTextFile(lCurrentFile, lInputedList);

            Console.WriteLine($"{Environment.NewLine} {UITexts._successMessage} {lCurrentFile}");

            InputHelper.RequestDeleteOption();
            lDeleteOption = InputHelper.SelectOption<DeleteOption>();
            lFileController.CleanUpFilesAndFolders(lDeleteOption, lCurrentDirectory);

            Console.ReadLine();
        }
    }
}