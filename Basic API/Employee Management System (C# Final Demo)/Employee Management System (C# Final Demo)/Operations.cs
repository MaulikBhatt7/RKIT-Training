using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Class for performing employee-related operations such as adding, viewing, updating, deleting, 
    /// searching employees, and handling file operations.
    /// </summary>
    public class Operations
    {
        private static List<Employee> employees = new List<Employee>();

        #region Employee Operations

        /// <summary>
        /// Adds a new employee to the list by collecting details such as ID, name, department, salary, 
        /// and joining date. Handles exceptions for invalid input.
        /// </summary>
        public static void AddEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID: ");
                string idInput = Console.ReadLine();
                if (!int.TryParse(idInput, out int id) || id <= 0)
                {
                    throw new InvalidIdException("Invalid ID. Please enter a positive integer.");
                }

                // Ensures no duplicate ID exists
                if (employees.Exists(e => e.Id == id))
                {
                    throw new InvalidIdException($"Employee ID {id} already exists.");
                }

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Choose Department: 1. HR 2. IT 3. Finance 4. Marketing");
                int deptChoice = int.Parse(Console.ReadLine());
                if (deptChoice < 1 || deptChoice > 4)
                {
                    throw new InvalidDepartmentException("Invalid department selection.");
                }
                EnmDepartment dept = (EnmDepartment)(deptChoice - 1);

                Console.Write("Enter Salary: ");
                if (!double.TryParse(Console.ReadLine(), out double salary) || salary < 0)
                {
                    throw new InvalidSalaryException("Invalid salary value.");
                }

                Console.Write("Enter Joining Date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime joiningDate))
                {
                    throw new InvalidDateException("Invalid date format.");
                }

                employees.Add(new Employee(id, name, dept, salary, joiningDate));
                Console.WriteLine("Employee added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Displays details of all employees in the system.
        /// </summary>
        public static void ViewAllEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine("\nEmployee Details:");
            foreach (var emp in employees)
            {
                emp.DisplayDetails();
            }
        }

        /// <summary>
        /// Searches for an employee by their ID and displays their details if found.
        /// </summary>
        public static void SearchEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to search: ");
                int id = int.Parse(Console.ReadLine());
                var emp = employees.Find(e => e.Id == id);
                if (emp == null)
                {
                    throw new EmployeeNotFoundException($"No employee found with ID {id}.");
                }
                emp.DisplayDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the details of an existing employee by their ID.
        /// Allows updating name, department, salary, and joining date selectively.
        /// </summary>
        public static void UpdateEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to update: ");
                int id = int.Parse(Console.ReadLine());
                var employee = employees.Find(e => e.Id == id);
                if (employee == null)
                {
                    throw new EmployeeNotFoundException($"No employee found with ID {id}.");
                }

                Console.Write("Enter New Name (Leave blank to keep unchanged): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    employee.Name = name;

                Console.WriteLine("Choose New Department: 1. HR 2. IT 3. Finance 4. Marketing (0 to skip)");
                if (int.TryParse(Console.ReadLine(), out int deptChoice) && deptChoice > 0)
                {
                    if (deptChoice < 1 || deptChoice > 4)
                    {
                        throw new InvalidDepartmentException("Invalid department selection.");
                    }
                    employee.Dept = (EnmDepartment)(deptChoice - 1);
                }

                Console.Write("Enter New Salary (Leave blank to keep unchanged): ");
                string salaryInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(salaryInput) && double.TryParse(salaryInput, out double salary))
                {
                    employee.Salary = salary;
                }

                Console.Write("Enter New Joining Date (Leave blank to keep unchanged): ");
                string dateInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dateInput) && DateTime.TryParse(dateInput, out DateTime joiningDate))
                {
                    employee.JoiningDate = joiningDate.ToShortDateString();
                }

                Console.WriteLine("Employee updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an employee from the system based on their ID.
        /// </summary>
        public static void DeleteEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                var employee = employees.Find(e => e.Id == id);
                if (employee == null)
                {
                    throw new EmployeeNotFoundException($"No employee found with ID {id}.");
                }

                employees.Remove(employee);
                Console.WriteLine("Employee deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        #endregion

        #region File Operations

        /// <summary>
        /// Saves all employee details to a file.
        /// </summary>
        public static void SaveToFile()
        {
            const string filePath = "EmployeeDetails.txt";

            try
            {
                using StreamWriter writer = new StreamWriter(filePath);
                foreach (var emp in employees)
                {
                    writer.WriteLine($"{emp.Id},{emp.Name},{emp.Dept},{emp.Salary},{emp.JoiningDate}");
                }
                Console.WriteLine("Employee details saved successfully.");
            }
            catch (Exception ex)
            {
                throw new EmployeeFileException($"Error saving to file: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads employee details from a file.
        /// </summary>
        public static void LoadFromFile()
        {
            const string filePath = "EmployeeDetails.txt";
            if (!File.Exists(filePath))
            {
                throw new EmployeeFileException("File not found.");
            }

            try
            {
                employees.Clear();
                using StreamReader reader = new StreamReader(filePath);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length != 5)
                    {
                        throw new EmployeeFileException("Invalid data format in file.");
                    }

                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    EnmDepartment dept = Enum.Parse<EnmDepartment>(parts[2]);
                    double salary = double.Parse(parts[3]);
                    DateTime joiningDate = DateTime.Parse(parts[4]);

                    employees.Add(new Employee(id, name, dept, salary, joiningDate));
                }
                Console.WriteLine("Employee details loaded successfully.");
            }
            catch (Exception ex)
            {
                throw new EmployeeFileException($"Error loading from file: {ex.Message}");
            }
        }

        #endregion
    }
}
