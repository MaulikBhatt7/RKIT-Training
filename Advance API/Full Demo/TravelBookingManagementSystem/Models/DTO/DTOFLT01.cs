using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TravelBookingManagementSystem.Models.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for Flight information (DTOFLT01).
    /// This class is used for adding or updating flight details.
    /// </summary>
    public class DTOFLT01
    {
        /// <summary>
        /// Gets or sets the flight ID (for update operations).
        /// Can be 0 for new records.
        /// </summary>
        [JsonProperty("T01101")]
        [Range(0, int.MaxValue, ErrorMessage = "Flight ID must be 0 or a positive integer.")]
        public int T01F01 { get; set; }

        /// <summary>
        /// Gets or sets the flight number.
        /// </summary>
        [JsonProperty("T01102")]
        [Required(ErrorMessage = "Flight number is required.")]
        [StringLength(20, ErrorMessage = "Flight number cannot exceed 20 characters.")]
        public string T01F02 { get; set; }

        /// <summary>
        /// Gets or sets the departure city.
        /// </summary>
        [JsonProperty("T01103")]
        [Required(ErrorMessage = "Departure city is required.")]
        [StringLength(100, ErrorMessage = "Departure city cannot exceed 100 characters.")]
        public string T01F03 { get; set; }

        /// <summary>
        /// Gets or sets the arrival city.
        /// </summary>
        [JsonProperty("T01104")]
        [Required(ErrorMessage = "Arrival city is required.")]
        [StringLength(100, ErrorMessage = "Arrival city cannot exceed 100 characters.")]
        public string T01F04 { get; set; }

        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        [JsonProperty("T01105")]
        [Required(ErrorMessage = "Departure time is required.")]
        public DateTime T01F05 { get; set; }

        /// <summary>
        /// Gets or sets the arrival time.
        /// </summary>
        [JsonProperty("T01106")]
        [Required(ErrorMessage = "Arrival time is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid arrival time format.")]
        public DateTime T01F06 { get; set; }

        /// <summary>
        /// Gets or sets the price of the flight.
        /// Must be a positive decimal value.
        /// </summary>
        [JsonProperty("T01107")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal T01F07 { get; set; }

        /// <summary>
        /// Gets or sets the airline name.
        /// </summary>
        [JsonProperty("T01108")]
        [Required(ErrorMessage = "Airline name is required.")]
        [StringLength(100, ErrorMessage = "Airline name cannot exceed 100 characters.")]
        public string T01F08 { get; set; }
    }
}
