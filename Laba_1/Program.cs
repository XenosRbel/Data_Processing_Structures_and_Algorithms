using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba_1
{
    //Вариант 4
    class Program
    {
        static void Main(string[] args)
        {
            /*var cars = new List<ICar> 
            { 
                new Car 
                {
                    CarType = "BMW", 
                    CreatedAt = DateTime.Parse("25.09.2016"), 
                    EngineV = 6.5,
                    SpeedMax = 260
                },
                new Car
                {
                    CarType = "Seat",
                    CreatedAt = DateTime.Parse("25.09.2000"),
                    EngineV = 2.5,
                    SpeedMax = 120
                },
                new Car
                {
                    CarType = "BMW",
                    CreatedAt = DateTime.Parse("25.09.2005"),
                    EngineV = 2.5,
                    SpeedMax = 180
                },
                new Car
                {
                    CarType = "Audi",
                    CreatedAt = DateTime.Parse("25.09.2015"),
                    EngineV = 4.5,
                    SpeedMax = 200
                },
                new Car
                {
                    CarType = "Scoda",
                    CreatedAt = DateTime.Parse("25.09.2020"),
                    EngineV = 6,
                    SpeedMax = 150
                },
            };*/
            var cars = FillCars();
            Console.WriteLine($"Input\n{string.Join("\n", cars)}\n");

            var filtredCars = cars.Where(car => car.CreatedAt.Year > 2005).OrderByDescending(car => car.SpeedMax);

            Console.WriteLine($"Output\n{string.Join("\n", filtredCars)}\n");
        }

        static IList<ICar> FillCars()
        {
            var cars = new List<ICar>();

            Console.WriteLine("Сколько автомобилей добавить ?\nВведите число:");
            var carCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Начат процесс добавления {carCount} автомол{(carCount > 1 ? "ей" : "я")}");
            for (int i = 0; i < carCount; i++)
            {
                var car = CreateCar();
                cars.Add(car);
            }

            return cars;
        }

        static ICar CreateCar()
        {
            var car = new Car();
            Console.WriteLine("Введите название автомобиля:\n");
            car.CarType = Console.ReadLine();

            Console.WriteLine("Введите дату выпуска автомобиля в формате \"дд.мм.гггг.\"\n");
            car.CreatedAt = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите объем двигателя автомобиля:\n");
            car.EngineV = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите максимальную скорость автомобиля:\n");
            car.SpeedMax = Convert.ToInt32(Console.ReadLine());
            return car;
        }
    }
}
