using System.Collections.Generic;

namespace Laba_15
{
	partial class Program
	{
		public class Unit<TK, TP>
        {
            // Степень
            private readonly int _power;

            public Unit(int power)
            {
                _power = power;

                Child = new List<Unit<TK, TP>>(power);

                Recordings = new List<Entry<TK, TP>>(power);
            }

            public List<Unit<TK, TP>> Child { get; set; }

            // Входящие значения
            public List<Entry<TK, TP>> Recordings { get; set; }

            // Если это узел
            public bool IsLeaf => Child.Count == 0;

            // Проверкам максимального значения
            public bool MaxRecordings => Recordings.Count == (2 * _power) - 1;

            // Проверка, достижения минимального количества входных значений
            public bool MinRecordings => Recordings.Count == _power - 1;
        }

    }
}
