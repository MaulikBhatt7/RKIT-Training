using System;
using System.IO;

namespace FileOperationsDemo
{
    /// <summary>
    /// Demonstrates basic file operations such as reading, writing, and appending to files in C#.
    /// </summary>
    public class FileOperationsExample
    {
        /// <summary>
        /// Runs a demo to show how to work with files in C#.
        /// </summary>
        public static void RunFileOperationsDemo()
        {
            string filePath = "example.txt";

            // Writing to a file
            string contentToWrite = "Hello, this is a demo for file operations in C#!";
            File.WriteAllText(filePath, contentToWrite);
            Console.WriteLine("Written to file.");

            // Reading from the file
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine($"Content from file: {fileContent}");
            }

            // Appending to a file
            string appendContent = "\nThis content was appended to the file.";
            File.AppendAllText(filePath, appendContent);
            Console.WriteLine("Appended to file.");

            // Reading the appended content
            string updatedFileContent = File.ReadAllText(filePath);
            Console.WriteLine($"Updated Content: {updatedFileContent}");

            // Checking if file exists
            bool fileExists = File.Exists(filePath);
            Console.WriteLine($"Does the file exist? {fileExists}");

            // Deleting the file
            File.Delete(filePath);
            Console.WriteLine("File deleted.");
        }
    }
}
