using System;
using System.Collections.Generic;

namespace Laba_2
{
    public static class EnumerableExtension
    {
        public static void Print<T>(this IEnumerable<T> enumerable)
        {
            Console.WriteLine($"{string.Join(",", enumerable)}\n");
        }

        public static void Print(this int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
