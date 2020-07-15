using OperationManager.UI;
using System;

namespace OperationManager
{
    class Program
    {
        static void Main(string[] args)
        {
            OperationResolver lResolver = new OperationResolver();
            OperationPerformer lOperationPerformer;
            string lOption;
            double[] lNumbers;
            double lResult;

            do
            {
                lOption = UIHandler.GetOperation(lResolver.Operations);
                lOperationPerformer = lResolver.ResolveOperation(lOption);
                lNumbers = UIHandler.GetNumbersInput();
                lResult = lOperationPerformer.PerformOperation(lNumbers);
                UIHandler.DisplayOutput(lOption, lResult, lNumbers);
            }
            while (true);


            //   Console.ReadLine();
        }
    }
}