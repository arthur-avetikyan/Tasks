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
            List<IOperation> lOperations = new List<IOperation>();
            string[] lFiles = GetOperationAssemblyFiles();

            foreach (string file in lFiles)
            {
                lOperations.AddRange(LoadInstances<IOperation>(file));
            }
            return lOperations;
        }

        private string[] GetOperationAssemblyFiles()
        {
            string lPath = Path.Combine(Directory.GetCurrentDirectory(), _PluginsDirectory);
            try
            {
                return Directory.GetFiles(lPath, _extension, SearchOption.AllDirectories);
            }
            catch (Exception ex)
            {
                logger.RecordError(ex);
                Environment.Exit(-1);
            }
            return null; ;
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
                logger.RecordError(ex);
            }
            catch (FileLoadException ex)
            {
                logger.RecordError(ex);
            }
            return lTypesList;
        }

        private bool ValidateVersion(Version lVersion)
        {
            return lVersion == null || !lVersion.Equals(Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}