using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Laba_15
{
	partial class Program
	{
		static void Main(string[] args)
		{
            // Ключи
            var testKeyData = File.ReadAllText("testKeyData.txt").Split(' ');
            //var testKeyData = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 120 };
            //var testKeyData = new List<int>();
            // Указатели
            var testPointerData = File.ReadAllText("testPointerData.txt").Split(' ').Select(item => Convert.ToInt32(item)).ToArray();
            //var testPointerData = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Создание дерева
            var BT = new BTree<int, int>(2);

			Console.WriteLine("Ввод значений дерева. Сколько элементов загрузить? (От 10 до 15)");
            var N = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine($"{(N <= testKeyData.Length ? "Размер верный" : "Ошибка размера")}");

			if (N <= testKeyData.Length)
			{
                for (var i = 0; i < N; i++)
                {
                    // Добавление всех значений из массивов.
                    BT.Insert(Convert.ToInt32(testKeyData[i]), testPointerData[i]);
                }

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
    }
}
