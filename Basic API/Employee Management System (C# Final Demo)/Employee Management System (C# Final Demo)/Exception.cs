using System;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Exception for invalid employee ID.
    /// </summary>
    public class InvalidIdException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidIdException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidIdException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception for invalid department selection.
    /// </summary>
    public class InvalidDepartmentException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidDepartmentException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidDepartmentException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception for invalid salary input.
    /// </summary>
    public class InvalidSalaryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSalaryException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidSalaryException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception for invalid joining date.
    /// </summary>
    public class InvalidDateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidDateException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidDateException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when an employee is not found.
    /// </summary>
    public class EmployeeNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeNotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public EmployeeNotFoundException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception for file-related errors in employee operations.
    /// </summary>
    public class EmployeeFileException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeFileException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public EmployeeFileException(string message) : base(message) { }
    }
}
