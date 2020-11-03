using System;

namespace Laba_1
{
    internal class Car : ICar
    {
        public string CarType { get; set; }
        public DateTime CreatedAt { get; set; }
        public double EngineV { get; set; }
        public double SpeedMax { get; set; }

        public override string ToString()
        {
            return $"{CarType}\t{CreatedAt.ToString()}\t{EngineV}\t{SpeedMax}";
        }
    }
}
