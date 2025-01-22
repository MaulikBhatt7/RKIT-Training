using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TravelBookingManagementSystem.Models.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for Hotel information (DTOHTL01).
    /// This class is used for adding or updating hotel details.
    /// </summary>
    public class DTOHTL01
    {
        /// <summary>
        /// Gets or sets the hotel ID (for update operations).
        /// Can be 0 for new records.
        /// </summary>
        [JsonProperty("L01101")]
        [Range(0, int.MaxValue, ErrorMessage = "Hotel ID must be 0 or a positive integer.")]
        public int L01F01 { get; set; }

        /// <summary>
        /// Gets or sets the hotel name.
        /// </summary>
        [JsonProperty("L01102")]
        [Required(ErrorMessage = "Hotel name is required.")]
        [StringLength(100, ErrorMessage = "Hotel name cannot exceed 100 characters.")]
        public string L01F02 { get; set; }

        /// <summary>
        /// Gets or sets the city of the hotel.
        /// </summary>
        [JsonProperty("L01103")]
        [Required(ErrorMessage = "City of the hotel is required.")]
        [StringLength(100, ErrorMessage = "City name cannot exceed 100 characters.")]
        public string L01F03 { get; set; }

        /// <summary>
        /// Gets or sets the price per night at the hotel.
        /// Must be a positive value.
        /// </summary>
        [JsonProperty("L01104")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price per night must be greater than 0.")]
        public decimal L01F04 { get; set; }

        /// <summary>
        /// Gets or sets the hotel rating.
        /// Must be between 1 and 5.
        /// </summary>
        [JsonProperty("L01105")]
        [Range(1, 5, ErrorMessage = "Hotel rating must be between 1 and 5.")]
        public float L01F05 { get; set; }

        /// <summary>
        /// Gets or sets the number of available rooms at the hotel.
        /// Must be a non-negative integer.
        /// </summary>
        [JsonProperty("L01106")]
        [Range(0, int.MaxValue, ErrorMessage = "Number of available rooms must be a non-negative integer.")]
        public int L01F06 { get; set; }
    }
}
