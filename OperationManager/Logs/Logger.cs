using System;
using System.IO;
using System.Text;

namespace OperationManager.Logs
{
    public class Logger : IRecorder
    {
        private const string _logFileDirectory = "Logs";
        private const string _logFileName = "Event_Log";
        private const string _logFileExtention = ".txt";

        private readonly string _path;
        private readonly string _workingDirectory;

        public Logger()
        {
            _workingDirectory = Directory.GetCurrentDirectory();
            _path = GetFilePath(_workingDirectory);
        }

        public bool LogFileExists => File.Exists(_path);

        public string GetLogFile()
        {
            if (LogFileExists)
                return _path;
            else
            {
                using (File.Create(_path))
                    return _path;
            }
        }

        private string GetFilePath(string workingDirectory) => Path.Combine(GetFolder(workingDirectory), ConstructFileName());

        private string GetFolder(string workingDirectory)
        {
            DirectoryInfo lDirectoryInfo = Directory.CreateDirectory(GetDirectoryPath(workingDirectory));
            if (lDirectoryInfo.Exists)
                return lDirectoryInfo.FullName;
            else
                return null;
        }

        private string GetDirectoryPath(string workingDirectory) => Path.Combine(workingDirectory, _logFileDirectory);

        private string ConstructFileName()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.Append($"{_logFileName}_");
            lBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd"));
            lBuilder.Append(_logFileExtention);
            return lBuilder.ToString();
        }

        public void Record(LogTypes logTypes, string message)
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.AppendLine();
            lBuilder.AppendLine(logTypes.ToString());
            lBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd"));
            lBuilder.Append(message);
            File.AppendAllText(GetLogFile(), lBuilder.ToString());
        }

        public void Record(LogTypes logTypes, params string[] messages)
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
