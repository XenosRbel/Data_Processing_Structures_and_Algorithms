using System;

namespace Laba_9
{
    partial class Program
    {
        // Прошитое дерево
        public class MyStitchedBinaryTree
        {
            // Основной элемент
            private MyStitchedTree main;

            public MyStitchedTree Main
            {
                get { return Main; }
            }


            // Поиска по значению
            public MyStitchedTree Search(int data)
            {
                if (main != null)
                {
                    return main.Search(data);
                }
                else
                {
                    return null;
                }
            }

            // Рекурсивный способ поиска
            public MyStitchedTree SearchRec(int data)
            {
                if (main != null)
                {
                    // Вызываем рекурсивный способ поиска
                    return main.SearchRec(data);
                }
                else
                {
                    // Или возвращаем пустой
                    return null;
                }
            }

            // Вставки
            public void Add(int data)
            {
                if (main != null)
                {
                    main.Add(data);
                }
                else
                {
                    main = new MyStitchedTree(data);
                }
            }

            // Удаление
            public void Remove(int data)
            {
                MyStitchedTree current = main;
                MyStitchedTree parent = main;

                bool isLeftChild = false;

                // Если элемент пустой, то пустой return
                if (current == null)
                {
                    return;
                }

                // Цикл пока не найдем совпадений
                while (current != null && current.Data != data)
                {
                    // Устанавливаем текущую в настоящую
                    parent = current;

                    if (data < current.Data)
                    {
                        // Устанавливаем в левый блок
                        current = current.LeftUnit;
                        isLeftChild = true;
                    }
                    else
                    {
                        // Устанавливаем в правый блок
                        current = current.RightUnit;
                        isLeftChild = false;
                    }
                }

                if (current == null)
                {
                    return;
                }

                // Если правая и левая ветки пустые
                if (current.RightUnit == null && current.LeftUnit == null)
                {
                    // Если текущая равна основной
                    if (current == main)
                    {
                        main = null;
                    }
                    else
                    {
                        // Если это левая ветка
                        if (isLeftChild)
                        {
                            // Удаляем левый блок
                            parent.LeftUnit = null;
                        }
                        else
                        {
                            // Удаляем правый блок
                            parent.RightUnit = null;
                        }
                    }
                }
                else if (current.RightUnit == null)
                {
                    // Если текущее значение равно основному
                    if (current == main)
                    {
                        // Основному присваивается левая ветвь
                        main = current.LeftUnit;
                    }
                    else
                    {
                        if (isLeftChild)
                        {
                            // Если это левый 
                            parent.LeftUnit = current.LeftUnit;
                        }
                        else
                        {
                            // Присваиваем правму блоку левую ветвь
                            parent.RightUnit = current.LeftUnit;
                        }
                    }
                }
                else if (current.LeftUnit == null)
                {
                    if (current == main)
                    {
                        main = current.RightUnit;
                    }
                    else
                    {
                        if (isLeftChild)
                        {
                            parent.LeftUnit = current.LeftUnit;
                        }
                        else
                        {
                            parent.RightUnit = current.RightUnit;
                        }
                    }
                }
                else
                {
                    MyStitchedTree successor = GetSuccessor(current);
                    if (current == main)
                    {
                        main = successor;
                    }
                    else if (isLeftChild)
                    {
                        parent.LeftUnit = successor;
                    }
                    else
                    {
                        parent.RightUnit = successor;
                    }
                }
            }

            private MyStitchedTree GetSuccessor(MyStitchedTree node)
            {
                MyStitchedTree parentOfSuccessor = node;

                MyStitchedTree successor = node;

                MyStitchedTree current = node.RightUnit;

                while (current != null)
                {
                    parentOfSuccessor = successor;
                    successor = current;
                    current = current.LeftUnit;
                }

                if (successor != node.RightUnit)
                {
                    parentOfSuccessor.LeftUnit = successor.RightUnit;
                    successor.RightUnit = node.RightUnit;
                }

                successor.LeftUnit = node.LeftUnit;

                return successor;
            }

            public void SoftDelete(int data)
            {
                MyStitchedTree toDelete = Search(data);
                if (toDelete != null)
                {
                    toDelete.Delete();
                }
            }

            public Nullable<int> Smallest()
            {
                if (main != null)
                {
                    return main.MinValue();
                }
                else
                {
                    return null;
                }
            }

            public Nullable<int> Largest()
            {
                if (main != null)
                {
                    return main.MaxValue();
                }
                else
                {
                    return null;
                }
            }

            public void InOrderTraversal()
            {
                if (main != null)
                {
                    main.InOrderTraversal();
                }
            }


            public void PreorderTraversal()
            {
                if (main != null)
                {
                    main.PreOrderTraversal();
                }
            }

            public void PostorderTraversal()
            {
                if (main != null)
                {
                    main.PostorderTraversal();
                }
            }

            public int NumberOfLeafNodes()
            {
                if (main == null)
                {
                    return 0;
                }

                return main.NumberOfLeafNodes();
            }

            public int Height()
            {
                if (main == null)
                {
                    return 0;
                }

                return main.Height();
            }

            public bool IsBalanced()
            {
                if (main == null)
                {
                    return true;
                }

                return main.IsBalanced();
            }

        }
    }
}
