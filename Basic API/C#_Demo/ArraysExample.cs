using System;

namespace ArraysDemo
{
    /// <summary>
    /// Demonstrates arrays and their methods in C#.
    /// </summary>
    public class ArraysExample
    {
        /// <summary>
        /// Runs a demo to show basic array operations and manipulation.
        /// </summary>
        public static void RunArraysDemo()
        {
            // Assumption: Creating a single-dimensional array with integers
            int[] numbers = { 10, 20, 30, 40, 50 };

            // Accessing array elements
            Console.WriteLine($"First element: {numbers[0]}");

            // Using Array methods
            Array.Sort(numbers);  // Sort the array
            // Insight: Sorting modifies the original array in ascending order
            Console.WriteLine("Sorted array:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            // Multidimensional array
            int[,] matrix = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            Console.WriteLine($"Matrix element at [1,1]: {matrix[1, 1]}");

            // Jagged array (array of arrays)
            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new int[] { 1, 2, 3 };
            jaggedArray[1] = new int[] { 4, 5, 6 };
            Console.WriteLine($"Jagged array element at [1][2]: {jaggedArray[1][2]}");
        }
    }
}
