using System;
using System.IO;

namespace TaskOne
{
    public class FileController
    {
        private readonly string _fileExtension = ".txt";
        private readonly string _rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public string ChooseFolder(string directoryName)
        {
            string lCreatedDirectory = Path.Combine(_rootDirectory, directoryName);
            if (Directory.Exists(lCreatedDirectory))
            {
                return lCreatedDirectory;
            }
            else
            {
                return CreateFolder(lCreatedDirectory);
            }
        }

        public string ChooseFile(string fileName, string directoryPath)
        {
            string lFilePath = Path.Combine(directoryPath, $"{fileName}{_fileExtension}");
            if (File.Exists(lFilePath))
            {
                return lFilePath;
            }
            else
            {
                return CreateFile(lFilePath);
            }
        }

        public void WriteDataToTextFile(string path, MyList<string> data)
        {
            File.AppendAllLines(path, data);
        }

        private string CreateFolder(string directoryPath)
        {
            DirectoryInfo lDirectoryInfo = Directory.CreateDirectory(directoryPath);
            if (lDirectoryInfo.Exists)
                return lDirectoryInfo.FullName;
            else
                return null;
        }

        private string CreateFile(string filePath)
        {
            using (File.Create(filePath))
            {
                return filePath;
            }
        }
    }
}