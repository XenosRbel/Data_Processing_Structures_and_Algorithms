using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba_7
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Введите строку в инфиксном виде");
            string infix = Console.ReadLine();
            var tokens = infix.ToCharArray();

            var postfix = Postfix(tokens);

            Console.WriteLine($"Постфиксная: {postfix}");

            var prefix = Prefix(tokens);
            Console.WriteLine($"Префиксная: {prefix}");
                
            Console.ReadLine();
        }

        private static string Prefix(char[] tokens)
        {
            Array.Reverse(tokens);

			for (int i = 0; i < tokens.Length; i++)
			{
                var c = tokens[i];

                if (c == '(')
                {
                    tokens[i] = ')';
                    i++;
                } else if (c == ')')
				{
                    tokens[i] = '(';
                    i++;
                }
            }

            Stack<char> s = new Stack<char>();
            List<char> outputList = new List<char>();
            foreach (var c in tokens)
            {
                if (char.IsLetterOrDigit(c))
                {
                    outputList.Add(c);
                }
                else if (c == '(')
                {
                    s.Push(c);
                }
                else if (c == ')')
                {
                    while (s.Count != 0 && (s.Peek() != '('))
                    {
                        outputList.Add(s.Pop());
                    }
                    s.Pop();
                }
                else
                {
                    if (IsOperator(c))
                    {
                        while (s.Count != 0 && (Priority(s.Peek()) > Priority(c)))
                        {
                            outputList.Add(s.Pop());
                        }
                        s.Push(c);
                    }
                }
            }

            while (s.Count != 0)
            {
                outputList.Add(s.Pop());
            }

            var prefix = string.Join("", outputList);
            var prefixOut = prefix.Reverse();

            return string.Join("", prefixOut);
        }

        private static string Postfix(char[] tokens)
		{
            Stack<char> s = new Stack<char>();
            List<char> outputList = new List<char>();
            foreach (var c in tokens)
            {
                if (char.IsLetterOrDigit(c))
                {
                    outputList.Add(c);
                }
                else if (c == '(')
                {
                    s.Push(c);
                }
                else if (c == ')')
                {
                    while (s.Count != 0 && (s.Peek() != '('))
                    {
                        outputList.Add(s.Pop());
                    }
                    s.Pop();
                }
                else
                {
                    if (IsOperator(c))
                    {
                        while (s.Count != 0 && (Priority(s.Peek()) >= Priority(c)))
                        {
                            outputList.Add(s.Pop());
                        }
                        s.Push(c);
                    }
                }
            }

            while (s.Count != 0)
            {
                outputList.Add(s.Pop());
            }

            return string.Join("", outputList);
        }

        static int Priority(char c)
        {
            if (c == '^')
            {
                return 3;
            }
            else if (c == '*' || c == '/')
            {
                return 2;
            }
            else if (c == '+' || c == '-')
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static bool IsOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
