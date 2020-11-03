using System;
using System.Collections.Generic;

namespace Laba_2
{
    class Program
    {
        static void Main(string[] args)
        {
			new Task1().Execute();
		}

		class Task1
        {
			public void Execute()
			{
				Console.WriteLine($"{this.GetType().FullName}\n");

				var linkedList = FillList();

				Console.WriteLine($"Исходный список:\t{string.Join(" ", linkedList)}");

				var evenList = CreateLinkedListWithOnlyEvenItems(linkedList);
				Console.WriteLine($"Исходный список EVEN:\t{string.Join(" ", evenList)}");

				var oddList = CreateLinkedListWithOnlyOddItems(linkedList);
				Console.WriteLine($"Исходный список ODD:\t{string.Join(" ", oddList)}");
			}

			private LinkedList<int> FillList()
			{
				var linkedList = new LinkedList<int>();
                Console.WriteLine("Сколько добавить элементов в лист?\nВведите число элементов:");
				var itemCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < itemCount; i++)
                {
                    Console.WriteLine("Введите элемент (число):\n");
					var item = Convert.ToInt32(Console.ReadLine());
					linkedList.Add(item);
                }

				return linkedList;
			}

			public LinkedList<int> CreateLinkedListWithOnlyEvenItems(LinkedList<int> list)
			{
				var newList = new LinkedList<int>();

				for (int i = 0; i < list.Count; i++)
				{
					var item = list.GetByIndex(i);

					if (item.IsEven())
					{
						newList.Add(item);
					}
				}
				return newList;
			}

			public LinkedList<int> CreateLinkedListWithOnlyOddItems(LinkedList<int> list)
			{
				var newList = new LinkedList<int>();

				for (int i = 0; i < list.Count; i++)
				{
					var item = list.GetByIndex(i);

					if (!item.IsEven())
					{
						newList.Add(item);
					}
				}
				return newList;
			}

			public void RemoveEachSecondElem(LinkedList<int> ts)
			{
				var failedItem = new List<int>();

				for (int i = 0; i < ts.Count; i++)
				{
					if ((i + 1) % 2 == 0)
					{
						var val = ts.GetByIndex(i);
						failedItem.Add(val);
					}
				}

				for (int i = 0; i < failedItem.Count; i++)
				{
					ts.Remove(failedItem[i]);

					Console.WriteLine(string.Join(" ", ts));
				}
			}
		}
	}
}
