using System;
using System.IO;

namespace FileOperationsDemo
{
    /// <summary>
    /// Demonstrates basic file operations such as reading, writing, appending to files,
    /// and working with FileInfo and DirectoryInfo in C#.
    /// </summary>
    public class FileOperationsExample
    {
        /// <summary>
        /// Runs a demo to show how to work with files and directories in C#.
        /// Allows dynamic paths for file and directory operations.
        /// </summary>
        public static void RunFileOperationsDemo()
        {
            // Prompt user for file and directory paths
            Console.WriteLine("Enter the file path (or press Enter to use the default 'example.txt'):");
            string filePath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "example.txt");
            }

            Console.WriteLine("Enter the directory path (or press Enter to use the default 'DemoDirectory'):");
            string directoryPath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "DemoDirectory");
            }

            // Writing to a file
            string contentToWrite = "Hello, this is a demo for file operations in C#!";
            File.WriteAllText(filePath, contentToWrite);
            Console.WriteLine($"Written to file: {filePath}");

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

            // Demonstrating FileInfo
            FileInfo fileInfo = new FileInfo(filePath);
            Console.WriteLine("\n--- FileInfo Details ---");
            Console.WriteLine($"File Name: {fileInfo.Name}");
            Console.WriteLine($"File Directory: {fileInfo.DirectoryName}");
            Console.WriteLine($"File Size: {fileInfo.Length} bytes");
            Console.WriteLine($"File Creation Time: {fileInfo.CreationTime}");

            // Demonstrating DirectoryInfo
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            // Creating a directory
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                Console.WriteLine("\nDirectory created.");
            }

            Console.WriteLine("\n--- DirectoryInfo Details ---");
            Console.WriteLine($"Directory Name: {directoryInfo.Name}");
            Console.WriteLine($"Full Path: {directoryInfo.FullName}");
            Console.WriteLine($"Creation Time: {directoryInfo.CreationTime}");

            // Moving the file into the created directory
            string newFilePath = Path.Combine(directoryPath, fileInfo.Name);
            fileInfo.MoveTo(newFilePath);
            Console.WriteLine($"\nFile moved to: {newFilePath}");

            // Deleting the file and directory
            File.Delete(newFilePath);
            Console.WriteLine("File deleted.");
            directoryInfo.Delete();
            Console.WriteLine("Directory deleted.");
        }
    }
}
