using Operation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
