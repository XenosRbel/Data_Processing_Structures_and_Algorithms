using System;
using System.Collections;

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
            Console.WriteLine();

            // Decode
            string decoded = huffmanTree.Decode(encoded);

            Console.WriteLine("Декодирование: " + decoded);

            Console.ReadLine();
        }
    }
}
