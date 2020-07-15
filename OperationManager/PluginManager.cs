using OperationManager.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OperationManager
{
    internal class PluginManager
    {
        private const string _pluginsDirectory = "Plugins";
        private const string _extension = "*Operations.dll";

        private readonly string _workingDirectory;
        private ILogger _logger;

        public PluginManager()
        {
            _workingDirectory = Directory.GetCurrentDirectory();
            _logger = new Logger();
        }

        public List<T> GetOperations<T>()
        {
            try
            {
                List<T> lOperations = new List<T>();
                string[] lFiles = GetOperationAssemblyFiles();

                foreach (string file in lFiles)
                {
                    lOperations.AddRange(LoadInstances<T>(file));
                }
                return lOperations;
            }
            catch (ArgumentException ex)
            {
                _logger.Record(LogTypes.Error, ex.ToString());
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                _logger.Record(LogTypes.Error, ex.ToString());
                Environment.Exit(1);
            }
            return null;
        }

        private string[] GetOperationAssemblyFiles()
        {
            string lPath = Path.Combine(_workingDirectory, _pluginsDirectory);
            if (Directory.Exists(lPath))
                return Directory.GetFiles(lPath, _extension, SearchOption.TopDirectoryOnly);
            else
            {
                DirectoryInfo lDir = Directory.CreateDirectory(lPath);
                _logger.Record(LogTypes.Warning, "Plugins directory does not exist.", lDir.FullName);
                return Directory.GetFiles(lDir.FullName, _extension, SearchOption.TopDirectoryOnly);
            }
        }

        private List<T> LoadInstances<T>(string fileName)
        {
            List<T> lTypesList = new List<T>();
            Type lToolType = typeof(T);
            try
            {
                Version lVersion = AssemblyName.GetAssemblyName(fileName).Version;
                if (ValidateVersion(lVersion))
                    return lTypesList;

                Assembly lAssembly = Assembly.LoadFrom(fileName);
                _logger.Record(LogTypes.Info, "Assembly loaded.", fileName);

                Type[] lTypes = lAssembly.GetTypes();
                for (int i = 0; i < lTypes.Length; i++)
                {
                    Type lType = lTypes[i];

                    if (lType.IsPublic && !lType.IsAbstract)
                    {
                        if (lToolType.IsAssignableFrom(lType))
                        {
                            lTypesList.Add((T)Activator.CreateInstance(lType));
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                _logger.Record(LogTypes.Error, fileName, ex.ToString());
            }
            catch (FileLoadException ex)
            {
                _logger.Record(LogTypes.Error, fileName, ex.ToString());
            }
            catch (BadImageFormatException ex)
            {
                _logger.Record(LogTypes.Error, fileName, ex.ToString());
            }
            return lTypesList;
        }

        private bool ValidateVersion(Version lVersion)
        {
            return lVersion == null || !lVersion.Equals(Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}