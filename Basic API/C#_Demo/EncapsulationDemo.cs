using System;

namespace EncapsulationDemo
{
    /// <summary>
    /// Demonstrates encapsulation by restricting access to properties using access modifiers.
    /// </summary>
    public class Person
    {
        // Private fields
        private string _name;
        private int _age;

        // Public properties to access private fields
        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
            }
        }


        public int Age
        {
            get { return _age; }
            set
            {
                if (value > 0)
                    _age = value;
            }
        }

        /// <summary>
        /// Displays person's details.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    public class EncapsulationExample

    {
        public static void RunEncapsulationDemo()
        {
            Person person = new Person
            {
                Name = "MB",
                Age = 21
            };
            person.Display();
        }
    }
}
