using System;

namespace DatatypesDemo
{
    /// <summary>
    /// Demonstrates datatypes and type conversions.
    /// </summary>
    public class DatatypeDemo
    {
        public static void Main()
        {
            int intValue = 10;
            float floatValue = 20.5f;
            string strValue = "30";
            char charValue = 'A';

            // Implicit conversion
            double doubleValue = intValue;

            // Explicit conversion
            int castedValue = (int)floatValue;

            // String conversion
            int parsedValue = int.Parse(strValue);

            Console.WriteLine($"Int: {intValue}, Float: {floatValue}, String: {strValue}");
            Console.WriteLine($"Double (Implicit): {doubleValue}, Int (Casted): {castedValue}");
            Console.WriteLine($"Parsed Int: {parsedValue}");
            Console.ReadLine();
        }
    }
}
