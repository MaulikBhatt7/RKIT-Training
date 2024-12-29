using System;


namespace EmployeeManagementSystem
{
    /// <summary>
    /// Abstract class defining the blueprint for employee operations.
    /// </summary>
    public abstract class EmployeeOperationsBase
    {

        #region PublicMethods
        /// <summary>
        /// Abstract method to add an employee.
        /// </summary>
        public abstract void AddEmployee();

        /// <summary>
        /// Abstract method to view all employees.
        /// </summary>
        public abstract void ViewAllEmployees();

        /// <summary>
        /// Abstract method to search for an employee by ID.
        /// </summary>
        public abstract void SearchEmployee();

        /// <summary>
        /// Abstract method to update an employee's details.
        /// </summary>
        public abstract void UpdateEmployee();

        /// <summary>
        /// Abstract method to delete an employee.
        /// </summary>
        public abstract void DeleteEmployee();

        /// <summary>
        /// Abstract method to save employee details to a file.
        /// </summary>
        public abstract void SaveToFile();

        /// <summary>
        /// Abstract method to load employee details from a file.
        /// </summary>
        public abstract void LoadFromFile();

        #endregion
    }
}
