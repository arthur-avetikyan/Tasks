using Operation;
using OperationManager.IOperationServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationManager
{
    public class OperationResolver : IOperationResolver
    {
        private ILogger _logger;

        public IEnumerable<IOperation> Operations { get; }

        public OperationResolver(IPluginManagerService pluginManagerService, ILogger logger)
        {
            Operations = pluginManagerService.GetOperations<IOperation>();
            _logger = logger;
        }

        public IOperation ResolveOperation(string option = null)
        {
            IOperation lOperation = option == null ? Operations.FirstOrDefault() : Operations
                .Where(item => item.OperationRepresentation.Equals(option) || item.OperationName.Equals(option))
                .FirstOrDefault();
            _logger.RecordLog(LogTypes.Info, $"Operation switched to {lOperation}");
            if (lOperation == null)
                throw new ArgumentException("Operation not found", option);
            return lOperation;
        }
    }
}
