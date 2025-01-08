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
        [JsonProperty("D01101")]
        public int D01F01 { get; set; }

        /// <summary>
        /// Gets or sets the student name.
        /// </summary>
        [JsonProperty("D01102")]
        public string D01F02 { get; set; }

        /// <summary>
        /// Gets or sets the student age.
        /// </summary>
        [JsonProperty("D01103")]
        public int D01F03 { get; set; }

        /// <summary>
        /// Gets or sets the city ID associated with the student.
        /// This is an optional property (nullable).
        /// </summary>
        [JsonProperty("D01104")]
        public int? D01F04 { get; set; }

        /// <summary>
        /// Gets or sets the student's marks.
        /// </summary>
        [JsonProperty("D01105")]
        public int D01F05 { get; set; }

        /// <summary>
        /// Gets or sets the student's grade.
        /// </summary>
        [JsonProperty("D01106")]
        public char D01F06 { get; set; }
    }
}
