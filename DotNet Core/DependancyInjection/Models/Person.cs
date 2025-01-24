using DependancyInjection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependancyInjection.Models
{
    /// <summary>
    /// The Person class implements the IPerson interface.
    /// </summary>
    public class Person : IPerson
    {
        // Private fields to hold the injected dependencies
        private IHome _objHome;
        private IEducation _objEducation;

        /// <summary>
        /// Gets or sets the Education service.
        /// </summary>
        public IEducation objEducation
        {
            set { _objEducation = value; }
        }

        /// <summary>
        /// Initializes a new instance of the Person class.
        /// </summary>
        /// <param name="objHome">An object implementing the IHome interface.</param>
        public Person(IHome objHome)
        {
        
            // _objHome = new Home();
            // _objSchool = new School();
            // _objCricket = new Cricket();

            // In the constructor, the IHome dependency is injected
            _objHome = objHome;
        }

        /// <summary>
        /// Implements the Greet method from the IPerson interface.
        /// </summary>
        public void Greet()
        {
            // Calls the Greet method of the injected IHome instance
            _objHome.Greet();
        }

        /// <summary>
        /// Implements the Teach method from the IPerson interface.
        /// </summary>
        public void Teach()
        {
            // Calls the Teach method of the injected IEducation instance if it's not null
            if (_objEducation != null)
                _objEducation.Teach();
        }

        /// <summary>
        /// Implements the Play method from the IPerson interface.
        /// </summary>
        /// <param name="objCricket">An object implementing the ICricket interface.</param>
        public void Play(ICricket objCricket)
        {
            // Calls the Play method of the injected ICricket instance
            objCricket.Play();
        }
    }
}