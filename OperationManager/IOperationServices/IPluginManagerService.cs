using System.Collections.Generic;

namespace OperationManager.IOperationServices
{
    public interface IPluginManagerService
    {
        List<T> GetOperations<T>();
    }
}
