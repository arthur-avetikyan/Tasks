using Calculator.IOperationServices;
using System;
using System.IO;
using System.Text;

namespace Calculator.OperationServices
{
    public class Logger : ILoggerService
    {
        private IFileProviderService _fileProvider;
        private StringBuilder _builder;

        public Logger(IFileProviderService fileProvider)
        {
            _fileProvider = fileProvider;
            _builder = new StringBuilder();
        }

        public void RecordLog(LogTypes logTypes, params string[] messages)
        {
            _builder.Clear();
            _builder.AppendLine();
            _builder.AppendLine(logTypes.ToString());
            _builder.AppendLine(DateTime.Now.ToString());
            for (int i = 0; i < messages.Length; i++)
            {
                _builder.AppendLine(messages[i]);
            }
            File.AppendAllText(_fileProvider.ProvideFile(), _builder.ToString());
        }
    }
}
