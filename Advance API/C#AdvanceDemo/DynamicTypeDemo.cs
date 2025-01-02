using System;
using System.Dynamic;
using System.Reflection;

namespace CSharpAdvanceDemo
{
    /// <summary>
    /// Represents an example class with a single string property.
    /// </summary>
    public class Example
    {
        /// <summary>
        /// Gets or sets the message of the Example class.
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// Print the message.
        /// </summary>
        public void PrintMessage()
        {
            Console.WriteLine(Message);
        }
    }

    /// <summary>
    /// Demonstrates the use of dynamic types, ExpandoObject, COM interop, and reflection in C#.
    /// </summary>
    public class DynamicTypeDemo
    {
        /// <summary>
        /// Demonstrates various dynamic type features, including:
        /// - Storing multiple types in a dynamic variable.
        /// - Using ExpandoObject to create dynamic objects at runtime.
        /// - Interacting with COM objects (e.g., Excel).
        /// - Using reflection to manipulate object properties.
        /// </summary>
        public void PrintInfo()
        {
            // Demonstrate dynamic type flexibility
            dynamic value = 10; // Can store any type
            Console.WriteLine(value); // Prints 10

            value = "Hello, World!";
            Console.WriteLine(value); // Prints "Hello, World!"

            // Using ExpandoObject for dynamic properties and methods
            dynamic obj = new ExpandoObject();
            obj.Name = "MB"; // Adding a property dynamically
            obj.SayHello = (Action)(() => Console.WriteLine($"Hello, {obj.Name}!")); // Adding a method dynamically
            obj.SayHello(); // Outputs: Hello, MB!

            // Interacting with COM objects (Excel)
            dynamic excelApp = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            dynamic workbook = excelApp.Workbooks[1];
            dynamic sheet = workbook.Sheets[1];
            sheet.Cells[1, 1].Value = "Hello, Excel!";

            // Using reflection to manipulate object properties
            Type type = typeof(Example);
            object instance = Activator.CreateInstance(type); // Create an instance of Example
            PropertyInfo property = type.GetProperty("Message"); // Get the property info
            property.SetValue(instance, "Hello, Reflection!"); // Set the value of the property
            //Console.WriteLine(property.GetValue(instance)); // Get and print the value of the property
            MethodInfo method = type.GetMethod("PrintMessage"); // Get the method info
            method.Invoke(instance,null); // Invoke PrintMessage() method.
        }
    }
}
