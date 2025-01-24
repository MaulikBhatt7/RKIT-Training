using DependancyInjection.Models;
using DependancyInjection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependancyInjection.Controllers
{
    /// <summary>
    /// The PersonController class defines API endpoints for person-related actions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPerson _objPerson;
        private readonly IEducation _objEducation;
        private readonly ICricket _objCricket;
        private readonly IHome _objHome;

        /// <summary>
        /// Initializes a new instance of the PersonController class.
        /// </summary>
        /// <param name="objPerson">An object implementing the IPerson interface.</param>
        /// <param name="objEducation">An object implementing the IEducation interface.</param>
        /// <param name="objHome">An object implementing the IHome interface.</param>
        /// <param name="objCricket">An object implementing the ICricket interface.</param>
        public PersonController(
           IPerson objPerson,
           IEducation objEducation,
           IHome objHome,
           ICricket objCricket)
        {
            _objPerson = objPerson;
            _objHome = objHome;
            _objCricket = objCricket;
            _objEducation = objEducation;
        }

        /// <summary>
        /// GET api/person endpoint.
        /// </summary>
        /// <returns>A response indicating the result of the actions.</returns>
        [HttpGet]
        public IActionResult GetPerson()
        {
            // Uncomment these lines if you wish to instantiate these objects directly
            // Person objPerson = new Person();
            // objPerson.Greet();
            // objPerson.Teach();
            // objPerson.Play();

            // Home objHome = new Home();
            // Person objPerson = new Person(objHome);
            // objPerson.Greet();
            // objPerson.objSchool = new School();
            // objPerson.objSchool = new College();
            // objPerson.Teach();
            // Cricket objCricket = new Cricket();
            // objPerson.Play(objCricket);

            // Use the injected dependencies to perform actions
            _objPerson.Greet();
            _objPerson.objEducation = _objEducation;
            _objPerson.Teach();
            _objPerson.Play(_objCricket);

            return Ok();
        }
    }
}