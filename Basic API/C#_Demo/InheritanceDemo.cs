using System;

namespace InheritanceDemo
{
    /// <summary>
    /// Base class for all shapes.
    /// </summary>
    public class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a generic shape.");
        }
    }

    /// <summary>
    /// Single inheritance: Circle inherits from Shape.
    /// </summary>
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Circle.");
        }
    }

    /// <summary>
    /// Multilevel inheritance: ColoredCircle inherits from Circle.
    /// </summary>
    public class ColoredCircle : Circle
    {
        public string Color { get; set; }

        public ColoredCircle(string color)
        {
            Color = color;
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a {Color} Circle.");
        }
    }

    /// <summary>
    /// Hierarchical inheritance: Rectangle also inherits from Shape.
    /// </summary>
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Rectangle.");
        }
    }

    public class InheritanceExample
    {
        public static void RunInheritanceDemo()
        {
            Shape circle = new Circle();
            Shape coloredCircle = new ColoredCircle("Red");
            Shape rectangle = new Rectangle();

            circle.Draw();
            coloredCircle.Draw();
            rectangle.Draw();
        }
    }
}
