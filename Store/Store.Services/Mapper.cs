using Store.IServices;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;

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
                foreach (PropertyInfo sourcePropertyInfo in lSourceType.GetProperties())
                {
                    PropertyInfo destinationPropertyInfo = lDestinationType.GetProperty($"{sourcePropertyInfo.Name}");

                    if (sourcePropertyInfo.PropertyType.IsClass && sourcePropertyInfo.PropertyType.Assembly.Equals(lSourceType.Assembly))
                    {
                        object sourceVal = sourcePropertyInfo.GetValue(source);
                        if (sourceVal != null)
                        {
                            var lValue = typeof(Mapper).GetMethod("MapContainingObject", BindingFlags.Instance | BindingFlags.NonPublic).
                                MakeGenericMethod(destinationPropertyInfo.PropertyType, sourcePropertyInfo.PropertyType)
                                .Invoke(this, new object[] { sourceVal, lSourceType.FullName });

                            destinationPropertyInfo.SetValue(lDestination, lValue);
                            continue;
                        }
                        destinationPropertyInfo.SetValue(lDestination, null);
                        continue;
                    }

                    if (sourcePropertyInfo.PropertyType.IsAssignableFrom(destinationPropertyInfo.PropertyType))
                        destinationPropertyInfo.SetValue(lDestination, sourcePropertyInfo.GetValue(source));
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
                    PropertyInfo destinationPropertyInfo = lDestinationType.GetProperty($"{sourcePropertyInfo.Name}");

                    if (sourcePropertyInfo.PropertyType.IsClass
                        && sourcePropertyInfo.PropertyType.Assembly.Equals(lSourceType.Assembly)
                        && !sourcePropertyInfo.PropertyType.FullName.Equals(initialTypeName))
                    {
                        object sourceVal = sourcePropertyInfo.GetValue(source);
                        if (sourceVal != null)
                        {
                            var lValue = typeof(Mapper).GetMethod("MapContainingObject", BindingFlags.Instance | BindingFlags.NonPublic).
                                MakeGenericMethod(destinationPropertyInfo.PropertyType, sourcePropertyInfo.PropertyType)
                                .Invoke(this, new object[] { sourceVal, lSourceType.FullName });

                            destinationPropertyInfo.SetValue(lDestination, val);
                            continue;
                        }
                        destinationPropertyInfo.SetValue(lDestination, null);
                        continue;
                    }

                    if (sourcePropertyInfo.PropertyType.IsAssignableFrom(destinationPropertyInfo.PropertyType))
                        destinationPropertyInfo.SetValue(lDestination, sourcePropertyInfo.GetValue(source));
                }
            }
            catch (Exception ex)
            {
            }
            return lDestination;
        }

    }
}
