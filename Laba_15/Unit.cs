using System.Collections.Generic;

namespace Laba_15
{
	partial class Program
	{
		public class Unit<TK, TP>
        {
            // Степень
            private int power;

            public Unit(int power)
            {
                this.power = power;

                this.Child = new List<Unit<TK, TP>>(power);

                this.Recordings = new List<Entry<TK, TP>>(power);
            }

            public List<Unit<TK, TP>> Child { get; set; }

            // Входящие значения
            public List<Entry<TK, TP>> Recordings { get; set; }

            // Если это узел
            public bool IsLeaf => this.Child.Count == 0;

            // Проверкам максимального значения
            public bool MaxRecordings => this.Recordings.Count == (2 * this.power) - 1;

            // Проверка, достижения минимального количества входных значений
            public bool MinRecordings => this.Recordings.Count == this.power - 1;
        }

    }
}
