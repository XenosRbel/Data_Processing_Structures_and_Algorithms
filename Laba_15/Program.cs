using System;
using System.Collections.Generic;

namespace Laba_15
{
	partial class Program
	{
		static void Main(string[] args)
		{
            // Ключи
            //var testKeyData = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 120 };
            var testKeyData = new List<int>();
            // Указатели
            var testPointerData = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Создание дерева
            var BT = new BTree<int, int>(2);

			Console.WriteLine("Ввод значений дерева");
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("Введите целое значение");
                var item = Convert.ToInt32(Console.ReadLine());
                testKeyData.Add(item);
            }

            for (var i = 0; i < testKeyData.Count; i++)
            {
                // Добавление всех значений из массивов.
                BT.Insert(testKeyData[i], testPointerData[i]);
            }

            PrintTree(BT, "Начальное дерево: ");

            BT.Delete(10);

            PrintTree(BT, "\nДерево после удаления 10 элемента: ");
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
