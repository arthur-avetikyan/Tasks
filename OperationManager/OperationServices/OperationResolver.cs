using Operation;
using OperationManager.IOperationServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationManager
{
    public class OperationResolver : IOperationResolver
    {
        public IEnumerable<IOperation> Operations { get; }

        public OperationResolver(IPluginManagerService pluginManagerService)
        {
            Operations = pluginManagerService.GetOperations<IOperation>();
        }

        public IOperation ResolveOperation(string option = null)
        {
            IOperation lOperation = option == null ? Operations.FirstOrDefault() : Operations
                .Where(item => item.OperationRepresentation.Equals(option) || item.OperationName.Equals(option))
                .FirstOrDefault();
            if (lOperation == null)
                throw new ArgumentException("Operation not found", option);
            return lOperation;
        }
    }
}
