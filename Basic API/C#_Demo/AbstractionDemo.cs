using System;

namespace AbstractionDemo
{
    /// <summary>
    /// Abstract base class representing a vehicle.
    /// </summary>
    public abstract class Vehicle
    {
        public abstract void Start(); // Abstract method

        public void Stop()
        {
            Console.WriteLine("Vehicle stopped.");
        }
    }

    /// <summary>
    /// Concrete implementation of a car.
    /// </summary>
    public class Car : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Car started.");
        }
    }

    /// <summary>
    /// Concrete implementation of a bike.
    /// </summary>
    public class Bike : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Bike started.");
        }
    }

    public class AbsractionExample
    {
        public static void RunAbstractionDemo()
        {
            Vehicle myCar = new Car();
            Vehicle myBike = new Bike();

            myCar.Start();
            myCar.Stop();
            myBike.Start();
            myBike.Stop();
        }
    }
}
