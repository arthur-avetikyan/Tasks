namespace OperationManager.Logs
{
    public interface IRecorder
    {
        void RecordEvent(string message);

        void RecordEvent(params string[] messages);
    }
}
