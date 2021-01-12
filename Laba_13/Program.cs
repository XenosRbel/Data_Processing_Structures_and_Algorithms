using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba_13
{
	partial class Program
	{
		static void Main(string[] args)
		{
            var n01 = new Node("1");
            var n02 = new Node("2");
            var n03 = new Node("3");
            var n04 = new Node("4");
            var n05 = new Node("5");
            var n06 = new Node("6");
            var n07 = new Node("7");
            var n08 = new Node("8");
            var n09 = new Node("9");
            var n10 = new Node("10");
            var n11 = new Node("11");
            var n12 = new Node("12");
            var n13 = new Node("13");
            var n14 = new Node("14");
            var n15 = new Node("15");

            // Добавляем потомка.
            n01.AddChildren(n02).AddChildren(n03);
            n02.AddChildren(n05);
            n03.AddChildren(n04);
            n04.AddChildren(n05, false).AddChildren(n10, false).AddChildren(n11, false);
            n06.AddChildren(n01, false);
            n07.AddChildren(n03, false).AddChildren(n08);
            n09.AddChildren(n08).AddChildren(n10);
            n11.AddChildren(n12).AddChildren(n13);
            n12.AddChildren(n13);
            n14.AddChildren(n15);

            var ss = new List<Node> { n01, n02, n03, n04, n05, n06, n07, n08, n09, n10, n11, n12, n13, n14, n15 };
            var search = new DepthFirstSearch();

			Console.WriteLine("Укажите вершину-источник");
            var verh = Console.ReadLine();

            var path = search.DLS(ss.First(item => item.Name == verh), n13, 6);
            PrintPath(path);
        }

        private static void PrintPath(LinkedList<Node> path)
        {
            Console.WriteLine();
            if (path.Count == 0)
            {
                Console.WriteLine("Ты не пройдешь");
            }
            else
            {
                Console.WriteLine(string.Join(" -> ", path.Select(x => x.Name)));
            }
            Console.Read();
        }
    }
}
