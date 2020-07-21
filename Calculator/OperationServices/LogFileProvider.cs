using Calculator.IOperationServices;
using Calculator.Settings;
using System;
using System.IO;
using System.Text;

namespace Calculator.OperationServices
{
    public class LogFileProvider : IFileProviderService
    {
        private LoggingSettings _loggingSettings;
        private string _FilePath;

        public LogFileProvider(LoggingSettings loggingSettings)
        {
            _loggingSettings = loggingSettings;
            _FilePath = ProvideFilePath(Directory.GetCurrentDirectory());
        }

        public string ProvideFile()
        {
            if (File.Exists(_FilePath))
                return _FilePath;
            else
            {
                using (File.Create(_FilePath))
                    return _FilePath;
            }
        }

        private string ProvideFilePath(string directory)
        {
            DirectoryInfo lDirectoryInfo = Directory.CreateDirectory(Path.Combine(directory, _loggingSettings.Directory));
            return Path.Combine(lDirectoryInfo.FullName, ConstructLogFileName());
        }

        private string ConstructLogFileName()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.Append($"{_loggingSettings.FileName}_");
            lBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd"));
            lBuilder.Append(_loggingSettings.FileExtention);
            return lBuilder.ToString();
        }
    }
}
