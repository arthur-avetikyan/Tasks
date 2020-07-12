using Operation;
using OperationManager.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OperationManager
{
    internal class PluginManager
    {
        private string _PluginsDirectory = "Plugins";
        private string _extension = "*Operations.dll";
        private ILogger logger = new Logger();

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
                logger.RecordEvent(ex.ToString());
                Environment.Exit(-1);
            }
            return null;
        }

        private string[] GetOperationAssemblyFiles()
        {
            string lPath = Path.Combine(Directory.GetCurrentDirectory(), _PluginsDirectory);
            return Directory.GetFiles(lPath, _extension, SearchOption.AllDirectories);
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
            catch (ArgumentException ex)
            {
                logger.RecordEvent(ex.ToString());
            }
            catch (FileLoadException ex)
            {
                logger.RecordEvent(ex.ToString());
            }
            return lTypesList;
        }

        private bool ValidateVersion(Version lVersion)
        {
            return lVersion == null || !lVersion.Equals(Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}