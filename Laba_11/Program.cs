﻿using System;

namespace Laba_11
{// Класс AVLTreeNode реализует один узел АВЛ дерева 
	class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> Oak = new AVLTree<int>();
            //                                            10                              10                                             
            Oak.Add(10);  //                            /   \                           /   \
            Oak.Add(3);   //                           /     \                         /     \
            Oak.Add(2);   //                          3      12      ====>            3       15
            Oak.Add(4);   //                         / \     / \                     / \      / \
            Oak.Add(12);  //                        2   4  null 15                  2   4    12  25
            Oak.Add(15);  //                                      \              
            Oak.Add(11);  //                                       25
            Oak.Add(25);  //
            Console.WriteLine("Дерево");
            foreach (var item in Oak)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Введите элемент для поиска");

            if (Oak.Contains(Convert.ToInt32(Console.ReadLine())))
            {
                Console.WriteLine("Элемент присутсвует");
            }
            else Console.WriteLine("Элемент отсутсвует");
            Console.WriteLine("Введите элемент на удаление");
            Oak.Remove(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Дерево");
            foreach (var item in Oak)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
