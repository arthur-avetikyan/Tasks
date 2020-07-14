using OperationManager.UI;
using System;

namespace OperationManager
{
    class Program
    {
        static void Main(string[] args)
        {
            OperationResolver lResolver = new OperationResolver();
            OperationPerformer lOperationPerformer = new OperationPerformer(lResolver);
        //    lOperationPerformer.PerformOperation(UIHandler.GetOperation(lResolver.Operations), UIHandler.GetNumbersInput());

            lOperationPerformer.PerformOperation("Add", 1, 5, 6);
            lOperationPerformer.PerformOperation("*", 1, 5, 6);
            lOperationPerformer.PerformOperation("-", 1, 5, 6);
            lOperationPerformer.PerformOperation("/", 1, 5, 6);

            Console.ReadLine();
        }
    }
}