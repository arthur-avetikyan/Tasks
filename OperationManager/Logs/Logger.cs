using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace OperationManager.Logs
{
    public class Logger : ILogger
    {
        private const string _logFileDirectory = "Logs";
        private const string _logFileName = "Error Log";
        private const string _logFileExtention = ".txt";

        private string _path;

        public Logger()
        {
            _path = GetFilePath();
        }

        private bool LogFileExists => File.Exists(_path);

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

        private string GetFilePath() => Path.Combine(GetFolder(), ConstructFileName());


        private string GetFolder()
        {
            DirectoryInfo lDirectoryInfo = Directory.CreateDirectory(GetDirectoryPath());
            if (lDirectoryInfo.Exists)
                return lDirectoryInfo.FullName;
            else
                return null;
        }

        private string GetDirectoryPath() => Path.Combine(Directory.GetCurrentDirectory(), _logFileDirectory);

        private string ConstructFileName()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.Append($"[{_logFileName}] _ ");
            lBuilder.Append(DateTime.UtcNow.ToShortDateString());
            lBuilder.Append(_logFileExtention);
            return lBuilder.ToString();
        }

        public void RecordEvent(string message)
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.AppendLine();
            lBuilder.Append(DateTime.UtcNow.ToString());
            lBuilder.Append(message);
            File.AppendAllText(GetLogFile(), lBuilder.ToString());
        }

        public void RecordEvent(params string[] message)
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.AppendLine();
            lBuilder.AppendLine(DateTime.UtcNow.ToString());
            for (int i = 0; i < message.Length; i++)
            {
                lBuilder.AppendLine(message[i]);
            }
            File.AppendAllText(GetLogFile(), lBuilder.ToString());
        }
    }
}
