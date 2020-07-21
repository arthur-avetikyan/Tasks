namespace Calculator.IOperationServices
{
    public interface ILoggerService
    {
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
