using Operation;
using System;
using System.Collections.Generic;
using System.IO;

namespace OperationManager
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryPaths lLibraryPaths = new LibraryPaths();
            PluginManager pluginManager = new PluginManager();

            UIHandler.RequestOperation();

            string lOperation = UIHandler.ReceiveOperationInput(lLibraryPaths.availablePlugins);
            string lPath = Path.Combine(LibraryPaths._pluginDirectory, lOperation);
            List<IOperation> lOperations = pluginManager.LoadInstances<IOperation>(lPath);

            UIHandler.ReceiveNumbersInput(lOperations);

            Console.ReadLine();
        }
    }
}
