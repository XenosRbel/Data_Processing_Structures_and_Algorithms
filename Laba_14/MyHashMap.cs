using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Laba_14
{
	partial class Program
	{
		public class MyHashMap<K, V>
        {
            private Dictionary<int, IList<HashMap<K, V>>> _hashMaps = null;

            public IReadOnlyCollection<KeyValuePair<int, IList<HashMap<K, V>>>> HashMaps => _hashMaps?.ToList()?.AsReadOnly();

            public MyHashMap()
            {
                // Инициализируем словарь
                _hashMaps = new Dictionary<int, IList<HashMap<K, V>>>();
            }

            // Метод добавления новых значений в хеш-таблицу
            public void Add(K key, V value)
            {
                // Создаём новый элемент
                var newHashMapItem = new HashMap<K, V>(key, value);

                // Создаём новый хеш ключа
                var newHashMapHash = GetHash(key);

                List<HashMap<K, V>> newHashMapList = new List<HashMap<K, V>>();

                if (_hashMaps.ContainsKey(newHashMapHash))
                {
                    // Находим старый элемент с существующим хешем
                    newHashMapList = _hashMaps[newHashMapHash]?.ToList();

                    // Пытаемся найти старый элемент среди списка с существующим ключом
                    var oldItemWithTheSameKey = newHashMapList.SingleOrDefault(value => EqualityComparer<K>.Default.Equals(value.Key, key));

                    // Если такой ключ уже существует, то вызываем ошибку и не добавляем значение
                    if (oldItemWithTheSameKey != null)
                    {
                        throw new ArgumentException($"Ключ должен быть уникален!: ", nameof(key));
                    }

                    // Добавляем в существующий элемент словаря новое значение с уникальным ключом
                    _hashMaps[newHashMapHash].Add(newHashMapItem);
                }
                else
                {
                    // Создаем новый элемент словаря с уникальным ключом
                    newHashMapList = new List<HashMap<K, V>> { newHashMapItem };
                    _hashMaps.Add(newHashMapHash, newHashMapList);
                }
            }

            // Метод для удаления по ключу
            public void Delete(K key)
            {
                var hash = GetHash(key);

                if (!_hashMaps.ContainsKey(hash))
                {
                    throw new KeyNotFoundException($"Такого ключа нет: {nameof(key)}");
                }

                var oldHashTable = _hashMaps[hash];

                var item = oldHashTable.SingleOrDefault(item => EqualityComparer<K>.Default.Equals(item.Key, key));

                // Если элемент найден, то удаляем
                if (item != null)
                {
                    oldHashTable.Remove(item);
                }
            }

            public V Search(K key)
            {
                var hash = GetHash(key);

                if (!_hashMaps.ContainsKey(hash))
                {
                    throw new KeyNotFoundException($"There is no such key: {nameof(key)}");
                }

                var oldHashTable = _hashMaps[hash];

                if (oldHashTable != null)
                {
                    var item = oldHashTable.SingleOrDefault(item => EqualityComparer<K>.Default.Equals(item.Key, key));

                    if (item != null)
                    {
                        return item.Value;
                    }
                }

                // Возвращаем пустое значение
                return default(V);
            }

            public int GetHash(K key)
            {
                return key.ToString().Length;
            }

            public void ShowHashTable(MyHashMap<K, V> hashTable, string title)
            {
                // Проверяем аргументы
                if (hashTable == null)
                {
                    throw new ArgumentNullException(nameof(hashTable));
                }

                if (string.IsNullOrEmpty(title))
                {
                    throw new ArgumentNullException(nameof(title));
                }

                var output = new List<string>();
                foreach (var hashMaps in hashTable.HashMaps)
                {
                    // Выводим все значения хранимые под этим хешем.
                    foreach (var value in hashMaps.Value)
                    {
                        Console.WriteLine($"\t{value.Key} - {value.Value}");
                        output.Add($"\t{value.Key} - {value.Value}");
                    }
                }
                File.WriteAllLines("output.txt", output);
                Console.WriteLine();
            }
        }
    }
}
