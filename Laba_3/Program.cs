using System;

namespace Laba_3
{
    class Program
    {
        static void Main(string[] args)
        {
			var doubleLinkedList = FillList();

			doubleLinkedList.PrintDoubleLinkedList();

			var evenLinkedList = doubleLinkedList.GetEvenLinkedList();
			var oddLinkedList = doubleLinkedList.GetOddLinkedList();

            Console.WriteLine();

			evenLinkedList.PrintCircleDoubleLinkedList();

            Console.WriteLine();

			oddLinkedList.PrintCircleDoubleLinkedList();
			Console.ReadKey();
		}

		private static DoubleLinkedList FillList()
		{
			var doubleLinkedList = new DoubleLinkedList();
			Console.WriteLine("Сколько добавить элементов в лист?\nВведите число элементов:");
			var itemCount = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < itemCount; i++)
			{
				Console.WriteLine("Введите элемент (число):\n");
				var item = Convert.ToInt32(Console.ReadLine());
				doubleLinkedList.Add(item);
			}

			return doubleLinkedList;
		}
	}
}
