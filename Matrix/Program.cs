using System;
using System.Collections.Generic;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] lNumberMatrix = new int[4, 4] { { 61, 5, 66, 8 }, { 17, 8, 92, 27 }, { 27, 32, 43, 5 }, { 64, 32, 64, 85 } };
            string[,] lTextMatrix = new string[4, 4] { { "61", "5", "66", "8" }, { "17", "8", "92", "27" }, { "27", "32", "43", "5" }, { "64", "32", "64", "85" } };

            HashSet<int> lDublicateNumbersSet = LinearSearch<int>.FindDublicatesInMatrix(lNumberMatrix);
            HashSet<string> lDublicateTextSet = LinearSearch<string>.FindDublicatesInMatrix(lTextMatrix);

            Dictionary<int, string> lDublicateNumbersDic = LinearSearch<int>.FindDublicatesIn2D(lNumberMatrix);
            Dictionary<string, string> lDublicateTextDic = LinearSearch<string>.FindDublicatesIn2D(lTextMatrix);

            PrintDublicateValues(lDublicateNumbersSet);
            PrintDublicateValues(lDublicateTextSet);

            PrintDublicateValues(lDublicateNumbersDic);
            PrintDublicateValues(lDublicateTextDic);

            Console.ReadLine();
        }

        static void PrintDublicateValues<T>(IEnumerable<T> set)
        {
            foreach (T item in set)
            {
                Console.WriteLine(item);
            }
        }

        static void PrintDublicateValues<T>(Dictionary<T, string> set)
        {
            foreach (var item in set)
            {
                if (item.Value.Equals(LinearSearch<T>.dublicate))
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}