using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Laba_15
{
	partial class Program
	{
        private const string BTreeFilePath = "B-Tree.txt";

		static void Main(string[] args)
		{
            var fileLines = string.Empty;

            var assembly = typeof(Program).GetTypeInfo().Assembly;
            var pathToFile = GetResourcePath(assembly);

            using (var stream = assembly.GetManifestResourceStream(pathToFile))
            using (var reader = new StreamReader(stream))
            {
                fileLines = reader.ReadToEnd();
            }

            var bTreeItems = new List<BTreeItem>();
            var delimeters = new string[] { "\r\n", "\n", "\r" };
            var treeData = fileLines.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

			foreach (var line in treeData)
			{
                var delimeterindex = line.IndexOf(':');
                var bindex = Convert.ToInt32(string.Join("", line.Take(delimeterindex)));
                var values = line.Substring(delimeterindex, line.Length - delimeterindex)
                    .TrimStart(':')
                    .TrimStart(' ')
                    .TrimEnd(' ')
                    .Split(' ')
                    .Select(item => Convert.ToInt32(item))
                    .ToArray();

                var itemB = new BTreeItem {Index = bindex, Values =  values};
                bTreeItems.Add(itemB);
            }

            // Создание дерева
            var BT = new BTree<int, int>(5);

			Console.WriteLine("Ввод значений дерева. Сколько элементов загрузить? (От 10 до 15)");
            var N = Convert.ToInt32(Console.ReadLine());
            var bTreeSize = bTreeItems.Sum(item => item.Values.Length);
			Console.WriteLine($"{(N <= bTreeSize ? "Размер верный" : "Ошибка размера")}");

			if (N <= bTreeSize)
			{
				for (int i = 0; i < bTreeItems.Count; i++)
				{
                    var item = bTreeItems[i];
                    var values = item.Values;

                    for (int j = 0; j < values.Length; j++)
					{
                        var value = values[j];

                        BT.Insert(value, item.Index);
                    }
				}				

                PrintTree(BT, "Начальное дерево: ");

                Console.WriteLine("Введите элемент для добавления");
                var forInsert = Convert.ToInt32(Console.ReadLine());
                BT.Insert(forInsert, 1);
                PrintTree(BT, "Начальное дерево: ");

                Console.WriteLine("Введите элемент для добавления");
                forInsert = Convert.ToInt32(Console.ReadLine());
                BT.Insert(forInsert, 1);
                PrintTree(BT, "Начальное дерево: ");

                Console.WriteLine("Введите элемент для удаления");
                var forDel = Convert.ToInt32(Console.ReadLine());
                BT.Delete(forDel);
                PrintTree(BT, $"\nДерево после удаления {forDel} элемента: ");             
            }         
        }

        // Вывод дерева
        static void PrintTree(BTree<int, int> tree, string title = null)
        {
            if (title != null)
            {
                Console.WriteLine(title);
            }

            tree.PrintTree(tree.Root);
        }

        public static IList<int> GetRandomIntList(int listSize, int minValue, int maxValue)
        {
            var rnd = new Random();
            return Enumerable.Range(0, listSize)
                .Select(value => rnd.Next(minValue, maxValue))
                .ToList();
        }

        private static string GetResourcePath(Assembly assembly)
        {
            var assemblyPrefix = assembly.GetName().Name;
            return $"{assemblyPrefix}.{BTreeFilePath}";
        }
    }
}
