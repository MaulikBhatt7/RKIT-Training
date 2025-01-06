using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LINQDemo.Controllers
{
    /// <summary>
    /// Controller that demonstrates LINQ operations on a SQL database (via repository).
    /// </summary>
    public class LINQToSQLController : ApiController
    {
        private readonly StudentRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LINQToSQLController"/> class.
        /// This constructor sets up the repository to access student and city data.
        /// </summary>
        public LINQToSQLController()
        {
            _repository = new StudentRepository();
        }

        /// <summary>
        /// Retrieves all students who have marks greater than 50, ordered by name.
        /// This is API version 1.
        /// </summary>
        /// <returns>
        /// An HTTP response containing a list of student names who have marks greater than 50.
        /// If no students are found, a NotFound result is returned.
        /// </returns>
        [HttpGet]
        [Route("get-all-students")]
        public IHttpActionResult GetAllStudentsV1()
        {
            // Fetching all students from the repository
            var students = _repository.GetAllStudents();

            // Fetching all cities from the repository (not currently used in the logic)
            var cities = _repository.GetAllCities();

            // Check if students are found, otherwise return a NotFound response
            if (students == null)
                return NotFound();

            // LINQ query: Filter students with marks greater than 50 and order by student name
            var studentDetails = from student in students
                                 where student.Marks > 50
                                 orderby student.Name
                                 select student.Name;

            // Return the student names in the response
            return Ok(studentDetails);
        }
    }
}
