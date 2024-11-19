using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    /// <summary>
    /// Demonstrates the use of collections in C#.
    /// </summary>
    public class CollectionsExample
    {
        /// <summary>
        /// Runs a demo to show how different collections work in C#.
        /// </summary>
        public static void RunCollectionsDemo()
        {
            // List Example
            // Assumption: Using List to store integers
            List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };

            // Adding an element to the list
            numbers.Add(60);

            // Iterating through the list
            Console.WriteLine("List Contents:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            // Dictionary Example (key-value pairs)
            Dictionary<string, string> capitals = new Dictionary<string, string>
            {
                { "USA", "Washington, D.C." },
                { "India", "New Delhi" }
            };

            // Accessing dictionary values by key
            Console.WriteLine("\nDictionary Example:");
            Console.WriteLine($"Capital of USA: {capitals["USA"]}");

            // Queue Example (FIFO)
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");

            Console.WriteLine("\nQueue Contents:");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            // Stack Example (LIFO)
            Stack<string> stack = new Stack<string>();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");

            Console.WriteLine("\nStack Contents:");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            // HashSet Example (unique elements)
            HashSet<int> uniqueNumbers = new HashSet<int> { 1, 2, 3, 4, 5, 5, 6 };

            Console.WriteLine("\nHashSet Contents (unique elements only):");
            foreach (int num in uniqueNumbers)
            {
                Console.WriteLine(num);
            }

            // SortedList Example (key-value pairs sorted by key)
            SortedList<string, string> sortedCapitals = new SortedList<string, string>
            {
                { "USA", "Washington, D.C." },
                { "India", "New Delhi" },
                { "Germany", "Berlin" }
            };

            Console.WriteLine("\nSortedList Contents:");
            foreach (var entry in sortedCapitals)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            // LinkedList Example
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddLast("First");
            linkedList.AddLast("Second");
            linkedList.AddLast("Third");

            Console.WriteLine("\nLinkedList Contents:");
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
