using System;

namespace Writer
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<char> lCharList = new MyList<char>() { '5', 'a', 't', '?' };
            MyList<int> lintList = new MyList<int>() { 15, 15, 61, 15612516 };
            MyList<long> lLongList = new MyList<long>() { 15, 15, 61, 15612516 };
            MyList<double> lDoubleList = new MyList<double>() { 15, 15, 61, 15612516 };
            MyList<decimal> lDecimalList = new MyList<decimal>() { 15, 15, 61, 15612516 };
            MyList<string> lStringList = new MyList<string>() { "15", "15", "61", "15612516" };
            MyList<MyStruct> myStructs = new MyList<MyStruct>() { new MyStruct { _count = 15, _amount = 11, _symbol = 'a' } };

            lCharList.Do();
            lintList.Do();
            lLongList.Do();
            lDoubleList.Do();
            lDecimalList.Do();
            lStringList.Do();
            myStructs.Do();





            //MyList<string> lInputedList = new MyList<string>();
            //FileController lFileController = new FileController();
            //InputOption lInputOption;
            //DeleteOption lDeleteOption;
            //string lCurrentDirectory;
            //string lCurrentFile;

            //InputHelper.ReqestInputOption();
            //lInputOption = InputHelper.SelectOption<InputOption>();
            //InputHelper.ReceiveNumberInputs(lInputedList, lInputOption);
            //lInputedList.SortByAscending();


            //lCurrentDirectory = lFileController.ChooseFolder(InputHelper.ReceiveDirectoryName());
            //lCurrentFile = lFileController.ChooseFile(InputHelper.ReceiveFileName(), lCurrentDirectory);
            //lFileController.WriteDataToTextFile(lCurrentFile, lInputedList);

            //Console.WriteLine($"{Environment.NewLine} {UITexts._successMessage} {lCurrentFile}");

            //InputHelper.RequestDeleteOption();
            //lDeleteOption = InputHelper.SelectOption<DeleteOption>();
            //lFileController.CleanUpFilesAndFolders(lDeleteOption, lCurrentDirectory);

            Console.ReadLine();
        }
    }

    struct MyStruct
    {
        public int _count;
        public double _amount;
        public char _symbol;
    }
}