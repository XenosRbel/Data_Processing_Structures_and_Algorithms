using System;

namespace Laba_9
{
	partial class Program
	{
		// Прошитая структура дерева дерево 
		public class MyStitchedTree
        {
            // Данные
            private int data;
            public int Data
            {
                get { return data; }
            }

            // Левый блок
            private MyStitchedTree leftUnit;
            public MyStitchedTree LeftUnit
            {
                get { return leftUnit; }
                set { leftUnit = value; }
            }

            // Правый блок
            private MyStitchedTree rightUnit;
            public MyStitchedTree RightUnit
            {
                get { return rightUnit; }
                set { rightUnit = value; }
            }

            // Bool удаления (true | false)
            private bool isDeleted;
            public bool IsDeleted
            {
                get { return isDeleted; }
            }

            // Конструктор
            public MyStitchedTree(int value)
            {
                data = value;
            }

            // Удаления
            public void Delete()
            {
                isDeleted = true;
            }

            // Поиск прямой
            public MyStitchedTree Search(int value)
            {
                MyStitchedTree thisEl = this;

                while (thisEl != null)
                {
                    if (value == this.data && isDeleted == false)
                    {
                        return thisEl;
                    }
                    else if (value > thisEl.data)
                    {
                        thisEl = thisEl.rightUnit;
                    }
                    else
                    {
                        thisEl = thisEl.leftUnit;
                    }
                }

                return null;
            }

            // Поиск рекурсивный
            public MyStitchedTree SearchRec(int value)
            {
                if (value == data && isDeleted == false)
                {
                    return this;
                }
                else if (value < data && leftUnit != null)
                {
                    return leftUnit.SearchRec(value);
                }
                else if (rightUnit != null)
                {
                    return rightUnit.SearchRec(value);
                }
                else
                {
                    return null;
                }
            }

            // Добавления значений
            public void Add(int value)
            {
                if (value >= data)
                {
                    if (rightUnit == null)
                    {
                        rightUnit = new MyStitchedTree(value);
                    }
                    else
                    {
                        rightUnit.Add(value);
                    }
                }
                else
                {
                    if (leftUnit == null)
                    {
                        leftUnit = new MyStitchedTree(value);
                    }
                    else
                    {
                        leftUnit.Add(value);
                    }
                }
            }

            // Ищем наименьшее значение
            public Nullable<int> MinValue()
            {
                // Когда достигем левого блока - возвращаем значение или продолжаем выбирать наименьшее значение левого блока
                if (leftUnit == null)
                {
                    return data;
                }
                else
                {
                    return leftUnit.MinValue();
                }
            }

            // Ищем наибольшее значение
            internal Nullable<int> MaxValue()
            {
                if (rightUnit == null)
                {
                    return data;
                }
                else
                {
                    return rightUnit.MaxValue();
                }
            }

            public void InOrderTraversal()
            {
                if (leftUnit != null)
                {
                    leftUnit.InOrderTraversal();
                }

                Console.Write(data + " ");

                if (rightUnit != null)
                {
                    rightUnit.InOrderTraversal();
                }
            }

            public void PreOrderTraversal()
            {
                Console.Write(data + " ");

                if (leftUnit != null)
                {
                    leftUnit.PreOrderTraversal();
                }

                if (rightUnit != null)
                {
                    rightUnit.PreOrderTraversal();
                }
            }

            public void PostorderTraversal()
            {
                if (leftUnit != null)
                {
                    leftUnit.PostorderTraversal();
                }

                if (rightUnit != null)
                {
                    rightUnit.PostorderTraversal();
                }

                Console.Write(data + " ");
            }


            public int Height()
            {
                if (this.leftUnit == null && this.rightUnit == null)
                {
                    return 1;
                }

                int left = 0;
                int right = 0;

                if (this.leftUnit != null)
                {
                    left = this.leftUnit.Height();
                }

                if (this.rightUnit != null)
                {
                    right = this.rightUnit.Height();
                }

                if (left > right)
                {
                    return (left + 1);
                }
                else
                {
                    return (right + 1);
                }
            }

            public int NumberOfLeafNodes()
            {
                if (this.leftUnit == null && this.rightUnit == null)
                {
                    return 1;
                }

                int leftLeaves = 0;
                int rightLeaves = 0;

                if (this.leftUnit != null)
                {
                    leftLeaves = leftUnit.NumberOfLeafNodes();
                }

                if (this.rightUnit != null)
                {
                    rightLeaves = rightUnit.NumberOfLeafNodes();
                }

                return leftLeaves + rightLeaves;
            }

            public bool IsBalanced()
            {
                int LeftHeight = LeftUnit != null ? LeftUnit.Height() : 0;
                int RightHeight = RightUnit != null ? RightUnit.Height() : 0;

                int heightDifference = LeftHeight - RightHeight;

                if (Math.Abs(heightDifference) > 1)
                {
                    return false;
                }
                else
                {
                    return ((LeftUnit != null ? LeftUnit.IsBalanced() : true) && (RightUnit != null ? RightUnit.IsBalanced() : true));
                }
            }
        }
    }

}
}
