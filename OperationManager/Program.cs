using OperationManager.UI;

namespace OperationManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Resolver lResolver = new Resolver();
            OperationPerformer lOperationPerformer;
            string lOption;
            double[] lNumbers;
            double lResult;
            bool lNext;

            do
            {
                lOption = UIHandler.GetOperation(lResolver.Operations);
                lOperationPerformer = lResolver.ResolveOperation(lOption);
                lNumbers = UIHandler.GetNumbersInput();
                lResult = lOperationPerformer.PerformOperation(lNumbers);
                UIHandler.DisplayOutput(lOption, lResult, lNumbers);
                lNext = UIHandler.GetExitOption();
            }
            while (lNext);
        }
    }
}