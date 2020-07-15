using OperationManager.UI;

namespace OperationManager
{
    class Program
    {
        static void Main(string[] args)
        {
            OperationResolver lResolver = new OperationResolver();
            OperationPerformer lOperationPerformer = lResolver.ResolveOperationPerformer();
            string lOption;
            double[] lNumbers;
            double lResult;
            bool lNext;

            do
            {
                lOption = UIHandler.GetOperation(lResolver.Operations);
                lOperationPerformer.SetOperation(lResolver.ResolveOperation(lOption));
                lNumbers = UIHandler.GetNumbersInput();
                lResult = lOperationPerformer.PerformOperation(lNumbers);
                UIHandler.DisplayOutput(lOption, lResult, lNumbers);
                lNext = UIHandler.GetExitOption();
            }
            while (lNext);
        }
    }
}