using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ORMDemo.Models.DTO
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
        [JsonProperty("D01101")]
        public int D01F01 { get; set; }

        /// <summary>
        /// Gets or sets the student name.
        /// </summary>
        [Required(ErrorMessage = "Student name is required.")]
        [StringLength(100, ErrorMessage = "Student name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name should only contain letters and spaces.")]
        [JsonProperty("D01102")]
        public string D01F02 { get; set; }

        /// <summary>
        /// Gets or sets the student age.
        /// </summary>
        [Required(ErrorMessage = "Student age is required.")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        [JsonProperty("D01103")]
        public int D01F03 { get; set; }

        /// <summary>
        /// Gets or sets the city ID associated with the student.
        /// This is an optional property (nullable).
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "City ID must be a positive integer.")]
        [JsonProperty("D01104")]
        public int? D01F04 { get; set; }

        /// <summary>
        /// Gets or sets the student's marks.
        /// </summary>
        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100.")]
        [JsonProperty("D01105")]
        public int D01F05 { get; set; }

        /// <summary>
        /// Gets or sets the student's grade.
        /// </summary>
        [Required(ErrorMessage = "Grade is required.")]
        [RegularExpression(@"^[A-Fa-f]{1}$", ErrorMessage = "Grade must be a letter from A to F.")]
        [JsonProperty("D01106")]
        public char D01F06 { get; set; }
    }
}
