using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for student information (DTOSTD01).
    /// This class is used to represent student data for transfer purposes.
    /// </summary>
    public class DTOSTD01
    {
        /// <summary>
        /// Gets or sets the student ID.
        /// </summary>
        [Required(ErrorMessage = "Student ID is required.")]
        public int D01F01 { get; set; }

        /// <summary>
        /// Gets or sets the student name.
        /// </summary>
        [JsonProperty("D01102")]
        [Required(ErrorMessage = "Student name is required.")]
        [StringLength(100, ErrorMessage = "Student name cannot exceed 100 characters.")]
        public string D01F02 { get; set; }

        /// <summary>
        /// Gets or sets the student age.
        /// </summary>
        [JsonProperty("D01103")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int D01F03 { get; set; }

        /// <summary>
        /// Gets or sets the city ID associated with the student.
        /// This is an optional property (nullable).
        /// </summary>
        [JsonProperty("D01104")]
        [Range(1, int.MaxValue, ErrorMessage = "City ID must be a positive integer.")]
        public int? D01F04 { get; set; }

        /// <summary>
        /// Gets or sets the student's marks.
        /// </summary>
        [JsonProperty("D01105")]
        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100.")]
        public int D01F05 { get; set; }
    }
}
