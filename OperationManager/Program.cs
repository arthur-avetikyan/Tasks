using Operation;
using OperationManager.Logs;
using OperationManager.UI;
using System;
using System.Collections.Generic;

namespace OperationManager
{
    class Program
    {
        static void Main(string[] args)
        {
            PluginManager pluginManager = new PluginManager();
            List<IOperation> lOperations = pluginManager.GetOperations();
            IOperation lSelectedOperation = UIHandler.RequestOperation(lOperations);
            if (lSelectedOperation != null)
                UIHandler.ReceiveNumbersInput(lSelectedOperation);

            Console.ReadLine();
        }
    }
}
