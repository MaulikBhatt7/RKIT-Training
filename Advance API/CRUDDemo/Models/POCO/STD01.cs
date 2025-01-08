using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDDemo.Models.POCO
{
    /// <summary>
    /// Plain Old CLR (Common Language Runtime) Object (POCO) for student information (STD01).
    /// This class represents the student entity for the database or internal processing.
    /// </summary>
    public class STD01
    {
        /// <summary>
        /// Gets or sets the student ID.
        /// </summary>
        public int D01F01 { get; set; }

        /// <summary>
        /// Gets or sets the student name.
        /// </summary>
        public string D01F02 { get; set; }

        /// <summary>
        /// Gets or sets the student age.
        /// </summary>
        public int D01F03 { get; set; }

        /// <summary>
        /// Gets or sets the city ID associated with the student.
        /// This is an optional property (nullable).
        /// </summary>
        public int? D01F04 { get; set; }

        /// <summary>
        /// Gets or sets the student's marks.
        /// </summary>
        public int D01F05 { get; set; }

        /// <summary>
        /// Gets or sets the student's grade.
        /// </summary>
        public char D01F06 { get; set; }
    }
}