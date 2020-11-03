using System;

namespace Laba_1
{
    public interface ICar
    {
        string CarType { get; set; }
        DateTime CreatedAt { get; set; } 
        double EngineV { get; set; }
        double SpeedMax { get; set; }
    }
}
