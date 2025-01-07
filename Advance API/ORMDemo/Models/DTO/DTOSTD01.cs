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
        [JsonProperty("P01101")]
        public int D01F01 { get; set; }

        /// <summary>
        /// Gets or sets the student name.
        /// </summary>
        [JsonProperty("P01102")]
        public string D01F02 { get; set; }

        /// <summary>
        /// Gets or sets the student age.
        /// </summary>
        [JsonProperty("P01103")]
        public int D01F03 { get; set; }

        /// <summary>
        /// Gets or sets the city ID associated with the student.
        /// This is an optional property (nullable).
        /// </summary>
        [JsonProperty("P01104")]
        public int? D01F04 { get; set; }

        /// <summary>
        /// Gets or sets the student's marks.
        /// </summary>
        [JsonProperty("P01105")]
        public int D01F05 { get; set; }

        /// <summary>
        /// Gets or sets the student's grade.
        /// </summary>
        [JsonProperty("P01106")]
        public char D01F06 { get; set; }
    }
}
