using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] lNumberMatrix = new int[4, 4] { { 61, 5, 66, 8 }, { 17, 8, 92, 27 }, { 27, 32, 43, 5 }, { 64, 32, 64, 85 } };
            string[,] lTextMatrix = new string[4, 4] { { "61", "5", "66", "8" }, { "17", "8", "92", "27" }, { "27", "32", "43", "5" }, { "64", "32", "64", "85" } };

            HashSet<int> lDublicateNumbers = LinearSearch<int>.FindDublicatesInMatrix(lNumberMatrix);
            HashSet<string> lDublicateText = LinearSearch<string>.FindDublicatesInMatrix(lTextMatrix);

            Print(lDublicateNumbers);
            Print(lDublicateText);

            Console.ReadLine();
        }

        static void Print<T>(IEnumerable<T> set)
        {
            foreach (T item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}