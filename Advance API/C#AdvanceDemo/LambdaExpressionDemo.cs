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
            Console.WriteLine("Expression Demo : ");
            IEnumerable<int> lstEvenNumbers = lstNumbers.FindAll(x => x % 2 == 0);

            Console.WriteLine("Even Number List : ");
            // Print all even numbers
            foreach (int num in lstEvenNumbers)
            {
                Console.WriteLine(num);
            }

            // Use a multi-line lambda expression to find all odd numbers

            Console.WriteLine("Statement Demo : ");
            IEnumerable<int> lstOddNumbers = lstNumbers.FindAll((x) =>
            {
                return x % 2 != 0;
            });

            Console.WriteLine("Odd Number List : ");
            // Print all odd numbers
            foreach (int num in lstOddNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
