using System;

namespace Laba_8
{
	class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();

            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(1);
            binaryTree.Add(6);
            binaryTree.Add(4);
            binaryTree.Add(7);
            binaryTree.Add(14);
            binaryTree.Add(16);
            binaryTree.Add(5);
            Console.WriteLine("Наше дерево");
            binaryTree.PrintTree();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Добавление 9");
            binaryTree.Add(9);
            binaryTree.PrintTree();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Удаление 7");
            binaryTree.Remove(7);
            binaryTree.PrintTree();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Поиск значения 14");
            if (binaryTree.FindNode(14) != null)
            {
                Console.WriteLine("Значение есть");
            }
            else Console.WriteLine("Значения нет");
            Console.ReadLine();
        }
    }
}
