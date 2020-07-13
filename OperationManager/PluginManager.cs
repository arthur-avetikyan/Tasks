using Operation;
using OperationManager.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;

namespace OperationManager
{
    internal class PluginManager
    {
        private const string _pluginsDirectory = "Plugins";
        private const string _extension = "*Operations.dll";

        private readonly string _workingDirectory;
        private IRecorder lLogger;

        public PluginManager()
        {
            _workingDirectory = Directory.GetCurrentDirectory();
            lLogger = new Logger();
        }

        public List<IOperation> GetOperations()
        {
            try
            {
                List<IOperation> lOperations = new List<IOperation>();
                string[] lFiles = GetOperationAssemblyFiles();

                foreach (string file in lFiles)
                {
                    lOperations.AddRange(LoadInstances<IOperation>(file));
                }
                return lOperations;
            }
            catch (ArgumentException ex)
            {
                lLogger.RecordError(ex.ToString());
                Environment.Exit(1);
            }
            return null;
        }

        private string[] GetOperationAssemblyFiles()
        {

            string lPath = Path.Combine(_workingDirectory, _pluginsDirectory);
            return Directory.GetFiles(lPath, _extension, SearchOption.TopDirectoryOnly);
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
                Type[] lTypes = lAssembly.GetTypes();

                lLogger.RecordEvent("File loaded.", fileName);

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
                lLogger.RecordError(fileName, ex.ToString());
            }
            catch (FileLoadException ex)
            {
                lLogger.RecordError(fileName, ex.ToString());
            }
            catch (BadImageFormatException ex)
            {
                lLogger.RecordError(fileName, ex.ToString());
            }
            return lTypesList;
        }

        private bool ValidateVersion(Version lVersion)
        {
            return lVersion == null || !lVersion.Equals(Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}