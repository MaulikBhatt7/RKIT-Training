namespace CSharpAdvanceDemo
{
    /// <summary>
    /// Entry class to demonstrate file system-related functionalities.
    /// Includes operations on drives, directories, and files.
    /// </summary>
    public class FileSystemDemo
    {
        /// <summary>
        /// Initiates demonstration of file system operations.
        /// Uncomment respective lines to invoke drive or directory-related functionality.
        /// </summary>
        public void PrintInfo()
        {
            DriveInfoDemo objDriveInfoDemo = new DriveInfoDemo();
            objDriveInfoDemo.PrintDriveInfo();

            DirectoryInfoDemo objDirectoryInfoDemo = new DirectoryInfoDemo();
            objDirectoryInfoDemo.PrintDirectoryInfo();

            FileInfoDemo objFileInfoDemo = new FileInfoDemo();
            objFileInfoDemo.PrintFileInfo();
        }
    }

    /// <summary>
    /// Demonstrates directory-related operations using DirectoryInfo.
    /// </summary>
    public class DirectoryInfoDemo
    {
        /// <summary>
        /// Creates directories, lists their properties, and creates subdirectories.
        /// </summary>
        public void PrintDirectoryInfo()
        {
            DirectoryInfo objDirectoryInfo = new DirectoryInfo("Temp_directory");
            objDirectoryInfo.Create();

            // Display properties of the created directory
            Console.WriteLine(objDirectoryInfo.FullName);
            Console.WriteLine(objDirectoryInfo.Exists);
            Console.WriteLine(objDirectoryInfo.LastAccessTime);
            Console.WriteLine(objDirectoryInfo.LastWriteTime);
            Console.WriteLine(objDirectoryInfo.Name);
            Console.WriteLine(objDirectoryInfo.Attributes);
            Console.WriteLine(objDirectoryInfo.CreationTime);
            Console.WriteLine(objDirectoryInfo.Extension);

            // Create subdirectories
            objDirectoryInfo.CreateSubdirectory("Sub_Directory");
            objDirectoryInfo.CreateSubdirectory("Sub_Directory/Sub_Temp_Directory");

            // Display the number of subdirectories created
            Console.WriteLine(objDirectoryInfo.GetDirectories().Length);
        }
    }

    /// <summary>
    /// Demonstrates file operations using FileInfo, including creation, modification, and inspection.
    /// </summary>
    public class FileInfoDemo
    {
        /// <summary>
        /// Performs various file operations such as appending text, moving files, and displaying file properties.
        /// </summary>
        public void PrintFileInfo()
        {
            // Get the current directory
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current Directory: {currentDirectory}");

            // Define paths for the directory and file
            string directoryPath = Path.Combine(currentDirectory, "Temp_Directory");
            string filePath = Path.Combine(directoryPath, "Temp_file.txt");

            try
            {
                // Create a directory if it does not exist
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                    Console.WriteLine($"Directory created: {directoryPath}");
                }

                FileInfo fileInfo = new FileInfo(filePath);

                // Append text to the file
                using (StreamWriter writer = fileInfo.AppendText())
                {
                    writer.WriteLine("Appending text to the file from MB.");
                }
                Console.WriteLine("Text appended to the file.");

                // Move the file to a new location
                string newFilePath = "example_moved.txt";
                FileInfo newFileInfo = new FileInfo(filePath);
                newFileInfo.MoveTo(newFilePath);
                Console.WriteLine($"File moved to {newFilePath}.");

                // Demonstrate file opening modes
                using (FileStream fileStream = fileInfo.Open(FileMode.OpenOrCreate))
                {
                    Console.WriteLine("File opened with FileMode.OpenOrCreate.");
                }
                using (FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read))
                {
                    Console.WriteLine("File opened with FileMode.Open and FileAccess.Read.");
                }
                using (FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    Console.WriteLine("File opened with FileMode.Open, FileAccess.ReadWrite, and FileShare.None.");
                }
                using (FileStream readStream = fileInfo.OpenRead())
                {
                    Console.WriteLine("File opened for reading.");
                }
                using (FileStream writeStream = fileInfo.OpenWrite())
                {
                    Console.WriteLine("File opened for writing.");
                }

                //// Perform file operations
                //string content = "Hello From MB!";
                //File.WriteAllText(filePath, content);
                //Console.WriteLine("Content written to file.");

                //string readContent = File.ReadAllText(filePath);
                //Console.WriteLine("File content: " + readContent);

                //File.AppendAllText(filePath, " How are you?");
                //Console.WriteLine("Content appended to file.");

                //string appendedContent = File.ReadAllText(filePath);
                //Console.WriteLine("Appended content: " + appendedContent);

                // Read and display content of the moved file
                using StreamReader reader = new StreamReader(newFilePath);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"{line}");
                }

                // Display file properties
                Console.WriteLine($"Full Name: {fileInfo.FullName}");
                Console.WriteLine($"Name: {fileInfo.Name}");
                Console.WriteLine($"Length: {fileInfo.Length} bytes");
                Console.WriteLine($"Extension: {fileInfo.Extension}");
                Console.WriteLine($"Created: {fileInfo.CreationTime}");
                Console.WriteLine($"Last Accessed: {fileInfo.LastAccessTime}");
                Console.WriteLine($"Last Modified: {fileInfo.LastWriteTime}");
            }
            catch (Exception ex)
            {
                // Handle exceptions and display error messages
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Demonstrates drive-related operations using DriveInfo.
    /// </summary>
    public class DriveInfoDemo
    {
        /// <summary>
        /// Lists available drives and their details such as total size, free space, and format.
        /// </summary>
        public void PrintDriveInfo()
        {
            // Retrieve and display all drives
            DriveInfo[] di = DriveInfo.GetDrives();

            Console.WriteLine("Total Partitions");
            Console.WriteLine("---------------------");
            foreach (DriveInfo items in di)
            {
                Console.WriteLine(items.Name);
            }

            // Prompt the user for a specific drive to display its details
            Console.Write("\nEnter the Partition::");
            string ch = Console.ReadLine();
            DriveInfo dInfo = new DriveInfo(ch);

            // Display details of the selected drive
            Console.WriteLine("\n");
            Console.WriteLine($"Drive Name: {dInfo.Name}");
            Console.WriteLine($"Total Space: {dInfo.TotalSize}");
            Console.WriteLine($"Free Space: {dInfo.TotalFreeSpace}");
            Console.WriteLine($"Drive Format: {dInfo.DriveFormat}");
            Console.WriteLine($"Volume Label: {dInfo.VolumeLabel}");
            Console.WriteLine($"Drive Type: {dInfo.DriveType}");
            Console.WriteLine($"Root Directory: {dInfo.RootDirectory}");
            Console.WriteLine($"Ready: {dInfo.IsReady}");
        }
    }
}
