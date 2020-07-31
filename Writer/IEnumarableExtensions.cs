using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    public static class IEnumarableExtensions
    {
        public static void Do<T>(this IEnumerable<T> collection)
        {

            int lSize = 0;
            Type lType = typeof(T);
            Console.WriteLine($"The type of the item is: {lType}");
            foreach (T item in collection)
            {
                if (lType.IsPrimitive || lType.IsAssignableFrom(typeof(decimal)))
                {
                    lSize += Marshal.SizeOf<T>();
                }
                else
                {
                    Console.WriteLine("Cannot obtain size of the collection.");
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine($"The size of the collection is {lSize} bytes");
            Console.WriteLine();
        }
    }
}
