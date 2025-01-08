using System.Collections.Generic;
using System.Web.Http;
using CRUDDemo.BL;
using CRUDDemo.BL.Operations;
using CRUDDemo.Models;
using CRUDDemo.Models.Enum;
using CRUDDemo.Models.DTO;
using CRUDDemo.Models.POCO;

namespace CRUDDemo.Controllers
{
    /// <summary>
    /// Controller to manage student-related API operations.
    /// </summary>
    public class CLStudentController : ApiController
    {
        /// <summary>
        /// Response object to hold operation results.
        /// </summary>
        Response _objResponse = new Response();

        /// <summary>
        /// Business logic layer object to handle student operations.
        /// </summary>
        BLStudent _objBLStudent = new BLStudent();
        BLConverter _objBLConverter = new BLConverter();

        /// <summary>
        /// Retrieves a list of all students.
        /// </summary>
        /// <returns>Object of Response.</returns>
        [Route("get-all-students")]
        public Response GetAllStudent()
        {
            // Fetch all student records from the business logic layer
            List<STD01> lstStudents = _objBLStudent.GetAllStudents();

            // Check if any students were retrieved
            if (lstStudents.Count > 0)
            {
                // Convert student list to DataTable and add to response
                _objResponse.Data = _objBLConverter.ToDataTable(lstStudents);
                _objResponse.Message = "Data Get Successfully";
            }
            else
            {
                // Handle case where no data is found
                _objResponse.IsError = true;
                _objResponse.Message = "No Data Found";
            }
            return _objResponse; // Return the response object
        }

        /// <summary>
        /// Retrieves a student by their ID.
        /// </summary>
        /// <param name="id">Student ID.</param>
        /// <returns>object of Response.</returns>
        [Route("get-student-by-id")]
        public IHttpActionResult GetStudentByID(int id)
        {
            // Retrieve student record by ID
            STD01 objSTD01 = _objBLStudent.GetStudentByID(id);

            // Check if student record exists
            if (objSTD01 == null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "No Data Found";
            }
            else
            {
                // Convert the student object to DataTable and add to response
                _objResponse.Data = _objBLConverter.ObjectToDataTable(objSTD01);
                _objResponse.Message = "Data Get Successfully";
            }
            return Ok(_objResponse); // Return the response
        }

        /// <summary>
        /// Deletes a student by their ID.
        /// </summary>
        /// <param name="id">Student ID to be deleted.</param>
        /// <returns>Response object indicating success or failure.</returns>
        [HttpDelete]
        [Route("delete-student")]
        public IHttpActionResult Delete(int id)
        {
            // Set the operation type to "Delete"
            _objBLStudent.Type = EnmEntryType.D;

            // Perform the delete operation and store the response
            _objResponse = _objBLStudent.Delete(id);

            // Return the response
            return Ok(_objResponse);
        }

        /// <summary>
        /// Adds a new student to the database.
        /// </summary>
        /// <param name="objDTOSTD01">Student data transfer object containing student details.</param>
        /// <returns>Response object indicating success or failure of the operation.</returns>
        [HttpPost]
        [Route("add-student")]
        public IHttpActionResult AddStudent(DTOSTD01 objDTOSTD01)
        {
            // Set the operation type to "Add"
            _objBLStudent.Type = EnmEntryType.A;

            // Prepare the student object for saving
            _objBLStudent.PreSave(objDTOSTD01);

            // Validate the student data
            _objResponse = _objBLStudent.Validation();

            // If validation passes, save the student record
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLStudent.Save();
            }

            // Return the response
            return Ok(_objResponse);
        }

        /// <summary>
        /// Updates an existing student's information.
        /// </summary>
        /// <param name="objDTOSTD01">Student data transfer object containing updated details.</param>
        /// <returns>Response object indicating success or failure of the operation.</returns>
        [HttpPut]
        [Route("update-student")]
        public IHttpActionResult UpdateStudent(DTOSTD01 objDTOSTD01)
        {
            // Set the operation type to "Edit"
            _objBLStudent.Type = EnmEntryType.E;

            // Prepare the student object for saving
            _objBLStudent.PreSave(objDTOSTD01);

            // Validate the student data
            _objResponse = _objBLStudent.Validation();

            // If validation passes, save the updated student record
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLStudent.Save();
            }

            // Return the response
            return Ok(_objResponse);
        }
    }
}
