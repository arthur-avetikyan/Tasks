using System.Collections.Generic;

namespace Calculator.IOperationServices
{
    public interface IPluginManagerService
    {
        List<T> GetOperations<T>();
    }
}
