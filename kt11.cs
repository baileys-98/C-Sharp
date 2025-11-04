using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT11
{
    abstract class Vehicle
    {
        protected string brand;
        protected string model;
        protected int year;

        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public int Year
        {
            get => year;
            set => year = value >= 1886 ? value : throw new ArgumentException("Год должен быть не менее 1886");
        }

        public Vehicle(string brand, string model, int year)
        {
            this.brand = brand;
            this.model = model;
            this.year = year;
        }

        public abstract void StartEngine();
        public abstract void StopEngine();

        public virtual string GetInfo()
        {
            return $"{brand} {model}, {year} год";
        }

        public void DisplayInfo()
        {
            Console.WriteLine(GetInfo());
        }
    }

    interface IDrivable
    {
        void Drive();
        void Park();
    }

    interface IMaintainable
    {
        void PerformMaintenance();
    }

    class Car : Vehicle, IDrivable, IMaintainable
    {
        private int numberOfDoors;

        public int NumberOfDoors
        {
            get => numberOfDoors;
            set => numberOfDoors = value >= 2 && value <= 5 ? value : throw new ArgumentException("Количество дверей должно быть от 2 до 5");
        }

        public Car(string brand, string model, int year, int numberOfDoors)
            : base(brand, model, year)
        {
            this.numberOfDoors = numberOfDoors;
        }

        public override void StartEngine()
        {
            Console.WriteLine($"Двигатель автомобиля {brand} {model} заведён");
        }

        public override void StopEngine()
        {
            Console.WriteLine($"Двигатель автомобиля {brand} {model} заглушен");
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", {numberOfDoors} дверей";
        }

        public void Drive()
        {
            Console.WriteLine($"Автомобиль {brand} {model} едет по дороге");
        }

        public void Park()
        {
            Console.WriteLine($"Автомобиль {brand} {model} припаркован");
        }

        public void PerformMaintenance()
        {
            Console.WriteLine($"Проводится техобслуживание автомобиля {brand} {model}");
        }
    }

    class Motorcycle : Vehicle, IDrivable, IMaintainable
    {
        private bool hasSidecar;

        public bool HasSidecar { get => hasSidecar; set => hasSidecar = value; }

        public Motorcycle(string brand, string model, int year, bool hasSidecar)
            : base(brand, model, year)
        {
            this.hasSidecar = hasSidecar;
        }

        public override void StartEngine()
        {
            Console.WriteLine($"Двигатель мотоцикла {brand} {model} заведён");
        }

        public override void StopEngine()
        {
            Console.WriteLine($"Двигатель мотоцикла {brand} {model} заглушен");
        }

        public override string GetInfo()
        {
            string sidecarInfo = hasSidecar ? "с коляской" : "без коляски";
            return base.GetInfo() + $", {sidecarInfo}";
        }

        public void Drive()
        {
            string driveMessage = hasSidecar ? "едет с коляской" : "едет";
            Console.WriteLine($"Мотоцикл {brand} {model} {driveMessage}");
        }

        public void Park()
        {
            Console.WriteLine($"Мотоцикл {brand} {model} припаркован");
        }

        public void PerformMaintenance()
        {
            Console.WriteLine($"Проводится техобслуживание мотоцикла {brand} {model}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Демонстрация транспортных средств ===\n");

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car("Dodge", "Challenger Hellcat", 2023, 2),
                new Car("Toyota", "Camry", 2022, 4),
                new Motorcycle("Yamaha", "MT-07", 2022, false),
                new Motorcycle("Ural", "Gear-Up", 2021, true)
            };

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine("=".PadRight(40, '='));
                vehicle.DisplayInfo();
                vehicle.StartEngine();

                if (vehicle is IDrivable drivable)
                {
                    drivable.Drive();
                    drivable.Park();
                }

                if (vehicle is IMaintainable maintainable)
                {
                    maintainable.PerformMaintenance();
                }

                vehicle.StopEngine();
                Console.WriteLine();
            }

            Console.WriteLine("\n=== Только управляемые транспортные средства ===");
            List<IDrivable> drivables = new List<IDrivable>
            {
                new Car("Honda", "Civic", 2020, 4),
                new Motorcycle("Kawasaki", "Ninja 400", 2023, false)
            };

            foreach (var drivable in drivables)
            {
                drivable.Drive();
                drivable.Park();
                Console.WriteLine();
            }
        }
    }
}