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
        private ILogger lLogger = new Logger();

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
                lLogger.RecordEvent(ex.ToString());
                Environment.Exit(1);
            }
            return null;
        }

        private string[] GetOperationAssemblyFiles()
        {
            string lPath = Path.Combine(Directory.GetCurrentDirectory(), _pluginsDirectory);
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

                lLogger.RecordEvent("File loaded ", fileName);

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
                lLogger.RecordEvent(fileName, ex.ToString());
            }
            catch (FileLoadException ex)
            {
                lLogger.RecordEvent(fileName, "Assembly can not be loaded", ex.ToString());
            }
            catch (BadImageFormatException ex)
            {
                lLogger.RecordEvent(fileName, "File is not an assembly", ex.ToString());
            }
            return lTypesList;
        }

        private bool ValidateVersion(Version lVersion)
        {
            return lVersion == null || !lVersion.Equals(Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}