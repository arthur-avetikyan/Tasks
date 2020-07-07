using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class SearchWithLoops<T>
    {
        public static HashSet<T> FindDublicatesInMatrix(T[,] lMatrix)
        {
            HashSet<T> lDublicates = new HashSet<T>();
            HashSet<T> lUniques = new HashSet<T>();
            for (int rowIndex = 0; rowIndex < lMatrix.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < lMatrix.GetLength(1); columnIndex++)
                {
                    CheckIfMatch(lMatrix, lDublicates, lUniques, rowIndex, columnIndex);
                }
            }
            return lDublicates;
        }

        private static void CheckIfMatch(T[,] lMatrix, HashSet<T> lDublicates, HashSet<T> lUniques, int rowIndex, int columnIndex)
        {
            if (!lUniques.Add(lMatrix[rowIndex, columnIndex]))
                lDublicates.Add(lMatrix[rowIndex, columnIndex]);
        }
    }
}
