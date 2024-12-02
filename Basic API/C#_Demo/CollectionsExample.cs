using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    /// <summary>
    /// Demonstrates the use of collections in C# with extended examples for List and Dictionary methods.
    /// </summary>
    public class CollectionsExample
    {
        /// <summary>
        /// Runs a demo to show how different collections work in C#, focusing on List and Dictionary methods.
        /// </summary>
        public static void RunCollectionsDemo()
        {
            // List Example
            List<int> lstNumbers = new List<int> { 10, 20, 30, 40, 50 };
            lstNumbers.Add(60);  // Add an element to the list
            lstNumbers.AddRange(new int[] { 70, 80 });  // Add multiple elements

            Console.WriteLine("List Contents After Add and AddRange:");
            lstNumbers.ForEach(num => Console.WriteLine(num));  // Use ForEach to print elements

            lstNumbers.Insert(2, 25);  // Insert element at index 2
            Console.WriteLine("\nAfter Insert at index 2:");
            lstNumbers.ForEach(num => Console.WriteLine(num));

            lstNumbers.Remove(30);  // Remove specific element
            lstNumbers.RemoveAt(1);  // Remove element at index 1
            Console.WriteLine("\nAfter Remove and RemoveAt:");
            lstNumbers.ForEach(num => Console.WriteLine(num));

            int[] arrNumbers = lstNumbers.ToArray();  // Convert to array
            Console.WriteLine("\nArray Converted from List:");
            foreach (int num in arrNumbers)
            {
                Console.WriteLine(num);
            }

            lstNumbers.Sort();  // Sort the list
            Console.WriteLine("\nAfter Sorting:");
            lstNumbers.ForEach(num => Console.WriteLine(num));

            lstNumbers.Reverse();  // Reverse the list
            Console.WriteLine("\nAfter Reversing:");
            lstNumbers.ForEach(num => Console.WriteLine(num));

            // Dictionary Example
            Dictionary<string, string> dicCapitals = new Dictionary<string, string>
            {
                { "India", "New Delhi" },
                { "USA", "Washington, D.C." },
                { "Germany", "Berlin" }
            };

            dicCapitals.Add("France", "Paris");  // Add a key-value pair
            dicCapitals["Canada"] = "Ottawa";  // Add or update key-value using index

            if (dicCapitals.TryGetValue("USA", out string capital))
            {
                Console.WriteLine($"\nCapital of USA: {capital}");
            }

            dicCapitals.Remove("Germany");  // Remove a key-value pair
            Console.WriteLine("\nDictionary Contents After Remove:");
            foreach (var keyValuePair in dicCapitals)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }

            Console.WriteLine($"\nContains key 'India': {dicCapitals.ContainsKey("India")}");
            Console.WriteLine($"Contains value 'Berlin': {dicCapitals.ContainsValue("Berlin")}");

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
            HashSet<int> hashUniqueNumbers = new HashSet<int> { 1, 2, 3, 4, 5, 5, 6 };

            Console.WriteLine("\nHashSet Contents (unique elements only):");
            foreach (int num in hashUniqueNumbers)
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
