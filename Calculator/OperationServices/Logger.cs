using OperationManager.IOperationServices;
using System;
using System.IO;
using System.Text;

namespace OperationManager.OperationServices
{
    public class Logger : ILogger
    {
        private const string _logFileDirectory = "Logs";
        private const string _logFileName = "Event_Log";
        private const string _logFileExtention = ".txt";

        private readonly string _filePath;
        private readonly string _workingDirectory;

        public Logger()
        {
            _workingDirectory = Directory.GetCurrentDirectory();
            _filePath = GetFilePath(_workingDirectory);
        }

        public bool LogFileExists => File.Exists(_filePath);

        public string GetLogFile()
        {
            if (LogFileExists)
                return _filePath;
            else
            {
                using (File.Create(_filePath))
                    return _filePath;
            }
        }

        private string GetFilePath(string workingDirectory)
        {
            DirectoryInfo lDirectoryInfo = Directory.CreateDirectory(Path.Combine(workingDirectory, _logFileDirectory));
            return Path.Combine(lDirectoryInfo.FullName, ConstructFileName());
        }

        private string ConstructFileName()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.Append($"{_logFileName}_");
            lBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd"));
            lBuilder.Append(_logFileExtention);
            return lBuilder.ToString();
        }

        public void RecordLog(LogTypes logTypes, string message)
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.AppendLine();
            lBuilder.AppendLine(logTypes.ToString());
            lBuilder.AppendLine(DateTime.Now.ToString());
            lBuilder.AppendLine(message);
            File.AppendAllText(GetLogFile(), lBuilder.ToString());
        }

        public void RecordLog(LogTypes logTypes, params string[] messages)
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.AppendLine();
            lBuilder.AppendLine(logTypes.ToString());
            lBuilder.AppendLine(DateTime.Now.ToString());
            for (int i = 0; i < messages.Length; i++)
            {
                lBuilder.AppendLine(messages[i]);
            }
            File.AppendAllText(GetLogFile(), lBuilder.ToString());
        }
    }
}
