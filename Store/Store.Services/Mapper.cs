using Store.IServices;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace Store.Services
{
    public class Mapper : IMapper
    {
        public TDestination MapTo<TDestination, TSource>(TSource source)
        {
            Type lSourceType = typeof(TSource);
            Type lDestinationType = typeof(TDestination);

            TDestination lDestination = Activator.CreateInstance<TDestination>();
            try
            {
                foreach (PropertyInfo lSourcePropertyInfo in lSourceType.GetProperties())
                {
                    PropertyInfo lDestinationPropertyInfo = lDestinationType.GetProperty(lSourcePropertyInfo.Name);

                    if (lSourcePropertyInfo.PropertyType.IsClass && lSourcePropertyInfo.PropertyType.Assembly.Equals(lSourceType.Assembly))
                    {
                        object lSourceVal = lSourcePropertyInfo.GetValue(source);
                        if (lSourceVal != null)
                        {
                            object lValue = typeof(Mapper).GetMethod("MapContainingObject", BindingFlags.Instance | BindingFlags.NonPublic).
                                MakeGenericMethod(lDestinationPropertyInfo.PropertyType, lSourcePropertyInfo.PropertyType)
                                .Invoke(this, new object[] { lSourceVal, lSourceType.FullName });

                            lDestinationPropertyInfo.SetValue(lDestination, lValue);
                            continue;
                        }
                        lDestinationPropertyInfo.SetValue(lDestination, null);
                        continue;
                    }

                    if (lSourcePropertyInfo.PropertyType.IsAssignableFrom(lDestinationPropertyInfo.PropertyType))
                    {
                        lDestinationPropertyInfo.SetValue(lDestination, lSourcePropertyInfo.GetValue(source));
                        continue;
                    }

                    //if (lSourcePropertyInfo.PropertyType.GetInterface(typeof(IEnumerable<>).Name, true) != null && lSourcePropertyInfo.PropertyType != typeof(string))
                    //{
                    //    Type[] lDestTypeArgs = lDestinationPropertyInfo.PropertyType.GetGenericArguments();
                    //    Type lDestTypeArgsOne = lDestinationPropertyInfo.PropertyType.GetGenericArguments().FirstOrDefault();
                    //    Type[] lSourceTypeArgs = lSourcePropertyInfo.PropertyType.GetGenericArguments();

                    //    lDestinationPropertyInfo.SetValue(lDestination, Activator.CreateInstance(typeof(List<>).MakeGenericType(lDestTypeArgs)));
                    //    MethodInfo lAddToDestinationList = lDestinationPropertyInfo.PropertyType.GetMethod("Add");

                    //    foreach (dynamic item in lSourcePropertyInfo.GetGetMethod().Invoke(source, null) as IEnumerable)
                    //    {
                    //        dynamic lValue = typeof(Mapper).GetMethod("MapContainingObject", BindingFlags.Instance | BindingFlags.NonPublic).
                    //            MakeGenericMethod(lDestTypeArgs.FirstOrDefault(), lSourceTypeArgs.FirstOrDefault())
                    //            .Invoke(this, new dynamic[] { item, lSourceType.FullName });

                    //        var huhu = typeof(Activator).GetMethod("CreateInstance").MakeGenericMethod(lDestTypeArgs).Invoke(this, lValue);

                    //        lAddToDestinationList.Invoke(lDestination, new dynamic[] { lValue });
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
            }
            return lDestination;
        }

        private TDestination MapContainingObject<TDestination, TSource>(TSource source, string initialTypeName)
        {
            Type lSourceType = typeof(TSource);
            Type lDestinationType = typeof(TDestination);

            TDestination lDestination = Activator.CreateInstance<TDestination>();
            try
            {
                foreach (PropertyInfo sourcePropertyInfo in lSourceType.GetProperties())
                {
                    PropertyInfo destinationPropertyInfo = lDestinationType.GetProperty(sourcePropertyInfo.Name);

                    if (sourcePropertyInfo.PropertyType.IsClass
                        && sourcePropertyInfo.PropertyType.Assembly.Equals(lSourceType.Assembly)
                        && !sourcePropertyInfo.PropertyType.FullName.Equals(initialTypeName))
                    {
                        object sourceVal = sourcePropertyInfo.GetValue(source);
                        if (sourceVal != null)
                        {
                            object lValue = typeof(Mapper).GetMethod("MapContainingObject", BindingFlags.Instance | BindingFlags.NonPublic).
                                MakeGenericMethod(destinationPropertyInfo.PropertyType, sourcePropertyInfo.PropertyType)
                                .Invoke(this, new object[] { sourceVal, lSourceType.FullName });

                            destinationPropertyInfo.SetValue(lDestination, lValue);
                            continue;
                        }
                        destinationPropertyInfo.SetValue(lDestination, null);
                        continue;
                    }

                    if (sourcePropertyInfo.PropertyType.IsAssignableFrom(destinationPropertyInfo.PropertyType))
                    {
                        destinationPropertyInfo.SetValue(lDestination, sourcePropertyInfo.GetValue(source));
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return lDestination;
        }
    }
}
