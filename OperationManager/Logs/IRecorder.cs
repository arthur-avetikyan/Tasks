namespace OperationManager.Logs
{
    public interface IRecorder
    {
        void Record(LogTypes logTypes, string message);

        void Record(LogTypes logTypes, params string[] messages);
    }


    public enum LogTypes
    {
        Error,
        Warning,
        Info,
        Event
    }
}
