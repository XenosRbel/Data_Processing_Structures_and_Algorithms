using System;
using System.Collections.Generic;

namespace Laba_6
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Необходимо реализовать очередь на базе списков, применяя комбинированный алгоритм для ее обслуживания. Затем  продемонстрировать выполнение основных операций с элементами очереди: поиск, добавление, удаление.");

            Queue<string> numbers = new Queue<string>();

            Console.WriteLine("Введите размер\n");
            var count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите значение\n");
                var value = Console.ReadLine();
                numbers.Enqueue(value);
            }

            // A queue can be enumerated without disturbing its contents.
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Введите значение для поиска");
            var searchValue = Console.ReadLine();
            Console.WriteLine($"Результат поиска значения \"{searchValue}\":\t" +
                $"{numbers.Contains(searchValue)}");

            numbers.Dequeue();

            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
