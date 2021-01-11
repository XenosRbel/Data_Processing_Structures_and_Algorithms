using System;
using System.Collections.Generic;

namespace Laba_13
{
	partial class Program
	{
		class Node
        {
            public string Name { get; }
            public List<Node> Children { get; }

            // Ветвь.
            public Node(string name)
            {
                Name = name;
                Children = new List<Node>();
            }

            // Добавление "ребенка" ветви.
            public Node AddChildren(Node node, bool bidirect = true)
            {
                Children.Add(node);
                if (bidirect)
                {
                    node.Children.Add(this);
                }
                return this;
            }

            // Метод отображения посещённой ноды.
            public void Handler()
            {
                Console.WriteLine($"visited {this.Name}");
            }
        }

    }
}
