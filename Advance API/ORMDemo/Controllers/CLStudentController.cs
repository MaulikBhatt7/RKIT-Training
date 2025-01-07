using ORMDemo.BL.Operations;
using ORMDemo.Models;
using ORMDemo.Models.DTO;
using ORMDemo.Models.Enum;
using System.Web.Http;

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
    }
}