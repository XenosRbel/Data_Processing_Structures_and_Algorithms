using System;

namespace Laba_12
{
    class Program
    {
 
        static void Main(string[] args)
        {
			Console.WriteLine("Введите размерность от 7-10");
            int N = Convert.ToInt32(Console.ReadLine());
            int[,] graf = RandomFillMatrix(N, N, 0, 2);

            Console.WriteLine("Пути в графе");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (graf[i, j] == 1)
                    {
                        Console.Write($"{i + 1}-{j + 1}\t");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Выберите вершину от 1 до {N}");
            int v = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine($"Смежные вершины с вершиной {v + 1}");
            for (int i = 0; i < N; i++)
            {
                if (graf[i, v] == 1)
                {
                    Console.Write($"{i + 1}\t");
                }
            }
            for (int i = 0; i < N; i++)
            {
                if (graf[v, i] == 1)
                {
                    Console.Write($"{i + 1}\t");
                }
            }
            Console.WriteLine($"\nСписок вершин из которых можно попасть в вершину {v + 1}");
            for (int i = 0; i < N; i++)
            {
                if (graf[i, v] == 1)
                {
                    Console.Write($"{i + 1}\t");
                }
            }
            Console.WriteLine($"\nИндексы смежных вершин с вершиной {v + 1}");
            for (int i = 0; i < N; i++)
            {
                if (graf[i, v] == 1)
                {
                    Console.Write($"{i}\t");
                }
            }
            for (int i = 0; i < N; i++)
            {
                if (graf[v, i] == 1)
                {
                    Console.Write($"{i}\t");
                }
            }
            Console.WriteLine("\nВыберите индекс интересующей вершины");
            Console.WriteLine($"Номер вершины = {Convert.ToInt32(Console.ReadLine()) + 1} ");
            Console.ReadKey();
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
}
