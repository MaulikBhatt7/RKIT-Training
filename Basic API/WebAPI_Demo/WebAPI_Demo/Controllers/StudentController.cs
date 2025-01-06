using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI_Demo.Models;


namespace WebAPI_Demo.Controllers
{
    /// <summary>
    /// Controller class to handle HTTP requests for Student entities.
    /// </summary>
    /// 

    
    public class StudentController : ApiController
    {
        private readonly StudentRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentController"/> class.
        /// </summary>
        public StudentController()
        {
            _repository = new StudentRepository();
        }

        /// <summary>
        /// Retrieves all students (API Version 1).
        /// </summary>
        /// <returns>A list of students.</returns>
        [HttpGet]
        [Route("api/v1/students")]
        public IHttpActionResult GetAllStudentsV1()
        {
            var students = _repository.GetAllStudents();

            if (students == null)
                return NotFound();

            return Ok(students);
        }



        /// <summary>
        /// Retrieves all students (API Version 2).
        /// Adds pagination for version 2.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="pageSize">The number of students per page.</param>
        /// <returns>A paginated list of students.</returns>
        [HttpGet]
        [Route("api/v2/students")]
        public IHttpActionResult GetAllStudentsV2(int page = 1, int pageSize = 2    )
        {
            var students = _repository.GetAllStudents();

            if (students == null)
                return NotFound();

            // Apply pagination
            var paginatedStudents = students
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return Ok(paginatedStudents);
        }

        ///// <summary>
        ///// Retrieves a student by their ID.
        ///// </summary>
        ///// <param name="id">The ID of the student to retrieve.</param>
        ///// <returns>The student with the specified ID.</returns>
        //[HttpGet]
        //[Route("api/students/{id}")]
        //public IHttpActionResult GetStudentById(int id)
        //{
        //    var student = _repository.GetStudentById(id);

        //    if (student == null)
        //        return NotFound();

        //    return Ok(student);
        //}

        /// <summary>
        /// Adds a new student.
        /// </summary>
        /// <param name="student">The student object to add.</param>
        /// <returns>The result of the operation.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("api/students")]
        public IHttpActionResult AddStudent(StudentModel student)
        {
            if (student == null)
                return BadRequest("Student data cannot be null.");

            var result = _repository.AddStudent(student);

            if (result > 0)
                return Ok("Student added successfully.");

            return BadRequest("Failed to add student.");
        }

        /// <summary>
        /// Updates an existing student.
        /// </summary>
        /// <param name="student">The student object with updated data.</param>
        /// <returns>The result of the operation.</returns>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("api/students")]
        public IHttpActionResult UpdateStudent(StudentModel student)
        {
            if (student == null)
                return BadRequest("Student data cannot be null.");

            var result = _repository.UpdateStudent(student);

            if (result > 0)
                return Ok("Student updated successfully.");

            return BadRequest("Failed to update student.");
        }

        /// <summary>
        /// Deletes a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student to delete.</param>
        /// <returns>The result of the operation.</returns>
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("api/students/{id}")]
        public IHttpActionResult DeleteStudent(int id)
        {
            var result = _repository.DeleteStudent(id);

            if (result > 0)
                return Ok("Student deleted successfully.");

            return BadRequest("Failed to delete student.");
        }
    }
}
