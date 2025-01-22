using ORMDemo.BL.Interface;
using ORMDemo.Models;
using ORMDemo.Models.DTO;
using ORMDemo.Models.Enum;
using ORMDemo.Models.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ORMDemo.Extension;
using ServiceStack.OrmLite.Legacy;
using System.Data;

namespace ORMDemo.BL.Operations
{
    /// <summary>
    /// Business logic class for handling student data operations.
    /// </summary>
    public class BLStudent : IDataHandler<DTOSTD01>
    {
        private STD01 _objSTD01; // Holds the student object to be processed.
        private int _id; // Student ID for update operations.
        private Response _objResponse; // Response object to store operation results.
        private readonly IDbConnectionFactory _dbFactory; // Factory to manage database connections.

        /// <summary>
        /// Specifies the type of operation (Add, Edit, etc.).
        /// </summary>
        public EnmType Type { get; set; }

        /// <summary>
        /// Constructor to initialize the BLStudent class.
        /// </summary>
        public BLStudent()
        {
            _objResponse = new Response(); // Initialize response object.
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

            // Validate database factory availability.
            if (_dbFactory == null)
            {
                throw new Exception("IDbConnectionFactory not found");
            }
        }

        /// <summary>
        /// Retrieves all student records from the database.
        /// </summary>
        /// <returns>A list of all students.</returns>
        public List<STD01> GetAll()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Select<STD01>(); // Fetch all student records.
            }
        }

        /// <summary>
        /// Retrieves a student by their ID.
        /// </summary>
        /// <param name="id">Student ID.</param>
        /// <returns>Student object if found, otherwise null.</returns>
        public STD01 Get(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.SingleById<STD01>(id); // Fetch student record by ID.
            }
        }

        /// <summary>
        /// Checks if a student exists in the database by their ID.
        /// </summary>
        /// <param name="id">Student ID.</param>
        /// <returns>True if student exists, otherwise false.</returns>
        private bool IsSTD01Exist(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Exists<STD01>(id); // Check for existence.
            }
        }

        /// <summary>
        /// Validates and fetches a student before deletion.
        /// </summary>
        /// <param name="id">Student ID.</param>
        /// <returns>Student object if valid for deletion, otherwise null.</returns>
        private STD01 PreDelete(int id)
        {
            if (IsSTD01Exist(id))
            {
                return Get(id); // Retrieve student for deletion if exists.
            }
            return null;
        }

        /// <summary>
        /// Validates the deletion of a student record.
        /// </summary>
        /// <param name="objSTD01">Student object.</param>
        /// <returns>Response indicating success or error.</returns>
        private Response ValidateOnDelete(STD01 objSTD01)
        {
            if (objSTD01 == null)
                return new Response { IsError = true, Message = "Student not found." };

            return new Response { IsError = false }; // Valid for deletion.
        }

        /// <summary>
        /// Deletes a student record by ID.
        /// </summary>
        /// <param name="id">Student ID.</param>
        /// <returns>Response indicating the result of the operation.</returns>
        public Response Delete(int id)
        {
            var student = PreDelete(id); // Pre-deletion checks.
            var validationResponse = ValidateOnDelete(student);
            if (validationResponse.IsError)
                return validationResponse; // Abort if validation fails.

            using (var db = _dbFactory.OpenDbConnection())
            {
                db.DeleteById<STD01>(id); // Delete student record by ID.
            }
            _objResponse.Message = "Data Deleted"; // Success message.
            return _objResponse;
        }

        /// <summary>
        /// Prepares the data object for saving (Add or Edit).
        /// </summary>
        /// <param name="objDTO">Data transfer object containing student data.</param>
        public void PreSave(DTOSTD01 objDTO)
        {
            _objSTD01 = objDTO.Convert<STD01>(); // Convert DTO to entity.
            if (Type == EnmType.E && objDTO.D01F01 > 0)
            {
                _id = objDTO.D01F01; // Set ID for editing.
            }
        }

        /// <summary>
        /// Validates the save operation (Add or Edit).
        /// </summary>
        /// <returns>Response indicating validation result.</returns>
        public Response Validation()
        {
            if (Type == EnmType.E) // If editing.
            {
                if (!(_id > 0))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct Id"; // Invalid ID.
                }
                else if (!IsSTD01Exist(_id))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "User Not Found"; // ID not found.
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves a student record (Insert or Update).
        /// </summary>
        /// <returns>Response indicating the result of the operation.</returns>
        public Response Save()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    if (Type == EnmType.A) // Add operation.
                    {
                        db.Insert(_objSTD01); // Insert student record.
                        _objResponse.Message = "Data Added";
                    }
                    if (Type == EnmType.E) // Edit operation.
                    {
                        db.Update(_objSTD01); // Update student record.
                        _objResponse.Message = "Data Updated";
                    }
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message; // Error message.
            }
            return _objResponse;
        }

        // Additional methods with detailed comments.
        /// <summary>
        /// Retrieves students matching a specific condition.
        /// </summary>
        /// <param name="predicate">A condition expressed as a LINQ-style SQL expression.</param>
        /// <returns>A list of students matching the condition.</returns>
        public List<STD01> GetStudentsByCondition(Func<SqlExpression<STD01>, SqlExpression<STD01>> predicate)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                // Apply the predicate to create the SQL expression and fetch matching records.
                var query = db.From<STD01>();
                return db.Select(predicate(query));
            }
        }


        /// <summary>
        /// Retrieves a paginated list of students.
        /// </summary>
        /// <param name="skip">The number of students to skip.</param>
        /// <param name="take">The number of students to take.</param>
        /// <returns>A list of students for the specified page.</returns>
        public List<STD01> GetPaginatedStudents(int skip, int take)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Select<STD01>(q => q.Skip(skip).Take(take));
            }
        }

        /// <summary>
        /// Counts the total number of students.
        /// </summary>
        /// <returns>The total number of students.</returns>
        public long CountStudents()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Count<STD01>();
            }
        }

        /// <summary>
        /// Checks if a student with the specified ID exists.
        /// </summary>
        /// <param name="id">The student ID to check.</param>
        /// <returns>True if the student exists; otherwise, false.</returns>
        public bool StudentExists(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Exists<STD01>(x => x.D01F01 == id);
            }
        }

        /// <summary>
        /// Performs a bulk insert of student records.
        /// </summary>
        /// <param name="students">The list of students to insert.</param>
        /// <returns>The response object containing the result of the operation.</returns>
        public Response BulkInsertStudents(List<STD01> students)
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    db.InsertAll(students);
                    _objResponse.Message = "Bulk Insert Successful";
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }

        /// <summary>
        /// Performs a bulk update of student records.
        /// </summary>
        /// <param name="students">The list of students to update.</param>
        /// <returns>The response object containing the result of the operation.</returns>
        public Response BulkUpdateStudents(List<STD01> students)
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    db.UpdateAll(students);
                    _objResponse.Message = "Bulk Update Successful";
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves the first student record based on the ascending order of IDs.
        /// </summary>
        /// <returns>The first student record.</returns>
        public STD01 GetFirstStudent()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Single<STD01>("Order By D01F01 ASC LIMIT 1");
            }
        }

        /// <summary>
        /// Retrieves the last student record based on the descending order of IDs.
        /// </summary>
        /// <returns>The last student record.</returns>
        public STD01 GetLastStudent()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Single<STD01>("Order By D01F01 DESC LIMIT 1");
            }
        }

        /// <summary>
        /// Executes a transactional operation on the database.
        /// </summary>
        /// <param name="action">The action to perform within the transaction.</param>
        public void PerformTransaction()
        {
            // Open a single connection to the first database
            using (var db = _dbFactory.OpenDbConnection())
            using (var transaction = db.OpenTransaction())
            {
                try
                {
                    // Insert into the first database
                    db.Insert(new STD01
                    {
                        // Fields for the first database
                        D01F01 = 55,
                        D01F02 = "asdf",
                        D01F03 = 21,
                        D01F04 = 1,
                        D01F05 = 80,
                        D01F06 = 'a'
                    });

                    // Switch to the second database
                    db.ChangeDatabase("college2");

                    // Insert into the second database
                    db.Insert(new STD01
                    {
                        // Fields for the second database
                        D01F01 = 55,
                        D01F02 = "asdf",
                        D01F03 = 21,
                        D01F04 = 1,
                        D01F05 = 80,
                        D01F06 = 'a'
                    });

                    // Commit the transaction if both inserts succeed
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback transaction on failure
                    transaction.Rollback();
                    throw new Exception("Transaction failed: " + ex.Message);
                }
            }
        }


        /// <summary>
        /// Calculates the average age of students.
        /// </summary>
        /// <returns>The average age of all students.</returns>
        public double GetAverageAgeOfStudent()
        {
            using (IDbConnection objIDbConnection = _dbFactory.OpenDbConnection())
            {
                return objIDbConnection.Scalar<double>("SELECT AVG(D01F03) FROM STD01");
            }
        }
    }
}
