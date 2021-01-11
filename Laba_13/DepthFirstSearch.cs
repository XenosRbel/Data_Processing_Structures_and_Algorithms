using System.Collections.Generic;

namespace Laba_13
{
	partial class Program
	{
		/// <summary>
		/// Класс, отображающий глубокий поиск.
		/// </summary>
		class DepthFirstSearch
        {
            private HashSet<Node> visited;
            private LinkedList<Node> path;
            private Node goal;
            private bool limitWasReached;

            // Алгоритм поиска в глубину.
            public LinkedList<Node> DFS(Node start, Node goal)
            {
                visited = new HashSet<Node>();
                path = new LinkedList<Node>();
                this.goal = goal;
                // Вызываем метод ниже.
                DFS(start);
                if (path.Count > 0)
                {
                    path.AddFirst(start);
                }
                return path;
            }

            // Действие над отдельной ветвью.
            private bool DFS(Node node)
            {
                //пишем в консоль что посетили ноду
                node.Handler();
                // если это не та что мы ищем, заканчиваем поиск
                if (node == goal)
                {
                    return true;
                }
                visited.Add(node);
                //поиск дочерних элементов (которые мы еще не посещали)
                foreach (var child in node.Children.Where(x => !visited.Contains(x)))
                {
                    if (DFS(child)) // рекурсия 
                    {
                        path.AddFirst(child);
                        return true;
                    }
                }
                return false;
            }

            //Поиск с ограничением глубины, отличается только указанием максимальной глубины поиска
            public LinkedList<Node> DLS(Node start, Node goal, int limit)
            {
                visited = new HashSet<Node>();
                path = new LinkedList<Node>();
                limitWasReached = true;
                this.goal = goal;
                DLS(start, limit);
                if (path.Count > 0)
                {
                    path.AddFirst(start);
                }
                return path;
            }
            //действия над отдельной нодой
            private bool DLS(Node node, int limit)
            {
                //пишем в консоль что посетили ноду
                node.Handler();
                // если это не та что мы ищем, заканчиваем поиск
                if (node == goal)
                {
                    return true;
                }
                if (limit == 0)
                {
                    limitWasReached = false;
                    return false;
                }
                visited.Add(node);
                //поиск дочерних элементов (которые мы еще не посещали)
                foreach (var child in node.Children.Where(x => !visited.Contains(x)))
                {
                    if (DLS(child, limit - 1)) // рекурсия 
                    {
                        path.AddFirst(child);
                        return true;
                    }
                }
                return false;
            }
        }

    }
}
