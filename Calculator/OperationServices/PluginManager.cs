using Calculator.IOperationServices;
using Calculator.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Calculator
{
    internal class PluginManager : IPluginManagerService
    {
        private ILoggerService _logger;
        private PluginSettings _pluginSettings;

        public PluginManager(ILoggerService logger, PluginSettings pluginSettings)
        {
            _pluginSettings = pluginSettings;
            _logger = logger;
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
                _logger.RecordLog(LogTypes.Error, ex.ToString());
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                _logger.RecordLog(LogTypes.Error, ex.ToString());
                Environment.Exit(1);
            }
            return null;
        }

        private string[] GetOperationAssemblyFiles()
        {
            string lPath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), _pluginSettings.PluginsDirectoryLevel), _pluginSettings.PluginsDirectory);
            if (Directory.Exists(lPath))
                return Directory.GetFiles(lPath, _pluginSettings.PluginFileNameConvention, SearchOption.TopDirectoryOnly);
            else
            {
                DirectoryInfo lDir = Directory.CreateDirectory(lPath);
                _logger.RecordLog(LogTypes.Warning, "Plugins directory does not exist.", lDir.FullName);
                return Directory.GetFiles(lDir.FullName, _pluginSettings.PluginFileNameConvention, SearchOption.TopDirectoryOnly);
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
                _logger.RecordLog(LogTypes.Info, "Assembly loaded.", fileName);

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
                _logger.RecordLog(LogTypes.Error, fileName, ex.ToString());
            }
            catch (FileLoadException ex)
            {
                _logger.RecordLog(LogTypes.Error, fileName, ex.ToString());
            }
            catch (BadImageFormatException ex)
            {
                _logger.RecordLog(LogTypes.Error, fileName, ex.ToString());
            }
            return lTypesList;
        }

        private bool ValidateVersion(Version lVersion)
        {
            return lVersion == null || !lVersion.Equals(Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}