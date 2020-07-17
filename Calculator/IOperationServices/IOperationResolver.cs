using Operation;
using System.Collections.Generic;

namespace OperationManager.IOperationServices
{
    public interface IOperationResolver
    {
        IEnumerable<IOperation> Operations { get; }

        IOperation ResolveOperation(string option = null);
    }
}