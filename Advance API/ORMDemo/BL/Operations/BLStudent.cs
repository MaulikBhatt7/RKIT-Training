using ORMDemo.BL.Interface;
using ORMDemo.Models;
using ORMDemo.Models.DTO;
using ORMDemo.Models.Enum;
using ORMDemo.Models.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Web;
using ORMDemo.Extension;

namespace ORMDemo.BL.Operations
{
    /// <summary>
    /// Business logic class for handling student data operations.
    /// </summary>
    public class BLStudent : IDataHandler<DTOSTD01>
    {
        /// <summary>
        /// Object to hold student data.
        /// </summary>
        private STD01 _objSTD01;

        /// <summary>
        /// Student ID for update operations.
        /// </summary>
        private int _id;

        /// <summary>
        /// Response object to return operation results.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Database connection factory.
        /// </summary>
        private readonly IDbConnectionFactory _dbFactory;

        /// <summary>
        /// Type of operation (Add, Edit, etc.).
        /// </summary>
        public EnmType Type { get; set; }

        /// <summary>
        /// Constructor to initialize the BLStudent class.
        /// </summary>
        public BLStudent()
        {
            _objResponse = new Response();  // Initialize response object.
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

            // Check if the database factory is available.
            if (_dbFactory == null)
            {
                throw new Exception("IDbConnectionFactory not found");
            }
        }

        /// <summary>
        /// Retrieves all students from the database.
        /// </summary>
        /// <returns>A list of all students.</returns>
        public List<STD01> GetAll()
        {
            using (var db = _dbFactory.OpenDbConnection())  // Open database connection.
            {
                List<STD01> students = db.Select<STD01>();  // Select all students from the database.
                return students;
            }
        }

        /// <summary>
        /// Retrieves a specific student by ID from the database.
        /// </summary>
        /// <param name="id">Student ID.</param>
        /// <returns>Student object if found, otherwise null.</returns>
        public STD01 Get(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())  // Open database connection.
            {
                var employee = db.SingleById<STD01>(id);  // Retrieve student by ID.
                return employee;
            }
        }

        /// <summary>
        /// Checks if a student exists by ID.
        /// </summary>
        /// <param name="id">Student ID.</param>
        /// <returns>True if the student exists, otherwise false.</returns>
        private bool IsSTD01Exist(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())  // Open database connection.
            {
                return db.Exists<STD01>(id);  // Check if student exists in the database.
            }
        }

        /// <summary>
        /// Pre-delete checks and retrieves the student object.
        /// </summary>
        /// <param name="id">Student ID.</param>
        /// <returns>The student object if found, otherwise null.</returns>
        private STD01 PreDelete(int id)
        {
            bool isStudentExist = IsSTD01Exist(id);  // Check if student exists.
            if (isStudentExist)
            {
                STD01 objSTD01 = Get(id);  // Retrieve student if exists.
                return objSTD01;
            }
            return null;  // Return null if student does not exist.
        }

        /// <summary>
        /// Validates if the student can be deleted.
        /// </summary>
        /// <param name="objSTD01">Student object.</param>
        /// <returns>Response indicating success or failure.</returns>
        private Response ValidateOnDelete(STD01 objSTD01)
        {
            if (objSTD01 == null)
                return new Response { IsError = true, Message = "Student not found." };

            return new Response { IsError = false };  // Validation passed.
        }

        /// <summary>
        /// Deletes a student from the database by ID.
        /// </summary>
        /// <param name="id">Student ID.</param>
        /// <returns>Response indicating the result of the operation.</returns>
        public Response Delete(int id)
        {
            var student = PreDelete(id);  // Pre-delete checks.
            var validationResponse = ValidateOnDelete(student);  // Validate delete operation.
            if (validationResponse.IsError)
                return validationResponse;  // Return error response if validation fails.

            using (var db = _dbFactory.OpenDbConnection())  // Open database connection.
            {
                db.DeleteById<STD01>(id);  // Delete student by ID.
            }
            _objResponse.Message = "Data Deleted";  // Success message.
            return _objResponse;
        }

        /// <summary>
        /// Prepares the data to be saved (either added or edited).
        /// </summary>
        /// <param name="objDTO">Student data transfer object.</param>
        public void PreSave(DTOSTD01 objDTO)
        {
            _objSTD01 = objDTO.Convert<STD01>();  // Convert DTO to student object.
            if (Type == EnmType.E)  // If it's an Edit operation.
            {
                if (objDTO.D01F01 > 0)
                {
                    _id = objDTO.D01F01;  // Set the student ID for editing.
                }
            }
        }

        /// <summary>
        /// Validates if the operation (Add or Edit) can be performed.
        /// </summary>
        /// <returns>Response indicating validation result.</returns>
        public Response Validation()
        {
            if (Type == EnmType.E)  // If it's an Edit operation.
            {
                if (!(_id > 0))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct Id";  // Invalid ID for Edit.
                }
                else
                {
                    bool isEMP01 = IsSTD01Exist(_id);  // Check if student exists.
                    if (!isEMP01)
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "User Not Found";  // Student not found.
                    }
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves (inserts or updates) the student data in the database.
        /// </summary>
        /// <returns>Response indicating the result of the operation.</returns>
        public Response Save()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())  // Open database connection.
                {
                    if (Type == EnmType.A)  // If it's an Add operation.
                    {
                        db.Insert(_objSTD01);  // Insert new student.
                        _objResponse.Message = "Data Added";  // Success message for add.
                    }
                    if (Type == EnmType.E)  // If it's an Edit operation.
                    {
                        db.Update(_objSTD01);  // Update existing student.
                        _objResponse.Message = "Data Updated";  // Success message for update.
                    }
                }

            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;  // Error message on failure.
            }
            return _objResponse;
        }
    }
}
