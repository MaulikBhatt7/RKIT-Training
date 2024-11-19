using System.Collections.Generic;
using System.Data;
using System.IO;
using System;

namespace EmployeeManagement
{
    // Enumeration for Department types
    public enum EnmDepartment
    {
        HR,
        IT,
        Finance,
        Marketing
    }

    // Interface for basic employee operations
    public interface IEmployeeOperations
    {
        // Displays the details of an employee
        void DisplayDetails();
    }

    // Represents an Employee with properties like ID, Name, Department, and Salary
    public class Employee : IEmployeeOperations
    {
        public int Id { get; set; }             // Unique identifier for the employee
        public string Name { get; set; }       // Name of the employee
        public EnmDepartment Dept { get; set; } // Department of the employee
        public double Salary { get; set; }     // Salary of the employee

        protected string joiningDate;          // Joining date stored as a string

        // Constructor to initialize the Employee object
        public Employee(int id, string name, EnmDepartment dept, double salary, DateTime joiningDate)
        {
            Id = id;
            Name = name;
            Dept = dept;
            Salary = salary;
            this.joiningDate = joiningDate.ToShortDateString();
        }

        // Displays the details of the employee
        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Department: {Dept}, Salary: {Salary:C}, Joining Date: {joiningDate}");
        }

        // Gets the joining date of the employee
        public DateTime GetJoiningDate()
        {
            return DateTime.Parse(joiningDate);
        }
    }

    // Main Program class to demonstrate employee management
    public class Program
    {
        // Entry point of the program
        public static void RunDemo()
        {
            try
            {
                // Number of employees
                int empCount = 3;

                // Initializing the employee array
                Employee[] employees = new Employee[empCount];

                // Adding employees to the array
                employees[0] = new Employee(1, "Alice", EnmDepartment.HR, 45000, DateTime.Now.AddYears(-3));
                employees[1] = new Employee(2, "Bob", EnmDepartment.IT, 55000, DateTime.Now.AddYears(-5));
                employees[2] = new Employee(3, "Charlie", EnmDepartment.Finance, 50000, DateTime.Now.AddYears(-2));

                // Converting array to a list for collections
                List<Employee> employeeList = new List<Employee>(employees);

                // Displaying employee details
                Console.WriteLine("\nEmployee Details:");
                foreach (var emp in employeeList)
                {
                    emp.DisplayDetails();
                }

                // Displaying employee join dates
                Console.WriteLine("\nEmployee Join Dates:");
                foreach (var emp in employeeList)
                {
                    Console.WriteLine($"{emp.Name}'s Join Date: {emp.GetJoiningDate().ToLongDateString()}");
                }

                // Searching employees by department
                string searchDept = "IT";
                Console.WriteLine($"\nSearching for employees in {searchDept} department...");
                foreach (var emp in employeeList)
                {
                    if (emp.Dept.ToString() == searchDept)
                    {
                        Console.WriteLine($"Found: {emp.Name}");
                    }
                }

                // Using DataTable to store employee details
                DataTable empTable = new DataTable("EmployeeTable");
                empTable.Columns.Add("ID", typeof(int));
                empTable.Columns.Add("Name", typeof(string));
                empTable.Columns.Add("Department", typeof(string));
                empTable.Columns.Add("Salary", typeof(double));

                foreach (var emp in employeeList)
                {
                    empTable.Rows.Add(emp.Id, emp.Name, emp.Dept.ToString(), emp.Salary);
                }

                Console.WriteLine("\nEmployee Table:");
                foreach (DataRow row in empTable.Rows)
                {
                    Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}, Department: {row["Department"]}, Salary: {row["Salary"]}");
                }

                // Writing employee details to a file
                string filePath = "EmployeeDetails.txt";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var emp in employeeList)
                    {
                        writer.WriteLine($"{emp.Id},{emp.Name},{emp.Dept},{emp.Salary},{emp.GetJoiningDate()}");
                    }
                }
                Console.WriteLine($"\nEmployee details saved to {filePath}.");

            }
            catch (Exception ex)
            {
                // Handling any errors
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


        }
    }
}