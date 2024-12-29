using System;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Enumeration for different departments in the organization.
    /// </summary>
    public enum EnmDepartment
    {
        HR,
        IT,
        Finance,
        Marketing
    }

    /// <summary>
    /// Represents an employee with basic information such as ID, Name, Department, Salary, and Joining Date.
    /// Implements <see cref="IEmployeeOperations"/>.
    /// </summary>
    public class Employee : IEmployeeOperations
    {


        #region Public Properties
        
        /// <summary> Gets or sets the unique employee ID. </summary>
        public int Id { get; set; }

        /// <summary> Gets or sets the employee's full name. </summary>
        public string Name { get; set; }

        /// <summary> Gets or sets the department the employee belongs to. </summary>
        public EnmDepartment Dept { get; set; }

        /// <summary> Gets or sets the salary of the employee. </summary>
        public double Salary { get; set; }

        /// <summary> Gets or sets the joining date of the employee. </summary>
        public DateTime JoiningDate { get; set; }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Displays the employee's details on the console.
        /// </summary>
        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Department: {Dept}, Salary: {Salary}, Joining Date: {JoiningDate}");
        }

        #endregion
    }
}
