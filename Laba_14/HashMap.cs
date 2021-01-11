namespace Laba_14
{
	partial class Program
	{
		public class HashMap<K, V>
        {
            // Ключ
            public K Key { get; private set; }

            // Значение
            public V Value { get; private set; }

            // Создание нового значения
            public HashMap(K key, V value)
            {
                Key = key;
                Value = value;
            }

            // Переопределение метода ToString
            public override string ToString()
            {
                return Value.ToString();
            }
        }
    }
}
