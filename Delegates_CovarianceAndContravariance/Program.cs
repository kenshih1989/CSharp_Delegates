namespace Delegates_CovarianceAndContravariance
{
    internal class Program
    {
        delegate Car CarFactoryDelegate(int Id, string type);
        delegate Car CarCreationDelegate(string type);
        delegate void RepairICECarDelegate(ICECar iceCar);
        delegate void RepairEVCarDelegate(EVCar veCar);

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Covariance and Contravariance Demo!");
            Console.WriteLine("===============================================");
            Console.WriteLine("This program demonstrates the concepts of covariance and contravariance in C# using a simple car factory example.");
            Console.WriteLine("In this example, we have a base class 'Car' and two derived classes 'ICECar' and 'EVCar'.");
            Console.WriteLine("We will use delegates to demonstrate how covariance and contravariance work in C#.");
            Console.WriteLine();

            Console.WriteLine("Creating an ICECar and an EVCar using covariance:");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Covariance allows a method to return a more derived type than the delegate's return type.");
            Console.WriteLine("Assigning a method that returns an ICECar to a delegate that expects a Car.");
            CarFactoryDelegate carFactoryDelegate = CarFactory.ReturnICECar;
            Car iceCar = carFactoryDelegate(1, "Audi R8");
            Console.WriteLine($"Object Type: {iceCar.GetType().Name}");
            Console.WriteLine($"Car Details: {iceCar.GetCarDetails()}");
            carFactoryDelegate = CarFactory.ReturnEVCar;
            Car evCar = carFactoryDelegate(2, "Tesla Model 3");
            Console.WriteLine($"Object Type: {evCar.GetType().Name}");
            Console.WriteLine($"Car Details: {evCar.GetCarDetails()}");
            Console.WriteLine();

            Console.WriteLine("Creating an EVCar using contravariance:");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Contravariance allows a method to accept parameters of a less derived type than the delegate's parameter type.");
            Console.WriteLine("Assigning a method that accepts a Car to a delegate that expects a method accepting an ICECar.");
            Console.WriteLine();

            RepairICECarDelegate repairICEDel = CarFactory.RepairAnyCar;
            RepairEVCarDelegate repairEVDel = CarFactory.RepairAnyCar;
            ICECar myAudi = new ICECar { Id = 1, Name = "Audi R8" };
            EVCar myTesla = new EVCar { Id = 2, Name="Tesla Model 3" };
            repairICEDel(myAudi);
            repairEVDel(myTesla);


            #region random car generation
            Console.WriteLine();
            Console.WriteLine("Randomly generating a list of cars using the CarCreationDelegate.");
            CarCreationDelegate carCreationDelegate = CarFactory.CreateCar;
            List<Car> cars = new List<Car>();
            int randomValue;
            for (int i = 0; i < 5; i++)
            {
                randomValue = Random.Shared.Next(0, 2);
                if (randomValue == 0)
                    cars.Add(carCreationDelegate("ICE"));
                else
                    cars.Add(carCreationDelegate("EV"));
            }

            //Up to this point, we have a list of cars, but we don't know their specific types (ICECar or EVCar).
            foreach (var unknownCar in cars)
            {
                Console.WriteLine($"Object Type: {unknownCar.GetType().Name}");
                if (unknownCar is ICECar iceCarObj)
                {
                    Console.WriteLine($"Car Details: {iceCarObj.GetCarDetails()}");
                }
                else if (unknownCar is EVCar evCarObj)
                {
                    Console.WriteLine($"Car Details: {evCarObj.GetCarDetails()}");
                }
                else
                {
                    Console.WriteLine("Car Details: Unknown car type.");
                }
            }
            #endregion

        }
    }

    public static class CarFactory
    {
        public static ICECar ReturnICECar(int id, string name) => new ICECar { Id = id, Name = name };
        public static EVCar ReturnEVCar(int id, string name) => new EVCar { Id = id, Name = name };
        public static Car CreateCar(string type)
        {
            return type switch
            {
                "ICE" => new ICECar { Id = 3, Name = "Toyota Camry" },
                "EV" => new EVCar { Id = 4, Name = "Tesla Model 3" },
                _ => throw new ArgumentException("Invalid car type")
            };
        }
        public static void RepairAnyCar(Car generalCar)
        {
            Console.WriteLine($"Repairing: {generalCar.Name}. No matter ICECar or EVCar,I can repair them!");
        }
        //public static void RepairICECar(ICECar iceCar)
        //{
        //    Console.WriteLine($"Repairing: {iceCar.Name}. I only repair ICECar!");
        //}
    }

    public abstract class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual string GetCarDetails()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }

    public class ICECar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Internal Combustion Engine";
        }
    }

    public class EVCar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Electrical Vehicle";
        }
    }
}
