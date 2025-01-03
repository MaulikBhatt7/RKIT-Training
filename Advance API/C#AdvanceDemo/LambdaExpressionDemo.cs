using System;
using System.Collections.Generic;

namespace CSharpAdvanceDemo
{
    /// <summary>
    /// Demonstrates the use of Lambda expressions in C# to filter and process lists.
    /// </summary>
    public class LambdaExpressionDemo
    {
        /// <summary>
        /// Prints even and odd numbers from a list using Lambda expressions.
        /// Even numbers are displayed as a simple list, 
        /// while odd numbers include an additional statement to demonstrate multi-line lambda.
        /// </summary>
        public void PrintInfo()
        {
            // Initialize a list of integers
            List<int> lstNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            // Use a lambda expression to find all even numbers
            IEnumerable<int> lstEvenNumbers = lstNumbers.FindAll(x => x % 2 == 0);

            Console.WriteLine("Square-List : ");
            // Print all even numbers
            foreach (int num in lstEvenNumbers)
            {
                Console.WriteLine(num);
            }

            // Use a multi-line lambda expression to find all odd numbers
            IEnumerable<int> lstOddNumbers = lstNumbers.FindAll((x) =>
            {
                Console.WriteLine("Statement Demo");
                return x % 2 != 0;
            });

            Console.WriteLine("Cube-List : ");
            // Print all odd numbers
            foreach (int num in lstOddNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
