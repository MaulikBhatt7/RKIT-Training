using System;

namespace MethodsDemo
{
    /// <summary>
    /// Demonstrates method definition and calling in C#.
    /// </summary>
    public class MethodsExample
    {
        /// <summary>
        /// Calls various methods to demonstrate method usage in C#.
        /// </summary>
        public static void RunMethodsDemo()
        {
            int result = Add(5, 10);
            Console.WriteLine($"Addition result: {result}");

            // Calling method without return value
            PrintMessage("Hello, world!");

            // Calling method with optional parameters
            DisplayInfo("MB", 21);

            // Calling method with named arguments
            DisplayInfo(age: 20, name: "YK");
        }

        /// <summary>
        /// Adds two numbers together.
        /// </summary>
        /// <param name="a">First number to add.</param>
        /// <param name="b">Second number to add.</param>
        /// <return>The sum of the two numbers.</return>
        public static int Add(int a, int b)
        {
            // Insight: Basic addition of two integers
            return a + b;
        }

        /// <summary>
        /// Prints a message to the console.
        /// </summary>
        /// <param name="message">The message to print.</param>
        public static void PrintMessage(string message)
        {
            // Assumption: Simply prints the input message
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays a person's name and age. Age is optional.
        /// </summary>
        /// <param name="name">The name of the person.</param>
        /// <param name="age">The age of the person, defaults to 20.</param>
        public static void DisplayInfo(string name, int age = 20)
        {
            // Insight: Displays the name and age, where age can be overridden
            Console.WriteLine($"Name: {name}, Age: {age}");
        }
    }
}
