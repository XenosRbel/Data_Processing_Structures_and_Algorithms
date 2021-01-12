using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Laba_10
{
	class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите исходную строку:");
            string input = Console.ReadLine();
            HuffmanTree huffmanTree = new HuffmanTree();

            // Build the Huffman tree
            huffmanTree.Build(input);

            // Encode
            BitArray encoded = huffmanTree.Encode(input);

            Console.Write("Кодирование: ");
            foreach (bool bit in encoded)
            {
                Console.Write((bit ? 1 : 0) + "");

            }
			Console.WriteLine($"\nЗакодировано {(encoded.Length / 2)} символов и (или) {encoded.Length} бит.");
            Console.WriteLine();


            var avgS = 0f;
            List<int> FrequenciesChar = new List<int>();
            var inputArr = input.ToArray();

            for (int i = 0; i < inputArr.Length; i++)
			{
                var elem = inputArr.Count(item => item == inputArr[i]);
                FrequenciesChar.Add(elem);
            }

            for (int i = 0; i < FrequenciesChar.Count; i++)
			{
                avgS += (FrequenciesChar[i] * huffmanTree.CodesChar[i].Length);

            }
            Console.WriteLine($"Cредняя длина кода сообщения = {avgS / input.Length}");

            // Decode
            string decoded = huffmanTree.Decode(encoded);

            Console.WriteLine("Декодирование: " + decoded);

            Console.ReadLine();
        }
    }
}
