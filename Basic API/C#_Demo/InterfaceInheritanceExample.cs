using System;

namespace InterfaceDemo
{
    /// <summary>
    /// Demonstrates Interface and Inheritance concepts in C#.
    /// </summary>
    public class InterfaceInheritanceExample
    {
        /// <summary>
        /// Runs a demo to show how interfaces and inheritance work in C#.
        /// </summary>
        public static void RunInterfaceInheritanceDemo()
        {
            // Assumption: Creating an instance of Car which implements IVehicle
            Car myCar = new Car("Toyota");
            myCar.Start();
            myCar.Stop();
        }
    }

    /// <summary>
    /// Interface representing vehicle behaviors.
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Starts the vehicle.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the vehicle.
        /// </summary>
        void Stop();
    }

    /// <summary>
    /// Represents a Car that inherits from Vehicle and implements IVehicle.
    /// </summary>
    public class Car : IVehicle
    {
        /// <summary>
        /// Gets or sets the car's brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Initializes a new instance of the Car class.
        /// </summary>
        /// <param name="brand">The brand of the car.</param>
        public Car(string brand)
        {
            // Assumption: The constructor initializes the car's brand
            Brand = brand;
        }

        /// <summary>
        /// Starts the car engine.
        /// </summary>
        public void Start()
        {
            Console.WriteLine($"The {Brand} car is starting.");
        }

        /// <summary>
        /// Stops the car engine.
        /// </summary>
        public void Stop()
        {
            Console.WriteLine($"The {Brand} car is stopping.");
        }
    }
}
