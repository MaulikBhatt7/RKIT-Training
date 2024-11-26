using System;

namespace PolymorphismDemo
{
    /// <summary>
    /// Demonstrates polymorphism using both compile-time and runtime approaches.
    /// </summary>
    public class CompileTimePolymorphism
    {
        /// <summary>
        /// Demonstrates compile-time polymorphism using method overloading.
        /// </summary>
        public void Display(string message)
        {
            Console.WriteLine($"Message: {message}");
        }

        public void Display(int number)
        {
            Console.WriteLine($"Number: {number}");
        }

        public void Display(string message, int number)
        {
            Console.WriteLine($"Message: {message}, Number: {number}");
        }
    }

    /// <summary>
    /// Base class for runtime polymorphism demonstration.
    /// </summary>
    public class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a generic shape.");
        }
    }

    /// <summary>
    /// Derived class Circle that overrides the Draw method.
    /// </summary>
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Circle.");
        }
    }

    /// <summary>
    /// Derived class Triangle that overrides the Draw method.
    /// </summary>
    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Triangle.");
        }
    }

    public class PolymorphismExample
    {
        public static void RunPolymorphismDemo()
        {
            Console.WriteLine("---- Compile-Time Polymorphism ----");
            CompileTimePolymorphism example = new CompileTimePolymorphism();
            example.Display("Hello World");
            example.Display(42);
            example.Display("The answer is", 42);

            Console.WriteLine("\n---- Runtime Polymorphism ----");
            Shape genericShape = new Shape();
            Shape circle = new Circle();
            Shape triangle = new Triangle();

            genericShape.Draw();
            circle.Draw();
            triangle.Draw();
        }
    }
}
