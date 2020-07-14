using Operation;

namespace OperationManager
{
    public interface IOperationResolver
    {
        IOperation Resolve(string option);
    }
}
