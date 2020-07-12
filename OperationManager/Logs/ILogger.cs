using System;
using System.Diagnostics;

namespace OperationManager.Logs
{
    public interface ILogger
    {
        void RecordEvent(string message);

        void RecordEvent(params string[] message);
    }
}
