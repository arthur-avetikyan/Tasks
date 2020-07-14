using Operation;
using OperationManager.UI;
using System;
using System.Collections.Generic;

namespace OperationManager
{
    class Program
    {
        static void Main(string[] args)
        {
            IOperation lSelectedOperation = UIHandler.RequestOperation();
            if (lSelectedOperation == null)
                return;
            double[] lOperands = UIHandler.ReceiveNumbersInput();

            OperationPerformer operationPerformer = new OperationPerformer(lSelectedOperation, lOperands);
            operationPerformer.PerformOperation();

            Console.ReadLine();
        }
    }
}
