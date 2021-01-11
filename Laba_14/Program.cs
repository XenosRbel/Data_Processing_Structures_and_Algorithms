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
            TestDictionary.Add(1, "Petrushka");
            TestDictionary.Add(2, "Morkovka");
            TestDictionary.Add(3, "Svekla");
            TestDictionary.Add(4, "Lyk");
            TestDictionary.Add(5, "Basilik");
            TestDictionary.Add(6, "Kartoshka");

            // Выводим хешированную таблицу
            Console.WriteLine("Изначальная таблица: ");
            TestDictionary.ShowHashTable(TestDictionary, "nameTable");

            // Ищем по ключу (Basilik)
            Console.WriteLine($"Результат поиска по ключу (5): {TestDictionary.Search(5)}\n");

            // Удаляем значение с ключом (1)
            TestDictionary.Delete(1);

            // Результат после удаления
            Console.WriteLine("Результат после удаления: ");
            TestDictionary.ShowHashTable(TestDictionary, "nameTable");
        }
    }
}
