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
            lOperationPerformer.PerformOperation(UIHandler.RequestOperation(lResolver.Operations), UIHandler.ReceiveNumbersInput());

            Console.ReadLine();
        }
    }
}
