﻿using System;

namespace Laba_8
{
	class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Ввести 10-15 целых чисел и  построить из них с помощью указателей бинарное дерево поиска. Обойти его прямым, симметричным и обратным способами. Реализовать процедуры поиска, вставки и удаления элементов  бинарного дерева поиска.");

            var binaryTree = new BinaryTree<int>();

            // Заполняем дерево значениями
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Введите целое число");
                var item = Convert.ToInt32(Console.ReadLine());
                binaryTree.Add(item);
            }

            //binaryTree.Add(8);
            //binaryTree.Add(3);
            //binaryTree.Add(10);
            //binaryTree.Add(1);
            //binaryTree.Add(6);
            //binaryTree.Add(4);
            //binaryTree.Add(7);
            //binaryTree.Add(14);
            //binaryTree.Add(16);
            //binaryTree.Add(5);
            Console.WriteLine("Наше дерево");
            binaryTree.PrintTree();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Добавление 9");
            binaryTree.Add(9);
            binaryTree.PrintTree();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Удаление значения. \n Введите значение");
            var itemForRemove = Convert.ToInt32(Console.ReadLine());
            binaryTree.Remove(itemForRemove);
            binaryTree.PrintTree();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Поиск значения.  \n Введите значение");
            var itemForSearch = Convert.ToInt32(Console.ReadLine());
            if (binaryTree.FindNode(itemForSearch) != null)
            {
                Console.WriteLine("Значение есть");
            }
            else Console.WriteLine("Значения нет");
            Console.ReadLine();
        }
    }
}
