using System;

namespace StringClassDemo
{
    /// <summary>
    /// Demonstrates the use of the String class in C#.
    /// </summary>
    public class StringExample
    {
        /// <summary>
        /// Runs a demo to show how string operations work in C#.
        /// </summary>
        public static void RunStringDemo()
        {
            string text = "Hello, C# World!";

            // String Length
            Console.WriteLine($"Length of the string: {text.Length}");

            // String Concatenation
            string concatenated = text + " Let's learn more!";
            Console.WriteLine($"Concatenated String: {concatenated}");

            // String Comparison
            bool areEqual = text.Equals("Hello, C# World!");
            Console.WriteLine($"Are the strings equal? {areEqual}");

            // Substring
            string substring = text.Substring(7, 3); // Extracts "C# "
            Console.WriteLine($"Substring: {substring}");

            // Replacing Characters
            string replacedText = text.Replace("C#", "CSharp");
            Console.WriteLine($"Replaced Text: {replacedText}");

            // Convert to Upper/Lowercase
            Console.WriteLine($"Uppercase: {text.ToUpper()}");
            Console.WriteLine($"Lowercase: {text.ToLower()}");

            // Trimming White Spaces
            string textWithSpaces = "   Hello, Trim me!   ";
            Console.WriteLine($"Trimmed: '{textWithSpaces.Trim()}'");
        }
    }
}
