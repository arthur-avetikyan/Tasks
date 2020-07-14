using Operation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationManager
{
    public class OperationResolver : IOperationResolver
    {
        public IEnumerable<IOperation> Operations { get; }

        public OperationResolver()
        {
            Operations = new PluginManager().GetOperations<IOperation>();
        }

        public IOperation Resolve(string option)
        {
            IOperation lOperation = Operations
                .Where(item => item.OperationRepresentation.Equals(option) || item.OperationName.Equals(option))
                .FirstOrDefault();
            if (lOperation == null)
                throw new ArgumentException("Operation not found", option);
            return lOperation;
        }
    }
}
