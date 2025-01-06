using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQDemo.Models
{
    /// <summary>
    /// Represents a student with details like ID, name, age, city, marks, and grade.
    /// </summary>
    public class StudentModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the student.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the student.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the ID of the city where the student resides.
        /// </summary>
        public int CityID { get; set; }

        /// <summary>
        /// Gets or sets the marks obtained by the student.
        /// </summary>
        public decimal Marks { get; set; }

        /// <summary>
        /// Gets or sets the grade of the student based on their marks.
        /// </summary>
        public string Grade { get; set; }
    }
}
