using System;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Main class containing the entry point of the application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entry point for the application. Displays a menu for managing employees.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            bool continueRunning = true;

            Console.WriteLine("Welcome to the Employee Management System!");

            while (continueRunning)
            {
                DisplayMenu();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Operations.AddEmployee();
                        break;
                    case "2":
                        Operations.ViewAllEmployees();
                        break;
                    case "3":
                        Operations.SearchEmployee();
                        break;
                    case "4":
                        Operations.UpdateEmployee();
                        break;
                    case "5":
                        Operations.DeleteEmployee();
                        break;
                    case "6":
                        try
                        {
                            Operations.SaveToFile();
                        }
                        catch (EmployeeFileException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "7":
                        try
                        {
                            Operations.LoadFromFile();
                        }
                        catch (EmployeeFileException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "8":
                        continueRunning = false;
                        Console.WriteLine("Exiting the Employee Management System. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Displays the main menu options to the console.
        /// </summary>
        private static void DisplayMenu()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("Employee Management System - Main Menu");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. Search Employee");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Save Employee Data to File");
            Console.WriteLine("7. Load Employee Data from File");
            Console.WriteLine("8. Exit");
            Console.WriteLine("==========================================");
        }
    }
}
