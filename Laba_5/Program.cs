using Laba_2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Laba_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = 11000;
            var end = 53000;
            var n = 9;
            var M = 10;

            var inputRange = new List<int>();
   
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите значения из дипоазона {start}-{end}:");
                var value = Convert.ToInt32(Console.ReadLine());
                if (value >= start && value <= end)
                {
                    inputRange.Add(value);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            inputRange.Print();

            var hashTable = new Hashtable(M);

            for (int i = 0; i < n; i++)
            {
                hashTable.Add(i, inputRange[i]);
            }

            foreach (var item in hashTable.Keys)
            {
                Console.WriteLine($"Key:{item};\tValue:{hashTable[item]}");
            }

            Console.WriteLine("Введите значение для поиска");
            var searchValue = Console.ReadLine();
            Console.WriteLine($"Результат поиска значения \"{searchValue}\":\t" +
                $"{hashTable.ContainsValue(searchValue)}");
        }
    }
}
