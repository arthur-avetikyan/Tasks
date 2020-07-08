using System;
using System.Collections.Generic;

namespace Matrix
{
    public static class LinearSearch<T>
    {
        public const string unicque = "u";
        public const string dublicate = "d";

        public static HashSet<T> FindDublicatesInMatrix(T[,] matrix)
        {
            HashSet<T> lDublicates = new HashSet<T>();
            HashSet<T> lUniques = new HashSet<T>();
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
                {
                    CheckIfMatch(matrix[rowIndex, columnIndex], lDublicates, lUniques);
                }
            }
            return lDublicates;
        }

        private static void CheckIfMatch(T item, HashSet<T> dublicates, HashSet<T> uniques)
        {
            if (!uniques.Add(item))
                dublicates.Add(item);
        }

        public static Dictionary<T, string> FindDublicatesIn2D(T[,] matrix)
        {
            Dictionary<T, string> lDublicates = new Dictionary<T, string>();
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
                {
                    CheckMatches(matrix[rowIndex, columnIndex], lDublicates);
                }
            }
            return lDublicates;
        }

        private static void CheckMatches(T item, Dictionary<T, string> dublicates)
        {
            try
            {
                dublicates.Add(item, unicque);
            }
            catch (ArgumentException)
            {
                dublicates[item] = dublicate;
            }
        }
    }
}