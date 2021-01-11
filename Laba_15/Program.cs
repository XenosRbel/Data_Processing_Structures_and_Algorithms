using System;

namespace Laba_15
{
	partial class Program
	{
		static void Main(string[] args)
		{
            // Ключи
            var testKeyData = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Указатели
            var testPointerData = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Создание дерева
            var BT = new BTree<int, int>(2);

            for (var i = 0; i < testKeyData.Length; i++)
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
