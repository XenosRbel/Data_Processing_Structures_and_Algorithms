using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba_13
{
    partial class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Введите размер матрицы от 7 до 10");
            var N = Convert.ToInt32(Console.ReadLine());

            var matrixOfLinked = FillRandomMatrixOfRelationships(N, N, 1, 50);

            int[] d = new int[N];
            int[] v = new int[N]; // посещенные вершины
            int temp, minindex, min;
            int begin_index = 0;
            Console.WriteLine("Алгоритм Дейкстры");
    
            // Выводим матрицу связей
            matrixOfLinked.Print();

            //Инициализируем вершину и расстояние
            for (int i = 0; i < N; i++)
            {
                d[i] = 10000;
                v[i] = 1;
            }
            d[begin_index] = 0;

            do
            {
                minindex = 10000;
                min = 10000;
                for (int i = 0; i < N; i++)
                { // Если вершину ещё не обошли и вес меньше min
                    if ((v[i] == 1) && (d[i] < min))
                    {
                        min = d[i];
                        minindex = i;
                    }
                }
                // Добавляем найденный минимальный вес к текущему и после этого сравниваем минимальный вес с текущей вершиной

                if (minindex != 10000)
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (matrixOfLinked[minindex, i] > 0)
                        {
                            temp = min + matrixOfLinked[minindex, i];
                            if (temp < d[i])
                            {
                                d[i] = temp;
                            }
                        }
                    }
                    v[minindex] = 0;
                }
            } while (minindex < 10000);

            // Вывод кратчайших расстояний до вершин
            Console.Write("\nКратчайшие расстояния до вершин: \n");
            for (int i = 0; i < N; i++)
                Console.Write(d[i] + " ");

            // Восстановление пути
            int[] ver = new int[N];
            int end = 4;
            ver[0] = end + 1;
            int k = 1;
            int weight = d[end];

            while (end != begin_index)
            {
                for (int i = 0; i < N; i++) // просматриваем все вершины
                    if (matrixOfLinked[i, end] != 0)
                    {
                        temp = weight - matrixOfLinked[i, end]; // определяем вес пути из предыдущей вершины
                        if (temp == d[i])
                        {
                            weight = temp; // сохраняем новый вес
                            end = i;       // сохраняем предыдущую вершину
                            ver[k] = i + 1;
                            k++;
                        }
                    }
            }

            // Вывод пути 
            Console.Write("\nКратчайший путь\n");
            for (int i = k - 1; i >= 0; i--)
                Console.Write(ver[i] + " ");



            Console.WriteLine("Алгоритм Флойда");
            int[,] ShortestPath = FillRandomMatrixOfRelationships(N, N, 1, 10);

            int Max_Sum = 0;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    Max_Sum += ShortestPath[i, j];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (ShortestPath[i, j] == 0 && i != j)
                        ShortestPath[i, j] = Max_Sum;
            for (k = 0; k < N; k++)
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < N; j++)
                        if ((ShortestPath[i, k] + ShortestPath[k, j]) <
                             ShortestPath[i, j])
                            ShortestPath[i, j] = ShortestPath[i, k] +
                              ShortestPath[k, j];


            Console.WriteLine("Кратчайшие пути алгоритма Флойда: ");
            Console.WriteLine(" ");
            Console.Write("  ");
            for (int i = 0; i < N; i++)
            {
                Console.Write(" " + (i + 1));
            }
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                Console.Write((i + 1) + "| ");
                for (int j = 0; j < N; j++)
                    Console.Write($"{ShortestPath[i, j]} ");
                Console.WriteLine("\n |");
            }

			Console.WriteLine("Конец работы");
            Console.ReadKey();
        }

        public static int[,] FillRandomMatrixOfRelationships(int n, int m, int minValue, int maxValue)
        {
            var res = new int[n, m];
            var rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                res[i, i] = 0;
                for (int j = i + 1; j < m; j++)
                {
                    var temp = rnd.Next(minValue, maxValue);
                    res[i, j] = temp;
                    res[j, i] = temp;
                }
            }

            return res;
        }

        public static int[,] RandomFillMatrix(int n, int m, int minValue, int maxValue)
        {
            var res = new int[n, m];
            var rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    res[i, j] = rnd.Next(minValue, maxValue);
                }
            }

            return res;
        }       
    }

    static class Utils
	{
        public static void Print(this int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j]}\t");
                Console.WriteLine();
            }
        }
    }
}
