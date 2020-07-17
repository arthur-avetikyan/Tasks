namespace OperationManager.IOperationServices
{
    public interface ILogger
    {
        void RecordLog(LogTypes logTypes, string message);

        void RecordLog(LogTypes logTypes, params string[] messages);
    }

    public enum LogTypes
    {
        Error,
        Warning,
        Info,
        Event
    }
}
