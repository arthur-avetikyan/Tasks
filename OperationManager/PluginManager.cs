﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager
{
    internal class PluginManager
    {
        // TODO Ask Q9
        public dynamic LoadOperation(string operationName, string fileName)
        {
            List<dynamic> LDynamicTypes = new List<dynamic>();
            dynamic lList;
            try
            {
                Version lVersion = AssemblyName.GetAssemblyName(operationName).Version;
                if (lVersion == null)
                    throw new FileNotFoundException();
                if (!lVersion.Equals(Assembly.GetExecutingAssembly().GetName().Version))
                    throw new FileNotFoundException();
                Assembly lAssembly = Assembly.LoadFrom(operationName);
                Type[] lTypes = lAssembly.GetTypes();
                for (int i = 0; i < lTypes.Length; i++)
                {
                    Type lType = lTypes[i];
                    if (lType.IsPublic && lType.IsInterface)
                    {
                        MethodInfo method = typeof(PluginManager)
                            .GetMethod(nameof(PluginManager.LoadInstances))
                            .MakeGenericMethod(lType);
                        lList = method.Invoke(this, new[] { fileName });
                        return lList;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public List<T> LoadInstances<T>(string fileName)
        {
            List<T> lTypesList = new List<T>();
            Type lToolType = typeof(T);
            try
            {
                Version lVersion = AssemblyName.GetAssemblyName(fileName).Version;
                if (lVersion == null)
                    return lTypesList;
                if (!lVersion.Equals(Assembly.GetExecutingAssembly().GetName().Version))
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
                            //TODO Ask Q8
                            //var a = Activator.CreateInstance(lType);
                            //var b = (T)a;
                            //lTypesList.Add(b);

                            lTypesList.Add((T)Activator.CreateInstance(lType));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lTypesList;
        }
    }
}
