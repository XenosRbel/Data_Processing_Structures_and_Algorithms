using System;
using System.IO;

namespace Laba_14
{
	partial class Program
	{
		static void Main(string[] args)
		{
            // Инициилизируем хеш таблицу
            MyHashMap<int, string> TestDictionary = new MyHashMap<int, string>();

            var lines = File.ReadAllLines("input.txt");
			// Добавим слова
			for (int i = 0; i < lines.Length; i++)
			{
                TestDictionary.Add(i, lines[i]);
            }

            // Выводим хешированную таблицу
            Console.WriteLine("Изначальная таблица: ");
            TestDictionary.ShowHashTable(TestDictionary, "nameTable");

			// Ищем по ключу (Basilik)
			Console.WriteLine("Введите ключ значения");
            var key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Результат поиска по ключу ({key}): {TestDictionary.Search(key)}\n");

            // Удаляем значение с ключом (1)
            Console.WriteLine("Введите ключ значения для удаления");
            key = Convert.ToInt32(Console.ReadLine());
            TestDictionary.Delete(key);

            // Результат после удаления
            Console.WriteLine("Результат после удаления: ");
            TestDictionary.ShowHashTable(TestDictionary, "nameTable");
        }
    }
}
