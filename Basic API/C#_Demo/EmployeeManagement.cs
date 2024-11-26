using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeManagementSystem
{

    #region Custom Exception
    /// <summary>
    /// Exception for invalid employee ID.
    /// </summary>
    public class InvalidIdException : Exception
    {
        public InvalidIdException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception for invalid department selection.
    /// </summary>
    public class InvalidDepartmentException : Exception
    {
        public InvalidDepartmentException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception for invalid salary input.
    /// </summary>
    public class InvalidSalaryException : Exception
    {
        public InvalidSalaryException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception for invalid joining date.
    /// </summary>
    public class InvalidDateException : Exception
    {
        public InvalidDateException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when an employee is not found.
    /// </summary>
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(string message) : base(message) { }
    }


    /// <summary>
    /// Custom exception class for handling file-related errors.
    /// </summary>
    public class EmployeeFileException : Exception
    {
        public EmployeeFileException(string message) : base(message) { }
    }

    #endregion

    /// <summary>
    /// Enumeration for employee departments.
    /// </summary>
    public enum EnmDepartment
    {
        HR,
        IT,
        Finance,
        Marketing
    }

    /// <summary>
    /// Interface for employee operations like displaying details.
    /// </summary>
    public interface IEmployeeOperations
    {
        /// <summary>
        /// Displays employee details.
        /// </summary>
        void DisplayDetails();
    }

    /// <summary>
    /// Manages employee details, implements IEmployeeOperations.
    /// </summary>
    public class Employee : IEmployeeOperations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnmDepartment Dept { get; set; }
        public double Salary { get; set; }
        public string JoiningDate { get; set; }

        /// <summary>
        /// Constructor for initializing employee details.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="name">Employee Name</param>
        /// <param name="dept">Employee Department</param>
        /// <param name="salary">Employee Salary</param>
        /// <param name="joiningDate">Employee Joining Date</param>
        public Employee(int id, string name, EnmDepartment dept, double salary, DateTime joiningDate)
        {
            Id = id;
            Name = name;
            Dept = dept;
            Salary = salary;
            JoiningDate = joiningDate.ToShortDateString();
        }

        /// <summary>
        /// Displays the employee's details.
        /// </summary>
        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Department: {Dept}, Salary: {Salary}, Joining Date: {JoiningDate}");
        }
    }

    /// <summary>
    /// Class for performing employee-related operations like add, view, update, delete, search and file operations.
    /// </summary>
    public class Operations
    {
        private static List<Employee> employees = new List<Employee>();


        #region All Operations

        /// <summary>
        /// Adds a new employee to the list.
        /// </summary>
        public static void AddEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID: ");
                string idInput = Console.ReadLine();
                if (!int.TryParse(idInput, out int id) || id <= 0)
                {
                    throw new InvalidIdException($"Invalid ID: {idInput}. Please enter a valid positive integer.");
                }

                // Check if the ID already exists in the list.
                if (employees.Exists(e => e.Id == id))
                {
                    throw new InvalidIdException($"Employee ID {id} already exists. Please enter a unique ID.");
                }

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Choose Department: 1. HR 2. IT 3. Finance 4. Marketing");
                int deptChoice = int.Parse(Console.ReadLine());

                // Validating department choice
                if (deptChoice < 1 || deptChoice > 4)
                {
                    throw new InvalidDepartmentException($"Invalid department choice: {deptChoice}. Please choose a number between 1 and 4.");
                }
                EnmDepartment dept = (EnmDepartment)(deptChoice - 1);

                // Salary Validation
                Console.Write("Enter Salary: ");
                string salaryInput = Console.ReadLine();
                double salary;
                if (!double.TryParse(salaryInput, out salary))
                {
                    throw new InvalidSalaryException($"Invalid salary value: {salaryInput}. Please enter a valid number.");
                }

                // Date Validation
                Console.Write("Enter Joining Date (yyyy-MM-dd): ");
                string dateInput = Console.ReadLine();
                DateTime joiningDate;
                if (!DateTime.TryParse(dateInput, out joiningDate))
                {
                    throw new InvalidDateException($"Invalid date format: {dateInput}. Please enter a valid date in the format yyyy-MM-dd.");
                }

                employees.Add(new Employee(id, name, dept, salary, joiningDate));
                Console.WriteLine("Employee added successfully.");
            }
            catch (InvalidIdException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidDepartmentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidSalaryException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidDateException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Displays all employee details.
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
        /// Searches employees by department.
        /// </summary>
        public static void SearchEmployee()
        {
            Console.WriteLine("Enter ID of Employee to search : ");
            int id = int.Parse(Console.ReadLine());

            var emp = employees.Find(e => e.Id == id);
            if (emp == null)
            {
                throw new EmployeeNotFoundException($"No employee found with ID {id}.");
            }

            emp.DisplayDetails();
        }

        /// <summary>
        /// Updates an employee's details.
        /// </summary>
        public static void UpdateEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to update: ");
                string idInput = Console.ReadLine();
                if (!int.TryParse(idInput, out int id) || id <= 0)
                {
                    throw new InvalidIdException($"Invalid ID: {idInput}. Please enter a valid positive integer.");
                }

                Employee employee = employees.Find(e => e.Id == id);
                if (employee == null)
                {
                    throw new EmployeeNotFoundException($"No employee found with ID {id}");
                }

                Console.Write("Enter New Name (Leave blank to keep unchanged): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                    employee.Name = name;

                Console.WriteLine("Choose New Department: 1. HR 2. IT 3. Finance 4. Marketing (0 to skip): ");
                string deptInput = Console.ReadLine();

                // Only update department if user input is valid
                if (int.TryParse(deptInput, out int deptChoice) && deptChoice > 0)
                {
                    if (deptChoice < 1 || deptChoice > 4)
                    {
                        throw new InvalidDepartmentException($"Invalid department choice: {deptChoice}. Please choose a number between 1 and 4.");
                    }

                    employee.Dept = (EnmDepartment)(deptChoice - 1);
                }

                // Salary Validation
                Console.Write("Enter New Salary (0 to skip): ");
                string salaryInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(salaryInput) && !double.TryParse(salaryInput, out double salary))
                {
                    throw new InvalidSalaryException($"Invalid salary value: {salaryInput}. Please enter a valid number.");
                }
                if (!string.IsNullOrEmpty(salaryInput))
                {
                    employee.Salary = double.Parse(salaryInput);
                }

                // Date Validation (only if user wants to update)
                Console.Write("Enter New Joining Date (Leave blank to keep unchanged): ");
                string dateInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(dateInput))
                {
                    DateTime joiningDate;
                    if (!DateTime.TryParse(dateInput, out joiningDate))
                    {
                        throw new InvalidDateException($"Invalid date format: {dateInput}. Please enter a valid date in the format yyyy-MM-dd.");
                    }
                    employee.JoiningDate = joiningDate.ToShortDateString();
                }

                Console.WriteLine("Employee updated successfully.");
            }
            catch (InvalidIdException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidDepartmentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidSalaryException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidDateException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an employee from the list by ID.
        /// </summary>
        public static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Employee employee = employees.Find(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public static void SaveToFile()
        {
            string filePath = "EmployeeDetails.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var emp in employees)
                    {
                        writer.WriteLine($"{emp.Id},{emp.Name},{emp.Dept},{emp.Salary},{emp.JoiningDate}");
                    }
                }
                Console.WriteLine($"Employee details saved to {filePath}.");
            }
            catch (Exception ex)
            {
                throw new EmployeeFileException("Error saving to file: " + ex.Message);
            }
        }

        public static void LoadFromFile()
        {
            string filePath = "EmployeeDetails.txt";

            if (!File.Exists(filePath))
                throw new EmployeeFileException($"File {filePath} not found.");

            try
            {
                employees.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length != 5)
                            throw new EmployeeFileException("Invalid data format in file.");

                        int id = int.Parse(parts[0]);
                        string name = parts[1];

                        // Using Enum.TryParse for case insensitivity
                        EnmDepartment dept;
                        if (!Enum.TryParse(parts[2], true, out dept)) // true makes it case-insensitive
                        {
                            throw new EmployeeFileException($"Invalid department value '{parts[2]}' in the file.");
                        }

                        double salary = double.Parse(parts[3]);
                        DateTime joiningDate = DateTime.Parse(parts[4]);

                        employees.Add(new Employee(id, name, dept, salary, joiningDate));
                    }
                }
                Console.WriteLine("Employee details loaded successfully.");
            }
            catch (Exception ex)
            {
                throw new EmployeeFileException("Error loading from file: " + ex.Message);
            }
        }

        #endregion

    }
    public class EmployeeManagementSystem
    {
        public static void RunDemo()
        {
            int choice;
            do
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Save to File");
                Console.WriteLine("7. Load from File");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Operations.AddEmployee();
                            break;
                        case 2:
                            Operations.ViewAllEmployees();
                            break;
                        case 3:
                            Operations.SearchEmployee();
                            break;
                        case 4:
                            Operations.UpdateEmployee();
                            break;
                        case 5:
                            Operations.DeleteEmployee();
                            break;
                        case 6:
                            Operations.SaveToFile();
                            break;
                        case 7:
                            Operations.LoadFromFile();
                            break;
                        case 8:
                            Console.WriteLine("Exiting the system.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (choice != 8);
        }
    }

}





