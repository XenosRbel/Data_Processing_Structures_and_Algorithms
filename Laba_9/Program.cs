using System;

namespace Laba_9
{
	partial class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Ввести 10-15 целых чисел и построить из них бинарное дерево поиска." +
				"1.Выполнить симметричную прошивку бинарного дерева поиска.Обойти его согласно симметричному порядку следования элементов.Реализовать вставку и удаление элементов из симметрично прошитого бинарного дерева." +
				"2.Выполнить прямую прошивку бинарного дерева поиска.Обойти его согласно прямому порядку следования элементов.Реализовать вставку и удаление элементов из прямо прошитого бинарного дерева.");

            MyStitchedBinaryTree myStitchedBinaryTree = new MyStitchedBinaryTree();
            // Заполняем дерево значениями'
            Console.WriteLine("Введите целое число для размера");
            var n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
				Console.WriteLine("Введите целое число");
                var item = Convert.ToInt32(Console.ReadLine());
                myStitchedBinaryTree.Add(item);
            }
            Console.WriteLine("Прямой порядок следования элементов: ");
            myStitchedBinaryTree.InOrderTraversal();

            Console.WriteLine("\n\nСимметричный порядок следования элементов: ");
            myStitchedBinaryTree.PreorderTraversal();

            Console.WriteLine("Поиск Удаления. \nВведите элемент");
            var itemForDelete = Convert.ToInt32(Console.ReadLine());
            myStitchedBinaryTree.Remove(itemForDelete);

            Console.WriteLine("\nПрямой порядок следования элементов после удаления:");
            myStitchedBinaryTree.InOrderTraversal();

     
        }

        public static int getHeight(MyStitchedTree main)
        {
            if (main == null)
            {
                return 0;
            }
            return Math.Max(getHeight(main.LeftUnit), getHeight(main.RightUnit)) + 1;
        }

        public static bool isBalanced(MyStitchedTree main)
        {
            if (main == null)
            {
                return true;
            }

            int heightDiff = getHeight(main.LeftUnit) - getHeight(main.RightUnit);

            if (Math.Abs(heightDiff) > 1)
            {
                return false;
            }
            else
            {
                return (isBalanced(main.LeftUnit) && isBalanced(main.RightUnit));
            }
        }
    }
}
