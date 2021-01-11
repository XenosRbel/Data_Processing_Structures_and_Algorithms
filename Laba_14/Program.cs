using System;

namespace Laba_14
{
	partial class Program
	{
		static void Main(string[] args)
		{
            // Инициилизируем хеш таблицу
            MyHashMap<int, string> TestDictionary = new MyHashMap<int, string>();

			// Добавим слова
			Console.WriteLine("Добавим 5 слов");
			for (int i = 1; i < 5; i++)
			{
				Console.WriteLine("Введите слово");
                var item = Console.ReadLine();
                TestDictionary.Add(i, item);
            }
            //TestDictionary.Add(1, "Petrushka");
            //TestDictionary.Add(2, "Morkovka");
            //TestDictionary.Add(3, "Svekla");
            //TestDictionary.Add(4, "Lyk");
            //TestDictionary.Add(5, "Basilik");
            //TestDictionary.Add(6, "Kartoshka");

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
