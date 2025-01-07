using ORMDemo.BL.Operations;
using ORMDemo.Models;
using ORMDemo.Models.POCO;
using ORMDemo.Models.DTO;
using ORMDemo.Models.Enum;
using System.Web.Http;
using System.Collections.Generic;
using ServiceStack.OrmLite;
using System;

namespace ORMDemo.Controllers
{
    /// <summary>
    /// Controller to manage student-related API operations.
    /// </summary>
    public class CLStudentController : ApiController
    {
        /// <summary>
        /// Response object to hold operation results.
        /// </summary>
        Response _objResponse;

        /// <summary>
        /// Business logic layer object to handle student operations.
        /// </summary>
        BLStudent _objBLStudent = new BLStudent();

        /// <summary>
        /// Retrieves a list of all students.
        /// </summary>
        /// <returns>List of students in JSON format.</returns>
        [Route("get-all-students")]
        public IHttpActionResult GetAllStudent()
        {
            var students = _objBLStudent.GetAll();  // Get all students from the business logic layer.
            return Ok(students);  // Return students as HTTP response.
        }

        /// <summary>
        /// Retrieves a student by their ID.
        /// </summary>
        /// <param name="id">Student ID.</param>
        /// <returns>Student object in JSON format if found, otherwise an error message.</returns>
        [Route("get-student-by-id")]
        public IHttpActionResult GetStudentByID(int id)
        {
            var student = _objBLStudent.Get(id);  // Retrieve student by ID from the business logic layer.
            return Ok(student);  // Return the student object as HTTP response.
        }

        /// <summary>
        /// Deletes a student by their ID.
        /// </summary>
        /// <param name="id">Student ID to be deleted.</param>
        /// <returns>Response message indicating success or failure.</returns>
        [HttpDelete]
        [Route("delete-student")]
        public IHttpActionResult Delete(int id)
        {
            _objResponse = _objBLStudent.Delete(id);  // Delete student and get response.
            return Ok(_objResponse);  // Return response message.
        }

        /// <summary>
        /// Adds a new student to the database.
        /// </summary>
        /// <param name="objDTOSTD01">Student data transfer object containing student details.</param>
        /// <returns>Response message indicating success or failure of the operation.</returns>
        [HttpPost]
        [Route("add-student")]
        public IHttpActionResult AddStudent(DTOSTD01 objDTOSTD01)
        {
            _objBLStudent.Type = EnmType.A;  // Set operation type to "Add".
            _objBLStudent.PreSave(objDTOSTD01);  // Prepare data for saving.
            _objResponse = _objBLStudent.Validation();  // Validate data before saving.
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLStudent.Save();  // Save the new student if no validation errors.
            }
            return Ok(_objResponse);  // Return response with operation result.
        }

        /// <summary>
        /// Updates an existing student's information.
        /// </summary>
        /// <param name="objDTOSTD01">Student data transfer object containing updated details.</param>
        /// <returns>Response message indicating success or failure of the operation.</returns>
        [HttpPut]
        [Route("update-student")]
        public IHttpActionResult UpdateStudent(DTOSTD01 objDTOSTD01)
        {
            _objBLStudent.Type = EnmType.E;  // Set operation type to "Edit".
            _objBLStudent.PreSave(objDTOSTD01);  // Prepare data for saving.
            _objResponse = _objBLStudent.Validation();  // Validate data before saving.
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLStudent.Save();  // Save the updated student if no validation errors.
            }
            return Ok(_objResponse);  // Return response with operation result.
        }


        /// <summary>
        /// Gets the first student record.
        /// </summary>
        /// <returns>The first student record.</returns>
        [HttpGet]
        [Route("get-first-student")]
        public IHttpActionResult GetFirstStudent()
        {
            STD01 objSTD01 = _objBLStudent.GetFirstStudent();
            return Ok(objSTD01);
        }

        /// <summary>
        /// Gets the last student record.
        /// </summary>
        /// <returns>The last student record.</returns>
        [HttpGet]
        [Route("get-last-student")]
        public IHttpActionResult GetLastStudent()
        {
            STD01 objSTD01 = _objBLStudent.GetLastStudent();
            return Ok(objSTD01);
        }

        /// <summary>
        /// Gets the total count of students.
        /// </summary>
        /// <returns>The total count of students.</returns>
        [HttpGet]
        [Route("get-count-of-students")]
        public IHttpActionResult CountStudent()
        {
            long totalStudents = _objBLStudent.CountStudents();
            return Ok("Total Students : " + totalStudents);
        }

        /// <summary>
        /// Checks if a student exists by their ID.
        /// </summary>
        /// <param name="id">The student ID.</param>
        /// <returns>True if the student exists; otherwise, false.</returns>
        [HttpGet]
        [Route("check-student-exists-or-not")]
        public IHttpActionResult IsStudentExists(int id)
        {
            bool isExists = _objBLStudent.StudentExists(id);
            return Ok("Is Student Exists? : " + isExists);
        }

        /// <summary>
        /// Gets a paginated list of students.
        /// </summary>
        /// <param name="skip">The number of students to skip.</param>
        /// <param name="take">The number of students to take.</param>
        /// <returns>A paginated list of students.</returns>
        [HttpGet]
        [Route("get-paginated-students")]
        public IHttpActionResult GetPaginatedStudents(int skip, int take)
        {
            List<STD01> objSTD01 = _objBLStudent.GetPaginatedStudents(skip, take);
            return Ok(objSTD01);
        }

        /// <summary>
        /// Gets students who meet the condition of having marks greater than 50.
        /// </summary>
        /// <returns>A list of students with marks greater than 50.</returns>
        [HttpGet]
        [Route("get-students-by-condition(more than 50 marks)")]
        public IHttpActionResult GetStudentsByCondition()
        {
            List<STD01> objSTD01 = _objBLStudent.GetStudentsByCondition(q => q.Where(x => x.D01F05 > 50));
            return Ok(objSTD01);
        }

        /// <summary>
        /// Gets the average age of all students.
        /// </summary>
        /// <returns>The average age of students.</returns>
        [HttpGet]
        [Route("get-average-of-students")]
        public IHttpActionResult GetAverageAgeOfStudent()
        {
            double averageAge = _objBLStudent.GetAverageAgeOfStudent();
            return Ok("Average age of students : " + averageAge);
        }

        /// <summary>
        /// Inserts multiple student records into the database.
        /// </summary>
        /// <param name="students">The list of students to insert.</param>
        /// <returns>The result of the insertion operation.</returns>
        [HttpPost]
        [Route("insert-multiple-students")]
        public IHttpActionResult InsertMultipleStudents([FromBody] List<STD01> students)
        {
            if (students == null || students.Count == 0)
            {
                return BadRequest("No students provided for insertion.");
            }
            try
            {
                _objResponse = _objBLStudent.BulkInsertStudents(students);
                return Ok(_objResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Updates multiple student records in the database.
        /// </summary>
        /// <param name="students">The list of students to update.</param>
        /// <returns>The result of the update operation.</returns>
        [HttpPut]
        [Route("update-multiple-students")]
        public IHttpActionResult UpdateMultipleStudents([FromBody] List<STD01> students)
        {
            if (students == null || students.Count == 0)
            {
                return BadRequest("No students provided for update.");
            }
            try
            {
                _objResponse = _objBLStudent.BulkUpdateStudents(students);
                return Ok(_objResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}