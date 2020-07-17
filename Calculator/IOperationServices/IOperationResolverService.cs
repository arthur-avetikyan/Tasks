using Operation;
using System.Collections.Generic;

namespace Calculator.IOperationServices
{
    public interface IOperationResolverService
    {
        IEnumerable<IOperation> Operations { get; }

        IOperation ResolveOperation(string option = null);
    }
}