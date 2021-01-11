using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba_7
{
   class Program
    {
        static bool TransformationToPostfix(string expression, out string postResult)
        {
            // Инициализируем стек
            Stack<char> stack = new Stack<char>();

            postResult = default(string);

            // Проходим циклом по выражению
            for (int i = 0; i < expression.Length; i++)
            {
                // Символ строки
                char thisEl = expression[i];

                if (thisEl == '(')
                {
                    // Ищем закрывающую скобку
                    var bracketEndIndex = expression.IndexOf(')');

                    // Выбираем строку в скобках
                    var bracketStr = expression.Substring(i + 1, bracketEndIndex - 1);

                    // Для вложенности используем рекурсию
                    TransformationToPostfix(bracketStr, out string postResultCld);

                    // Добавляем результат в expression
                    postResult += postResultCld;

                    // Перенос символа.
                    i = bracketEndIndex;
                }
                else if (thisEl == '*' || thisEl == '/' || thisEl == '+' || thisEl == '-')
                {
                    if (stack.Count <= 0)
                    {
                        // Добавляем знак выражения в стек
                        stack.Push(thisEl);
                    }
                    else
                    {
                        // Если деление или умножение (приоритетнее)
                        if (stack.Peek() == '*' || stack.Peek() == '/')
                        {
                            // Добавляем знак и удаляем элемент из стека
                            postResult += stack.Pop();
                            i--;
                        }
                        else
                        {
                            if (thisEl == '+' || thisEl == '-')
                            {
                                // Добавляем знак и удаляем элемент из стека
                                postResult += stack.Pop();

                            }

                            // Добавляем знак в стек
                            stack.Push(thisEl);
                        }
                    }
                }
                else
                {
                    // Добавляем симовлы в стек
                    postResult += thisEl;
                }
            }

            for (int j = 0; j < stack.Count; j++)
            {
                // Добавляем остальные элементы в стеке в результат
                postResult += stack.Pop();
            }

            return true;
        }

        static void Main(string[] args)
        {
            // Тестовое выражение
            string expression = "(A*B)+C-D";

            // Метод трансформации выражения
            TransformationToPostfix(expression, out string postResult);

            var preResultArr = postResult.ToCharArray();

            // Инвертируем полученное выражение, для получения префиксной формы
            Array.Reverse(preResultArr);

            var preResult = new string(preResultArr);

            // Инфиксное выражение 
            Console.WriteLine("Инфиксное выражение: " + expression);

            // Префиксное выражение
            Console.WriteLine("Префиксное выражение: " + preResult);

            // Постфиксное выражение
            Console.WriteLine(" Постфиксное выражение: " + postResult);
        }
    }
}
