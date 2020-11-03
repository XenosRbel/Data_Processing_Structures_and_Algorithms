using System;

namespace Laba_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем новую хеш таблицу.
            var hashTable = FillTable();

            // Добавляем данные в хеш таблицу в виде пар Ключ-Значение.
            //hashTable.Insert("Little Prince", "I never wished you any sort of harm; but you wanted me to tame you...");
            //hashTable.Insert("Fox", "And now here is my secret, a very simple secret: It is only with the heart that one can see rightly; what is essential is invisible to the eye.");
            //hashTable.Insert("Rose", "Well, I must endure the presence of two or three caterpillars if I wish to become acquainted with the butterflies.");
            //hashTable.Insert("King", "He did not know how the world is simplified for kings. To them, all men are subjects.");

            // Выводим хранимые значения на экран.
            ShowHashTable(hashTable, "Выводим хранимые значения на экран");

            // Получаем хранимое значение из таблицы по ключу.
            Console.WriteLine("Получаем хранимое значение из таблицы по ключу:");
            var value = Console.ReadLine();
            var text = hashTable.Search(value);
            Console.WriteLine(text);

            // Удаляем элемент из хеш таблицы по ключу
            // и выводим измененную таблицу на экран.
            Console.WriteLine("Введите ключ для удаления значения");
            value = Console.ReadLine();
            hashTable.Delete(value);
            ShowHashTable(hashTable, "Delete item from hashtable.");
        }

        private static HashTable FillTable()
        {
            var hashTable = new HashTable();
            Console.WriteLine("Сколько добавить элементов в таблицу?\nВведите число элементов:");
            var itemCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < itemCount; i++)
            {
                Console.WriteLine("Введите ключ (строку):\n");
                var key = Console.ReadLine();

                Console.WriteLine("Введите значение (строку):\n");
                var value = Console.ReadLine();
                hashTable.Insert(key, value);
            }

            return hashTable;

        }
        /// <summary>
        /// Вывод хеш-таблицы на экран.
        /// </summary>
        /// <param name="hashTable"> Хеш таблица. </param>
        /// <param name="title"> Заголовок перед выводом таблицы. </param>
        private static void ShowHashTable(HashTable hashTable, string title)
        {
            // Проверяем входные аргументы.
            if (hashTable == null)
            {
                throw new ArgumentNullException(nameof(hashTable));
            }

            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            // Выводим все имеющие пары хеш-значение
            Console.WriteLine(title);
            foreach (var item in hashTable.Items)
            {
                // Выводим хеш
                Console.WriteLine(item.Key);

                // Выводим все значения хранимые под этим хешем.
                foreach (var value in item.Value)
                {
                    Console.WriteLine($"\t{value.Key} - {value.Value}");
                }
            }
            Console.WriteLine();
        }
    }
}
