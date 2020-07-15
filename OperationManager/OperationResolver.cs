using Operation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationManager
{
    public class OperationResolver
    {
        public IEnumerable<IOperation> Operations { get; }

        public OperationResolver()
        {
            Operations = new PluginManager().GetOperations<IOperation>();
        }

        public OperationPerformer ResolveOperationPerformer(string option = null)
        {
            IOperation lOperation = GetSelectedOperation(option);
            return new OperationPerformer(lOperation);
        }

        public IOperation ResolveOperation(string option = null)
        {
            return GetSelectedOperation(option);
        }

        private IOperation GetSelectedOperation(string option = null)
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
