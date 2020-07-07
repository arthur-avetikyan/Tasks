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
            int[,] lMatrix = new int[4, 4] { { 61, 5, 66, 8 }, { 17, 8, 92, 27 }, { 27, 32, 43, 5 }, { 64, 32, 64, 85 } };

            HashSet<int> lDublicates = SearchWithLoops<int>.FindDublicatesInMatrix(lMatrix);

            foreach (int item in lDublicates)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
