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

        #region Private Properties
        #endregion

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
        public string JoiningDate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for the employee.</param>
        /// <param name="name">Name of the employee.</param>
        /// <param name="dept">Department of the employee.</param>
        /// <param name="salary">Salary of the employee.</param>
        /// <param name="joiningDate">Date the employee joined.</param>
        public Employee(int id, string name, EnmDepartment dept, double salary, DateTime joiningDate)
        {
            Id = id;
            Name = name;
            Dept = dept;
            Salary = salary;
            JoiningDate = joiningDate.ToShortDateString();
        }

        #endregion

        #region Private Methods
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
