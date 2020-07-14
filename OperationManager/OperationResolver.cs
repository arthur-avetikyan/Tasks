using Operation;
using System.Collections.Generic;
using System.Linq;

namespace OperationManager
{
    public class OperationResolver : IOperationResolver
    {
        public IEnumerable<IOperation> Operations { get; }

        public OperationResolver()
        {
            Operations = new PluginManager().GetOperations();
        }

        public IOperation Resolve(string option)
        {
            return Operations
                .Where(item => item.OperationRepresentation.Equals(option) || item.OperationName.Equals(option))
                .FirstOrDefault();
        }
    }
}
