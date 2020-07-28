using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Analizer
{
    public interface IAnalizerFactory
    {
        List<AnalizerTemplate> GetAnalizers();
    }

    public class AnalizerFactory : IAnalizerFactory
    {
        private AnalizerData _analizerData;

        public AnalizerFactory(AnalizerData analizerData)
        {
            _analizerData = analizerData;
        }

        public List<AnalizerTemplate> GetAnalizers()
        {
            List<AnalizerTemplate> lTypesList = new List<AnalizerTemplate>();
            try
            {
                string[] lFiles = Directory.GetFiles(_analizerData.Settings.Directory, $"*{ _analizerData.Settings.SourceFileName}*", SearchOption.TopDirectoryOnly);
                foreach (var item in lFiles)
                {
                    var lExtention = item.Substring(item.IndexOf('.', StringComparison.OrdinalIgnoreCase) + 1).ToUpper();
                    Type lType = Assembly.GetExecutingAssembly().GetType($"Analizer.{lExtention}Analizer", false, true);
                    if (typeof(AnalizerTemplate).IsAssignableFrom(lType))
                    {
                        lTypesList.Add((AnalizerTemplate)Activator.CreateInstance(lType, _analizerData));
                    }
                }
            }
            catch (IOException ex)
            {
                //Log here
            }
            catch (ArgumentException ex)
            {
                //Log here
            }
            catch(Exception ex)
            {
                //Log here
            }
            return lTypesList;
        }
    }
}
