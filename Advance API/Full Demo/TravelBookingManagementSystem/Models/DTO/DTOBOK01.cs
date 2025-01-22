using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TravelBookingManagementSystem.Models.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for Booking information (DTOBOK01).
    /// This class is used for adding or updating booking details.
    /// </summary>
    public class DTOBOK01
    {
        /// <summary>
        /// Gets or sets the booking ID (for update operations).
        /// Must be a positive integer.
        /// </summary>
        [JsonProperty("K01101")]
        [Range(0, int.MaxValue, ErrorMessage = "Booking ID must be 0 or a positive integer.")]
        public int K01F01 { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        [JsonProperty("K01102")]
        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, ErrorMessage = "Customer name cannot exceed 100 characters.")]
        public string K01F02 { get; set; }

        /// <summary>
        /// Gets or sets the customer email.
        /// Must be a valid email format.
        /// </summary>
        [JsonProperty("K01103")]
        [Required(ErrorMessage = "Customer email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string K01F03 { get; set; }

        /// <summary>
        /// Gets or sets the booking date.
        /// </summary>
        [JsonProperty("K01104")]
        [Required(ErrorMessage = "Booking date is required.")]
        public DateTime K01F04 { get; set; }

        /// <summary>
        /// Gets or sets the type of booking (flight or hotel).
        /// </summary>
        [JsonProperty("K01105")]
        [Required(ErrorMessage = "Booking type is required.")]
        [StringLength(50, ErrorMessage = "Booking type cannot exceed 50 characters.")]
        public string K01F05 { get; set; }

        /// <summary>
        /// Gets or sets the reference ID (flight_id or hotel_id).
        /// Must be a positive integer.
        /// </summary>
        [JsonProperty("K01106")]
        [Range(1, int.MaxValue, ErrorMessage = "Reference ID must be a positive integer.")]
        public int K01F06 { get; set; }
    }
}
